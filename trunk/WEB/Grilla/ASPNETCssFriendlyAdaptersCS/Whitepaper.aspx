<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="WhitePaper.aspx.cs" Inherits="WhitePaper" Title="White Paper: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" StyleSheetTheme="Enhanced" Theme="Enhanced" %>
<%@ Register TagPrefix="wilco" Namespace="Wilco.Web.SyntaxHighlighting" Assembly="Wilco.SyntaxHighlighter" %>

<asp:Content ContentPlaceHolderID="MainContent" Runat="Server">
  <div id="WhitePaper">
    <h1>ASP.NET 2.0 CSS Friendly Control Adapters: The White Paper</h1>

    <h2>Contents</h2>
    
    <asp:TreeView ID="WhitePaperTocTree" runat="server" DataSourceID="WhitePaperTocDS" SkinID="WhitePaperTocTree" CssSelectorClass="WhitePaperToc">
        <DataBindings>
            <asp:TreeNodeBinding PopulateOnDemand="false" DataMember="siteMapNode" TextField="title" ToolTipField="description" NavigateUrlField="url" />
        </DataBindings>
    </asp:TreeView>
    <asp:SiteMapDataSource runat="server" ID="WhitePaperTocDS" SiteMapProvider="WhitePaperTocSiteMapProvider" ShowStartingNode="false" />

    <a id="Summary"></a>
    <h2>Summary</h2>
    <p>
        Control adapters let you change the HTML markup produced by ASP.NET controls. Rather than
        having to invent a new control to generate the markup you want, in many cases you can
        simply write a small adapter for an existing ASP.NET control.
    </p>
    <p>
        This white paper discusses control adapters in general and a sample set of adapters in particular.
        The samples demonstrate how you can adapt controls so they are easier to style with CSS. The
        adapters you create in the future may share this or some other purpose.
    </p>
    
    <a id="Introduction"></a>
    <h2>Introduction</h2>
    <p>
        ASP.NET supplements client-side HTML with a set of powerful server-side tags. For example, by adding
        a single ASP.NET Menu tag to a web page you can create a completely functional menu. Without this Menu
        tag you would typically have to write dozens, even hundreds, of HTML tags. In fact, if you look at the
        HTML produced by ASP.NET's Menu control you'll find it does produce hundreds of HTML tags. Obviously it's
        a huge boost in your productivity as an author when you can use a single Menu tag rather than having to
        invent and maintain hundreds of HTML tags.
    </p>
    <p>
        Some authors, however, would prefer that different HTML markup was produced by ASP.NET controls like Menu.
        For example, it's becoming increasingly common to see menus implemented using nested &lt;ul&gt; tags rather
        than the &lt;table&gt; tags produced by Menu and TreeView controls in version 2.0 of the ASP.NET framework.
        From nested &lt;ul&gt; tags you can develop the so-called
        <a href="http://www.meyerweb.com/eric/css/edge/menus/demo.html" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="pure CSS menus">pure CSS menus</a>,
        an approach that continues to be
        <a href="http://www.alistapart.com/articles/horizdropdowns/" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="more about pure CSS menus">developed and refined</a>. 
    </p>
    <p>
        This presents a wonderful opportunity to demonstrate the power and flexibility of ASP.NET's control
        adapters.  There are plenty of great things about ASP.NET's Menu control that would be shame to have to
        recreate.  After all, the Menu control gives us a great mechanism for converting hierarchical data
        from a database or XML file into submenus and leaf menu items. All we want to do is replace the
        logic used by the Menu to generate HTML for these submenus and leaves. That's what control adapters
        let you do.  They replace just the chunk of logic devoted to figuring out the final HTML that the
        control produces in response to a request from a browser.
    </p>
    <p>
        So, for example, an adapter can improve the Menu control so it renders &lt;ul&gt; tags rather
        than its usual &lt;table&gt; tags. All the rest of the Menu tag is retained.
    </p>
    <p>
        You may be thinking, "That's fine but I need my web site to work even if the client visits it with an
        old browser, one in which those <em>pure CSS menus</em> don't work!" The architects of the ASP.NET
        framework considered that.  Their solution was to allow you to stipulate which browsers should trigger
        the use of which adapters.  So, it's easy to configure your web site to use the adapted controls only when
        it's visited by, say, modern versions of particular browsers like Internet Explorer, Firefox or Opera.        
    </p>
    <p>
        Readers who are familiar with traditional object oriented programming may be thinking, "I can do the
        same thing by deriving a new class based on Menu and simply override the necessary rendering methods."
        That is certainly a viable approach but, in practice, adapters are easier to introduce to a site. You
        don't need to add the <strong>@Register</strong> directives to your pages (as you do when you use custom controls). 
        Further, as mentioned above, the ASP.NET framework comes with a built-in means to apply the adapters to just
        certain browsers.  When you build entirely new custom controls you have to write your own logic to
        handle browser detection to vary the response.  That's not to say that custom controls are bad.  Rather,
        it suggests that it's worth considering if an easy-to-write adapter might solve certain problems where
        you've employed custom controls in the past.
    </p>

    <a id="Background"></a>
    <h2>Background</h2>

    <a id="BackgroundArchitecture"></a>
    <h3>Architecture</h3>
    <p>
        Developers interested in studying the theory and architecture underpinning control adapters
        are encouraged to review the
        <a href="http://windowssdk.msdn.microsoft.com/en-us/library/67276kc5.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Microsoft documentation">previously 
        published literature</a> on the subject.
    </p>
    <p>
        More details are revealed in the documentation provided by Microsoft for the most important
        classes related to adapters:
    </p>
    <ul>    
        <li><a href="http://windowssdk.msdn.microsoft.com/en-us/library/system.web.ui.adapters.controladapter.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="ControlAdapter">ControlAdapter</a></li>
        <li><a href="http://windowssdk.msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.adapters.webcontroladapter.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="WebControlAdapter">WebControlAdapter</a></li>
        <li><a href="http://windowssdk.msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.adapters.databoundcontroladapter.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="DataBoundControlAdapter">DataBoundControlAdapter</a></li>
        <li><a href="http://windowssdk.msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.adapters.hidedisabledcontroladapter.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="HideDisabledControlAdapter">HideDisabledControlAdapter</a></li>
        <li><a href="http://windowssdk.msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.adapters.hierarchicaldataboundcontroladapter.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="HierarchicalDataBoundControlAdapter">HierarchicalDataBoundControlAdapter</a></li>
        <li><a href="http://windowssdk.msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.adapters.menuadapter.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="MenuAdapter">MenuAdapter</a></li>
    </ul>

    <a id="BackgroundPracticalPatterns"></a>
    <h3>Practical Patterns</h3>
    <p>
        Along with understanding the architecture underpinning control adapters, you may wish to take a look
        at the ASP.NET <a href="http://www.asp.net/QuickStart/aspnet/doc/extensibility.aspx#A" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="ASP.NET QuickStarts">QuickStart</a>
        tutorials that discuss building adapters.
    </p>    
    <p>
        It's easy to create an ASP.NET control adapter.</p>
    <ul>
        <li>
            <p>
                Begin by creating a class derived from System.Web.UI.Adapters.ControlAdapter or a class derived from
                it, e.g., System.Web.UI.WebControls.Adapters.DataBoundControlAdapter or System.Web.UI.WebControls.Adapters.HierarchicalDataBoundControlAdapter. 
                Override a few methods like RenderBeginTag, RenderContents and RenderEndTag that produce the
                adapted control's markup.</p>
            <p>
                This sample control adapter kit demonstrates how this is done. For example, the screenshot below
                shows a portion of this kit's TreeView adapter code (C# version).</p>
                <img runat="server" src="~/images/Whitepaper/TreeViewAdapterCode.gif" alt="TreeView adapter code" />                
            <p>
                The adapter class that you create can be added into your web project and compiled as part of the 
                project.  For even greater re-use, you could add it to a class library project and reference it 
                from multiple web projects.</p>
        </li>
        <li>
            <p> 
                To register the adapter class add an entry to a
                <a href="SrcViewer.aspx?inspect=~/App_Browsers/CSSFriendlyAdapters.browser&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CSSFriendlyAdapters.browser">.browser</a> 
                file in the App_Browsers folder. See this kit's 
                <a runat="server" href="~/WalkThru/WalkThrough.aspx" title="tutorial for the kit">tutorial</a> for more information about the 
                <a runat="server" href="~/WalkThru/WalkThrough.aspx#DotBrowser" title=".browser file">.browser</a> file.</p>
        </li>
    </ul>
    
    <a id="BackgroundViewState"></a>
    <h3>View State</h3>
    <p>
        <a href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnaspp/html/viewstate.asp" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Understanding ASP.NET View State">View state</a>
        can be characterized in a weird and funny way: when it works well you don't notice it!
    </p>    
    <p>
        The term <em>view state</em> refers to the overall appearance of a web page just before its
        &lt;form method="post"&gt; is submitted by the user. A page <em>maintains</em> its view state
        when it restores its appearance after posting back to the server.
    </p>
    <p>
        When it works well you don't notice it. The reloaded page simply looks like it did a moment earlier.
        Typically, one only notices failures to maintain view state: places where the page looks different 
        after it reloads.
    </p>    
    <p>
        A textbox can restore its appearance merely by setting the <strong>value</strong> attribute in its
        &lt;input&gt; tag to whatever was submitted. Maintaining the view state of a
        <a href="TreeView.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="TreeView">tree</a>
        or other complex control can be far more complicated.
    </p>
    <p>
        The traditional ASP.NET TreeView renders itself as an elaborately nested set of &lt;table&gt; tags.
        This kit's TreeView adapter renders nested &lt;ul&gt; tags. Either way, the tree uses client-side 
        JavaScript to allow users to expand a node to reveal its children. The server typically has no idea
        this is happening. So, on the client, the tree must create a map of its expansion state and send it
        to the server when the page is submitted if it hopes to restore that state.
    </p>
    <p>
        There are a 
        <a href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/diforwc-ch05.asp" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Design and Implementation Guidelines for Web Clients">variety of ways</a>
        to send that data back to the server. Often a hidden form element is used. This is the strategy employed
        by the TreeView adapter in this kit.
    </p>
    <p>
        Here is an outline of the implementation pattern used by the
        <a href="SrcViewer.aspx?inspect=~/App_Code/Adapters/TreeViewAdapter.cs&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CSSFriendly.TreeViewAdapter">CSSFriendly.TreeViewAdapter</a>
        class to maintain view state.
    </p>
    <ul>
        <li>
            Declare a private HiddenField property called _viewState.
        </li>
        <li>
            Override the SaveAdapterViewState, LoadAdapterViewState and OnLoad methods.
        </li>
        <li>
            In SaveAdapterViewState, register some JavaScript that sets the value of a hidden form element. The 
            value will be a string representing which nodes in the tree are expanded immediately before the form 
            is submitted. SaveAdapterViewState itself returns the same sort of string representing how the tree 
            is expanded at present.
        </li>
        <li>
            In LoadAdapterViewState, find the value submitted in the hidden form element. Compare it to the
            original value to see if the view state has changed. Note if they differ.             
        </li>
        <li>
            In OnLoad, use the latest view state data retrieved in LoadAdapterViewState to re-expand the tree.
        </li>
    </ul>

    <a id="Samples"></a>
    <h2>Samples</h2>

    <a id="SamplesGoalsScope"></a>
    <h3>Goals and Scope</h3>
    <p>
        First and foremost, the samples included with this web site are intended to demonstrate how to develop and 
        use control adapters. You may find these samples to be sufficiently robust for use in your own
        ASP.NET 2.0 web sites. Or, you may wish to enhance these samples before deploying them. In some cases
        you'll find that they serve as a pattern from which to create entirely new adapters for other ASP.NET controls.
    </p>
    <p>
        Each of the sample adapters recognize a limited number of the public properties of the control it adapts.
        These samples produce markup that can be easily styled with classic CSS techniques. Therefore, these adapters 
        ignore control properties like <strong>Font</strong> or <strong>BorderColor</strong>.  Without the adapters, 
        those sorts of properties cause the control to generate additional markup, inline or embedded CSS.
        When the sample adapters are enabled, these sorts of stylistic control properties are not needed since 
        these same effects can be achieved by creating your own CSS rules to control the choice of font or border color.
    </p>
    <p>
        The properties that the sample control adapters honor are properties that impact <em>content</em>, not style.
        For example, if you specify the <strong>HeaderText</strong> property on a 
        <a href="DetailsView.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="DetailsView">DetailsView</a> 
        and <a href="FormView.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="FormView">FormView</a> control, it will be recognized as important by the adapter because it 
        impacts what markup and content is produced, rather than what that content looks like.
    </p>
    <p>
        Remember that these adapters are samples.  Since they are not part of the official ASP.NET framework you
        may find a few control properties (unrelated to style) that the adapters ignore. Keep in mind that the intent of
        these adapters is to show you how to build adapters. Armed with this knowledge you'll, hopefully, discover that
        it's fairly straightforward to enhance the adapters to support additional control properties. 
    </p>

    <a id="SamplesArchitecture"></a>
    <h3>Architecture</h3>
    <p>
        These sample control adapters produce markup that is intended to be simple and predictable. For example,
        the adapters for the <a href="Menu.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Menu">Menu</a> and 
        <a href="TreeView.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="TreeView">TreeView</a> controls produce 
        nested &lt;ul&gt; tags that mimic the nesting of the hierarchical data bound to that Menu or TreeView.        
    </p>
    <p>
        Similarly, each adapter predictably assigns CSS classes to some of the tags it produces.
    </p>
    <p>
        By keeping this scheme simple it's fairly easy to create a set of CSS rules that completely govern
        the appearance of the adapted control.
    </p>
    <p>
        This is a departure from the approach historically taken by the ASP.NET controls where you never need
        to know anything about the markup ultimately produced by a control.  In the past, when you've needed
        to alter the appearance of a control you modified the value of one of its properties.
    </p>
    <p>
        For example, when building a Menu with a blue background you would traditionally set a property like
        <strong>StaticMenuStyle-BackColor</strong>. When the adapters are used, you'll instead modify a CSS rule like this:
    </p>
    <wilco:SyntaxHighlighter id="css1" runat="server" Language="CSS" Mode="Source" Text="
        ul.AspNet-Menu li
        {
            background:Blue;
        }" />    


    <a id="SamplesCssSelectorClass"></a>
    <h3>CssSelectorClass</h3>
    <p>
        It's quite common for a page to contain more than a single Menu or TreeView, etc.  In those cases you'll typically
        want each control to look distinct.  For example, a page might have three menus: two of which must look
        similar, the third must look different. Fortunately, these sample control adapters make it easy accomplish
        this.
    </p>
    <p>
        The key is to use a new (expando) attribute called <strong>CssSelectorClass</strong>. For instance, the
        <a href="Menu.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Menu">Menu</a> example contains two Menu tags that look like this:
    </p>
    <wilco:SyntaxHighlighter id="css2" runat="server" Language="ASPX" Mode="Source" Text='
        &lt;asp:Menu ID="Menu1" runat="server" SkinID="SampleMenuVertical" DataSourceID="ExampleSiteMapDS" 
        CssSelectorClass="PrettyMenu" /&gt;
        &lt;asp:Menu ID="Menu2" runat="server" SkinID="SampleMenuHorizontal" DataSourceID="ExampleSiteMapDS" 
        CssSelectorClass="PrettyMenu" Orientation="Horizontal" /&gt;' />    
    <p>
        Notice that <strong>CssSelectorClass</strong> has a value of <strong>PrettyMenu</strong>.  Now look at the 
        CSS selectors found in 
        <a href="SrcViewer.aspx?inspect=~/App_Themes/Basic/MenuExample.css&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="MenuExample.css">MenuExample.css</a>. 
        (This is the style sheet that controls most aspects of how the menus appear.)  Many of the rules include 
        <strong>PrettyMenu</strong> in their selectors.  For example:
    </p>
    <wilco:SyntaxHighlighter id="css3" runat="server" Language="CSS" Mode="Source" Text="
        .PrettyMenu ul.AspNet-Menu li:hover, 
        .PrettyMenu ul.AspNet-Menu li.AspNet-Menu-Hover
        {
            background:#4682B3;
        }" />
    <p>
        This CSS rule controls the background color that the menu should use to highlight an item that
        the cursor is hovering over.
    </p>
    <p>
        Now, return to the <a href="Menu.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Menu">Menu</a> sample.  Notice that there is
        a third menu.  It's at the top of the page and lets you navigate to the other example pages.
        It uses a completely different set of colors, etc., compared to the menus demonstrated in the
        center of the page.  This menu (at the top of the page) is created in 
        <a href="SrcViewer.aspx?inspect=~/Main.master&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Main.master">Main.master</a>
        like this:
    </p>
    <wilco:SyntaxHighlighter id="css4" runat="server" Language="ASPX" Mode="Source" Text='
        &lt;asp:Menu ID="MainNav" runat="server" SkinId="MainNav" DataSourceID="SiteMapDS" CssSelectorClass="MainMenu" Orientation="Horizontal" /&gt;' />
    <p>
        Notice that the <strong>CssSelectorClass</strong> has a different value in this case.  It is set to <strong>MainMenu</strong>.  
        Now look at the CSS selectors in 
        <a href="SrcViewer.aspx?inspect=~/App_Themes/Basic/MainMaster.css&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="MainMaster.css">MainMaster.css</a>.
        Notice that the rules pertaining to this menu are distinguished by their use of <strong>MainMenu</strong>.  For example:
    </p>
    <wilco:SyntaxHighlighter id="css5" runat="server" Language="CSS" Mode="Source" Text="
        .MainMenu .AspNet-Menu-Horizontal ul.AspNet-Menu li:hover,
        .MainMenu .AspNet-Menu-Horizontal ul.AspNet-Menu li.AspNet-Menu-Hover
        {
            color: White;
            background: #165EA9 url(bg-menu-main.png) repeat-x;
        }" />
    <p>
        The different CSS classes (PrettyMenu and MainMenu) allow us to create CSS rules that visually
        distinguish one group of menus from another.
    </p>
    <p>
        All of the sample control adapters (not just Menu) allow you to use the expando property:
        <strong>CssSelectorClass</strong>.
    </p>

    <a id="SamplesConventions"></a>
    <h3>Conventions</h3>
    <p>
        When you first learn to use CSS you tend to build fairly simple rules that govern straightforward
        properties like color, font size or border thickness.  Later, you discover that you can use CSS to
        precisely control the position of elements on a page with properties like <strong>padding</strong>, 
        <strong>margin</strong> or <strong>position</strong>. Ultimately, you find that by coupling certain properties
        (like <strong>display</strong> and <strong>float</strong>) to pseudo-classes (like
        <strong>hover</strong>), you can control the behavior of web elements.  In fact, these behavioral techniques are
        the crux of implementations like 
        <a href="http://www.meyerweb.com/eric/css/edge/menus/demo.html" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="pure CSS menus">pure CSS menus</a>.
    </p>
    <p>
        In practice, you rarely need to change behavioral CSS rules when you reskin a web site.  Instead,
        you tend to find it is sufficient to modify the CSS rules governing simple display properties like color.
        Therefore, the CSS rules that apply to these sample web pages are segregated into two groups:
    </p>
    <ul>
        <li>Rules that primarily control simple properties like color.</li>
        <li>Rules that primarily control behavior like when an element should appear or disappear.</li>
    </ul>
    <p>
        In these samples, behavioral CSS rules are contained in style sheets named for the controls they pertain to. 
        You will probably not need to edit these rules, even when you reskin a site or use these sample adapters 
        in your own web sites. The style sheets containing these behavioral rules are found in the CSS folder.
    </p>
    <p>
        CSS rules pertaining to properties like color are contained in style sheets in the individual theme subfolders
        beneath the App_Themes folder.
    </p>
    <p>
        Unfortunately, the distinction between behavioral CSS rules and design-centric rules is a bit fuzzy. For example
        you might imagine that you could modify any rule in 
        <a href="SrcViewer.aspx?inspect=~/App_Themes/Basic/MenuExample.css&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="MenuExample.css">MenuExample.css</a>
        (or even omit 
        <a href="SrcViewer.aspx?inspect=~/App_Themes/Basic/MenuExample.css&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="MenuExample.css">MenuExample.css</a>
        from your web site entirely) without compromising the behavior of a menu. Alas, that isn't true.  It is
        possible to alter certain CSS properties that are generally considered design-centric in such a way that they
        end up radically altering the behavior of a control like Menu.  This is particularly true of CSS
        properties like <strong>margin</strong>, <strong>padding</strong> and (especially) <strong>width</strong>.  
        Small changes to these sorts of properties are typically made to alter the look of a web page by slightly 
        shifting content left/right or up/down. However, you can sometimes stumble into situations where an element becomes 
        too wide to be properly contained by its parent element (which may have a smaller width) so its placement on the page suddenly
        is radically altered.  It may, for example, have to be pushed below other elements in order for the
        browser to find room for it.  When these sorts of radical layout changes occur on a page the overall
        behavior of something like a Menu can be unintentionally damaged.
    </p>
    <p>
        In practice, when modifying properties like <strong>margin</strong>, <strong>padding</strong> and <strong>width</strong> 
        you'll find that it's usually  best to make a small handful of changes to the CSS rules and then test the results by refreshing 
        the page in a browser. Typically, if your changes suddenly push some property past its limit you'll see an 
        obvious problem on the page. If this occurs, you can back out the CSS changes you made and try again with 
        smaller changes to the <strong>margin</strong>, <strong>padding</strong> and <strong>width</strong>.
    </p>

    <a id="SamplesAdaptedControls"></a>
    <h3>Adapted Controls</h3>
    <p>
        The following diagrams show some of the more important styles used in the example pages. By studying these
        images you will better appreciate the influence of these styles on the rendition of each control.         
    </p>
    <div id="CSSClasses">
        <a id="SamplesCSSClassesMenu"></a>
        <h4>Menu</h4>
        <img src="images/Whitepaper/Css_Menu.gif" alt="CSS rules that impact the markup rendered by the Menu adapter" />

        <a id="SamplesCSSClassesTreeView"></a>
        <h4>TreeView</h4>
        <img src="images/Whitepaper/Css_TreeView.gif" alt="CSS rules that impact the markup rendered by the TreeView adapter" />

        <a id="SamplesCSSClassesDetailsView"></a>
        <h4>DetailsView</h4>
        <img src="images/Whitepaper/Css_DetailsView.gif" alt="CSS rules that impact the markup rendered by the DetailsView adapter" />

        <a id="SamplesCSSClassesFormView"></a>
        <h4>FormView</h4>
        <img src="images/Whitepaper/Css_FormView.gif" alt="CSS rules that impact the markup rendered by the FormView adapter" />

        <a id="SamplesCSSClassesGridView"></a>
        <h4>GridView</h4>
        <img src="images/Whitepaper/Css_GridView.gif" alt="CSS rules that impact the markup rendered by the GridView adapter" />

        <a id="SamplesCSSClassesDataList"></a>
        <h4>DataList</h4>
        <img src="images/Whitepaper/Css_DataList.gif" alt="CSS rules that impact the markup rendered by the DataList adapter" />
        
        <a id="SamplesCSSClassesLogin"></a>
        <h4>Login</h4>
        <img src="images/Whitepaper/Css_Login.gif" alt="CSS rules that impact the markup rendered by the Login adapter" />

        <a id="SamplesCSSClassesChangePassword"></a>
        <h4>ChangePassword</h4>
        <img src="images/Whitepaper/Css_ChangePassword.gif" alt="CSS rules that impact the markup rendered by the ChangePassword adapter" />

        <a id="SamplesCSSClassesPasswordRecovery"></a>
        <h4>PasswordRecovery</h4>
        <img src="images/Whitepaper/Css_PasswordRecovery.gif" alt="CSS rules that impact the markup rendered by the PasswordRecovery adapter" />

        <a id="SamplesCSSClassesCreateUserWizard"></a>
        <h4>CreateUserWizard</h4>
        <img src="images/Whitepaper/Css_CreateUserWizard.gif" alt="CSS rules that impact the markup rendered by the CreateUserWizard adapter" />

        <a id="SamplesCSSClassesLoginStatus"></a>
        <h4>LoginStatus</h4>
        <img src="images/Whitepaper/Css_LoginStatus.gif" alt="CSS rules that impact the markup rendered by the LoginStatus adapter" />
    </div>    

    <a id="SamplesUsingInYourWebSite"></a>
    <h3>Using These Adapters in Your Web Site</h3>
    <p>
        These control adapters can be used in any ASP.NET 2.0 web site, not just this sample site.
        When you 
        <a runat="server" href="~/WalkThru/WalkThrough.aspx#DownloadAndInstall" title="tutorial for the kit">download and install</a>
        this kit's VSI file new web site templates will be added to
        Visual Studio.  These allow you to reproduce this whole sample kit locally or create a slimmer
        version that has just the essential files plus a small number of sample pages to get you started.
    </p>        
    <p>
        If you want to integrate these adapters into an existing site, follow these instructions:        
    </p>
    <div id="UsingInYourWebSite">
        <a id="SamplesCopyFiles"></a>
        <h4>Copy Some Files</h4>
        <ul>
            <li>
                Locate the root folder for your web application.  Create the following subfolders in this root folder
                if they don't yet exist:
                <ul>
                    <li>App_Browsers</li>
                    <li>App_Code</li>
                    <li>App_Themes</li>
                    <li>CSS</li>
                    <li>JavaScript</li>
                </ul>
            </li>
            <li>
                Copy the file named
                <a href="SrcViewer.aspx?inspect=~/App_Browsers/CSSFriendlyAdapters.browser&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CSSFriendlyAdapters.browser">CSSFriendlyAdapters.browser</a>
                from the <strong>App_Browsers</strong> folder 
                in this sample web application to your web application's <strong>App_Browsers</strong> folder.  Typically you won't 
                need to edit this file; its current settings will work for your web application, too. You can define which browsers
                use the adapters by editing 
                <a href="SrcViewer.aspx?inspect=~/App_Browsers/CSSFriendlyAdapters.browser&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CSSFriendlyAdapters.browser">CSSFriendlyAdapters.browser</a>.
                When developing your own sites in the future, it's helpful to remember that you can
                experimentally delete
                <a href="SrcViewer.aspx?inspect=~/App_Browsers/CSSFriendlyAdapters.browser&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CSSFriendlyAdapters.browser">CSSFriendlyAdapters.browser</a>
                when you want to see the unadapted markup that the ASP.NET framework would normally generate for a page.
            </li>
            <li>
                Copy the entire <strong>Adapters</strong> folder from the <strong>App_Code</strong> folder in this sample web 
                application to your web application's <strong>App_Code</strong> folder.  You do not need to modify these files, 
                nor do you need to compile them or build a DLL explicitly from them. ASP.NET 2.0 will do all that work automatically 
                for you. (Of course, you can build a DLL if you prefer.  In that case, you would put that DLL into your web
                application's <strong>bin</strong> folder and you would not copy the <strong>Adapters</strong> folder to 
                <strong>App_Code</strong>.)
            </li>
            <li>
                Copy the entire <strong>JavaScript</strong> folder in this sample web application to your web application.
                You do not need to modify these files.
            </li>
            <li>
                Copy the entire <strong>CSS</strong> folder in this sample web application to your web application.
                Be sure to copy the <strong>BrowserSpecific</strong> subfolder, too. The following markup must be present in
                your page's &lt;head&gt;. It imports a set of style sheets with rules that are independent of your
                page's theme. Conditional comments are used to add a special style sheet used only for previous versions of Internet
                Explorer. See
                <a href="SrcViewer.aspx?inspect=~/Main.master&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Main.master">Main.master</a>
                for an example of where this markup is used in this sample kit's pages.
                <wilco:SyntaxHighlighter id="css10" runat="server" Language="CSS" Mode="Source" Text='
&lt;link runat="server" rel="stylesheet" href="~/CSS/Import.css" type="text/css" id="AdaptersInvariantImportCSS" /&gt;
&lt;!--[if lt IE 7]&gt;
    &lt;link runat="server" rel="stylesheet" href="~/CSS/BrowserSpecific/IEMenu6.css" type="text/css"&gt;
&lt;![endif]--&gt;' />
            </li>
            <li>
                Create a folder (or choose an existing folder) within the <strong>App_Themes</strong> folder. This is your <em>theme</em>
                folder.
            </li>
            <li>
                Copy some or all of the files from this sample web application's <strong>Basic</strong> theme folder into your
                theme folder. For example, if you want to create an adapted Menu, the styles in
                <a href="SrcViewer.aspx?inspect=~/App_Themes/Basic/MenuExample.css&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="MenuExample.css">MenuExample.css</a>
                will get you started. Copy that file into your own theme folder (a subfolder of App_Themes in your web site).
                Then, modify the CSS property values and perhaps the CSS selectors for the rules to make Menu appear
                as you wish.  Making CSS property modifications is discussed in more detail later in this document.
                See: <a href="#SamplesMatchAttributes" title="Match CSS to ASP.NET Attributes">Match CSS to ASP.NET Attributes</a>.
            </li>
            <li>
                Depending on if/how you modify the CSS rules in the various <strong>[control]Example.css</strong> files you may
                need some of the images found in this sample web application's <strong>Basic</strong> theme folder. Likewise
                you may wish to create an <strong>Images</strong> folder in the root of your web application and copy into it
                some (or all) of the files found in this sample web application's <strong>Images</strong> folder.
            </li>
            <li>
                This sample web site's 
                <a href="SrcViewer.aspx?inspect=~/App_Browsers/CSSFriendlyAdapters.browser&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CSSFriendlyAdapters.browser">CSSFriendlyAdapters.browser</a>
                file tells the web site to always use the CSS friendly control adapters. You can, however,
                configure it to use the adapters for specific versions of specific browsers only. 
                If you do so be sure to specify how you want your controls rendered when the adapters
                aren't used.  Typically, this is done by adding a skin file to a theme folder.  This kit
                includes sample skin files like
                <a href="SrcViewer.aspx?inspect=~/App_Themes/Basic/Basic.skin&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Basic.skin">Basic.skin</a>.
            </li>
        </ul>

        <a id="SamplesLinkToSheets"></a>
        <h4>Link to Style Sheets</h4>
        <p>
            CSS rules are typically stored in style sheet files. If you used early versions of
            ASP.NET then you're probably used to adding style sheets to your pages manually by adding 
            &lt;link&gt; tags to the &lt;head&gt; section of the page. The latest version (2.0) of ASP.NET
            introduces <a href="http://msdn.microsoft.com/msdnmag/issues/05/11/CuttingEdge/default.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="introducing themes">themes</a>
            which are really just subfolders under the App_Themes folder where you put CSS files, skin files,
            and images.  Each page can specify which theme it uses.  <strong>ASP.NET 2.0 automatically
            links to the CSS files in that theme folder.</strong>
        </p>
        <p>
            If you use the theme system in ASP.NET 2.0 you simply drop your CSS files into the proper
            theme folder and that CSS file will be linked into any page that uses that theme.  That is
            why <a href="#SamplesCopyFiles" title="copy files instructions">the instructions above</a> say to put certain CSS files into
            a folder under App_Themes. It is so you could use that theme in your web site's pages and
            automatically have those pages link in those CSS files.
        </p>
        <p>
            For example, in this sample web site the file <strong>App_Themes\Basic\FormViewExample.css</strong> is automatically
            linked into all the example pages like
            <a href="SrcViewer.aspx?inspect=~/FormView.aspx&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="FormView.aspx">FormView.aspx</a>
            where the <strong>@Page</strong> page includes the attribute <strong>StyleSheetTheme=&quot;Basic&quot;</strong>. 
        </p>
        <p>
            You can use ASP.NET themes to link to your CSS files or create those links
            manually.  Either way, you need to create CSS rules in these style sheets to govern how your
            adapted Menus, TreeViews, etc., will look. These CSS rules will define the sorts of properties that
            you've traditionally defined as attributes in tags like &lt;asp:FormView&gt;.
        </p>

        <a id="SamplesMatchAttributes"></a>
        <h4>Match CSS to ASP.NET Attributes</h4>
        <p>
        Amongst the instructions listed above, the crux is putting the 
        <a href="SrcViewer.aspx?inspect=~/App_Browsers/CSSFriendlyAdapters.browser&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CSSFriendlyAdapters.browser">CSSFriendlyAdapters.browser</a>
        file into the <strong>App_Browsers</strong> folder. We're using this <em>browser</em> file to tell our web site to 
        adapt the rendition of some controls like this:
        </p>
        <wilco:SyntaxHighlighter id="css6" runat="server" Language="CSS" Mode="Source" Text='
    &lt;adapter controlType="System.Web.UI.WebControls.FormView"
           adapterType="CSSFriendly.FormViewAdapter" /&gt;' />
        
        <p>
        Now when the web site executes a page that contains an &lt;asp:FormView&gt;
        (whose fully qualified class name is System.Web.UI.WebControls.FormView) it will automatically:
        </p>
        <ul>
            <li>
                Create an instance of the
                <a href="SrcViewer.aspx?inspect=~/App_Code/Adapters/FormViewAdapter.cs&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CSSFriendly.FormViewAdapter">CSSFriendly.FormViewAdapter</a>
                class.  
            </li>
            <li>
                Call that adapter's various <strong>Render*</strong> methods whenever it needs to obtain the HTML that
                represents that particular FormView instance.
            </li>
        </ul>
        <p>
            You don't have to create your adapter instances or call their <strong>Render*</strong> methods explicitly.
            The ASP.NET framework does that for you automatically once you've added the <em>browser</em> file
            to your web site's <strong>App_Browsers</strong> folder.
        </p>
        <p>
            Remember, these sample adapters generally ignore style-related attributes. Imagine your
            page contains a FormView like this:
        </p>
        <wilco:SyntaxHighlighter id="css7" runat="server" Language="CSS" Mode="Source" Text='
    &lt;asp:FormView

        ID="FormView1"
        Runat="server"
        DataSourceID="ContactsDS"
        HeaderText="Author Details"
        AllowPaging="True" 

        backcolor="White" 
        borderstyle="None" 
        gridlines="None" 
        cellspacing="2"
        HeaderStyle-forecolor="#F7F6F3"
        HeaderStyle-backcolor="#5D7B9D"
        HeaderStyle-font-bold="True"
        RowStyle-forecolor="#333333"
        RowStyle-backcolor="White"
        PagerStyle-forecolor="#00FFFF"
        PagerStyle-horizontalalign="Center"
        PagerStyle-backcolor="#284775" /&gt;' />
        <p>
            In this example FormView tag, the first set of attributes relates to content;
            the second set relates to style.
        </p>
        <p>
            When the adapters are not used, this &lt;asp:FormView&gt; tag will create HTML with lots of
            embedded attributes to specify colors, etc. The HTML created by the FormView adapter, however,
            is utterly different. It doesn't include specifics about colors, etc. Instead, these properties 
            are defined in CSS files.
        </p>
        <p>
            In other words, when the CSS friendly FormView adapter is used, the specific FormView example
            shown above will render the same HTML as this simpler one:
        </p>
        <wilco:SyntaxHighlighter id="css8" runat="server" Language="CSS" Mode="Source" Text='
    &lt;asp:FormView
        ID="FormView1"
        Runat="server"
        DataSourceID="ContactsDS"
        HeaderText="Author Details"
        AllowPaging="True"
    /&gt;' />
        <p>
            Attributes like DataSourceID, HeaderText and AllowPaging tell the FormView what content to
            display.  They do not tell the FormView how to display that content (e.g., its color, font,
            borders, etc.).  The CSS friendly adapters pay attention to content-related attributes
            but ignore attributes related to styling.
        </p>
        <p>
            So, after you've <a href="#SamplesCopyFiles" title="copy files instructions">added the adapter files to your web site</a>,
            your job will be to create CSS rules that match the ASP.NET style-related attributes.
            Here is an example of how this was done for the <a href="FormView.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="FormView">FormView</a>
            example.
        </p>
        <table cellpadding="0" cellspacing="0">
            <thead>
                <tr>            
                    <th>
                        &lt;asp:FormView&gt; attribute
                    </th>
                    <th>
                        Matching CSS rule for the adapted FormView
                    </th>
                    <th>
                        Notes
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        backcolor="White" 
                    </td>
                    <td>
                        .AspNet-FormView { background-color: White; }
                    </td>
                    <td class="SpecialNote">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        borderstyle="None" 
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="SpecialNote">
                        No comparable CSS because the adapted FormView doesn't use tables so there
                        are no borders shown by default.
                    </td>
                </tr>
                <tr>
                    <td>
                        gridlines="None" 
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="SpecialNote">
                        No comparable CSS because the adapted FormView doesn't use tables so there
                        are no grid lines shown by default.
                    </td>
                </tr>
                <tr>
                    <td>
                        cellspacing="2"
                    </td>
                    <td>
                        .AspNet-FormView-Data { padding:7px 0 0 4px; }
                    </td>
                    <td class="SpecialNote">
                        These padding values result in white space in a manner similar to using ASP.NET's cellpadding
                        attribute, though the two aren't 100% equivalent.  The point of making your CSS rules isn't always to
                        match the adapted and unadapted control renditions pixel for pixel.  You are simply trying to create CSS
                        that produces an adapted rendition that is comparable and pleasing.
                    </td>
                </tr>
                <tr>
                    <td>
                        HeaderStyle-forecolor="#F7F6F3"
                    </td>
                    <td>
                        .AspNet-FormView-Header { color: #F7F6F3; }
                    </td>
                    <td class="SpecialNote">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        HeaderStyle-backcolor="#5D7B9D"
                    </td>
                    <td>
                        .AspNet-FormView-Header { background-color: #5D7B9D; }
                    </td>
                    <td class="SpecialNote">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        HeaderStyle-font-bold="True"
                    </td>
                    <td>
                        .AspNet-FormView-Header { font-weight: bold; }
                    </td>
                    <td class="SpecialNote">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        RowStyle-forecolor="#333333"
                    </td>
                    <td>
                        #SampleFormView .Sample-Phone { color: #333333; }
                    </td>
                    <td class="SpecialNote">
                        Sometimes you'll find it convenient to invent classes that you
                        then use explicitly within tags found inside your FormView's &lt;ItemTemplate&gt;.                            
                    </td>
                </tr>
                <tr>
                    <td>
                        RowStyle-backcolor="White"
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="SpecialNote">
                        No comparable CSS because the adapted FormView doesn't use tables so the background is inherited from
                        parent objects like the &lt;body&gt;, which already have a White background.
                    </td>
                </tr>
                <tr>
                    <td>
                        PagerStyle-forecolor="#00FFFF"
                    </td>
                    <td>
                        .AspNet-FormView-OtherPage { color: #00FFFF; }
                    </td>
                    <td class="SpecialNote">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        PagerStyle-horizontalalign="Center"
                    </td>
                    <td>
                        .AspNet-FormView-Pagination { text-align:center; }
                    </td>
                    <td class="SpecialNote">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        PagerStyle-backcolor="#284775"
                    </td>
                    <td>
                        .AspNet-FormView-Pagination { background-color: #284775; }
                    </td>
                    <td class="SpecialNote">
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>

        <p>
            Matching ASP.NET style-related attributes to comparable CSS attributes is the bulk of the
            work you'll need to do in order to use these CSS friendly adapters.  You'll put these rules
            into a file like 
            <a href="SrcViewer.aspx?inspect=~/App_Themes/Basic/FormViewExample.css&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="FormViewExample.css">FormViewExample.css</a>
            that you ensure is linked to your page (either manually via a &lt;link&gt; tag in the
            &lt;head&gt; of your page or by using an ASP.NET theme folder).  By the way, there is nothing
            particularly special about this file name: FormViewExample.css.  You can name this sort of style
            sheet file anything you prefer.
        </p>            
        <p>
            See the <a href="#SamplesCssSelectorClass" title="CssSelectorClass">CssSelectorClass</a> section of this document for
            more details regarding the leading class name (like PrettyFormView) found in many of the example
            CSS rules.  You'll almost certainly want to choose CssSelectorClass names that suit your
            web pages better.
        </p>

        <a id="SamplesTestYourWork"></a>
        <h4>Test Your Work</h4>
        <p>
            Once you get <a href="#SamplesMatchAttributes" title="Match CSS to ASP.NET Attributes">your CSS rules written</a> and 
            <a href="#SamplesCopyFiles" title="copy files instructions">put your adapter files, etc., in the right locations 
            in your web site</a>, you are ready to test the result. This is no more complicated than viewing your pages
            in various browsers: Internet Explorer (versions 5, 6 and/or 7), Firefox, Opera, Safari, etc.
        </p>
        <p>
            Remember that the adapters will be used based on whatever elements are in your
            <em>browser</em> file in the App_Browsers folder.  Only the browsers mentioned in that
            <em>browser</em> file will cause the adapters to be used.  All other browsers will render
            the controls using the traditional ASP.NET mechanisms.  
        </p>
        <p>
            The sample <em>browser</em> file included with this kit tells the framework to use the adapters
            by default.  If you modify that be sure to provide the appropriate ASP.NET style-related
            attributes (in the tag itself, on the page or in a skin file) so your page continues to look
            correct if it is visited by a browser for which the adapters are not used.
        </p>
        <p>
            A simple but powerful testing strategy is to temporarily delete the <em>browser</em> file(s)
            from the App_Browsers folder.  Then visit your web pages again.  This is what they will look
            like when visited by browsers that are not configured to use the CSS friendly adapters.
        </p>
    </div>
    
    <a id="SamplesAcessibility"></a>
    <h3>Accessibility</h3>
    <h4>Accesskey</h4>
    <p>
        Over the years, authors have suggested many ways to use the HTML accesskey attribute to make pages more
        accessible and easier to use. An accesskey is a keyboard shortcut. It can move the focus to a
        particular form element. Or, it can be the equivalent of clicking a button or link.
    </p>
    <p>
        When using Windows, you invoke an accesskey by holding down the Alt key and whatever letter or number
        is assigned to the accesskey attribute.  On a Macintosh you use the Ctrl key. Linux users use the Meta key.
        On Windows systems, you can sometimes resolve conflicts by using the Shift and Alt keys together with the
        accesskey character.
    </p>
    <p>
        Some authors advocate consistently using a 
        <a href="http://www.smackthemouse.com/20021031" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Article advocating the first-letter heuristic for accesskey">first letter</a>
        heuristic for accesskey values. This pattern can be implemented in   
        <a href="http://www.alistapart.com/articles/accesskeys/" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Tutorial on menus using the first-letter heuristic for accesskey">menus</a>
        or other complex clusters of hyperlinks.
    </p>
    <p>
        In theory, all this sounds great. In reality things
        <a href="http://www.mezzoblue.com/archives/2003/12/29/i_do_not_use/" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Article describing problems with using or overusing accesskey, especially for links">aren't so simple</a>.
        The biggest problem is that accesskey settings sometimes coincide and conflict with existing keyboard shortcuts
        used by the browser or parts of the operating system. Even within a single web page you need to take care not to
        use the same accesskey value for two different HTML elements. Menus can easily contain dozens of items. If the text
        for any two menu items starts with the same letter then you will have an accesskey conflict if you use the 
        <a href="http://www.smackthemouse.com/20021031" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Article advocating the first-letter heuristic for accesskey">first letter</a>
        pattern. For this reason, the sample Menu and TreeView adapters found in this kit do not try to set the accesskey
        attribute.
    </p>
    <p>
        There are particular dangers when using accesskey values for hyperlinks or form buttons. These take
        immediate actions: navigate to another page, submit a form, etc. Confusion can easily result if the
        user presses a key combination resulting in immediate and unexpected action like submitting an incomplete form.
    </p>
    <p>
        An accesskey on a textbox, radio button or checkbox typically causes no dramatic action to be taken. For example,
        the accesskey for a textbox merely moves the cursor to within it. Likewise, the accesskey for a
        radio button or checkbox simply toggles its state.
    </p>
    <p>
        This kit's membership control adapters programmatically set the accesskey values for the textboxes and checkboxes.
        The first letter within the associated label is emphasized to give a visual cue. So the rendered HTML looks like this:
    </p>
    <wilco:SyntaxHighlighter id="accesskeyLabel" runat="server" Language="ASPX" Mode="Source" Text='
        &lt;label for=&quot;someTextbox&quot;&gt;&lt;em&gt;M&lt;/em&gt;y label text:&lt;/label&gt;' />
    <p>
        Then, it is a simple matter of establishing a CSS rule that governs how an &lt;em&gt; within a &lt;label&gt;
        should be displayed.
    </p>
    <wilco:SyntaxHighlighter id="accesskeyRule" runat="server" Language="CSS" Mode="Source" Text='
        .PrettyCreateUserWizard .AspNet-CreateUserWizard label em
        {
            text-decoration: underline;
            font-style: normal;
        }' />
    <p>
        To see this in action, go to the 
        <a runat="server" href="~/Membership/CreateUserWizard.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CreateUserWizard sample">CreateUserWizard</a> 
        sample. Navigate with accesskeys. If using Windows, press Alt + e to set the focus to the textbox for the Email address. 
        (Prior to Internet Explorer 7 you must also hold down the Shift key to use the password textbox's accesskey.) 
    </p>
    <p>
        There are two ways to stop the automatic generation of accesskey values:
    </p>
    <ul>
        <li>Set the (new expando) attribute <strong>AutoAccessKey</strong> to false on the membership control tag in your markup.</li>
        <li>Modify the implementation of the <strong>AutoAccessKey</strong> property in the <strong>WebControlAdapterExtender</strong> class.</li>
    </ul>
    <h4>Scalable Styling</h4>
    <p>
        <a href="http://www.uiaccess.com/scaletext.html" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Discussion of the benefits of using scalable styling">Scalable styling</a>
        is a good way to make your web site more accessible.
    </p>
    <p>
        All of this kit's adapters produce markup that fundamentally scales well. The CSS that you use to style
        that markup, however, may or may not handle scaling. It requires some measure of experience and discipline
        to consistently use proportional CSS units like em or percent rather than pixels and other so-called fixed
        units.  The sample CSS included with this kit is intended to look great and act well if you increase the
        browser font size by one notch. Scaling more generally results in a reasonable presentation, though you
        may notice some anomalies.
    </p>
    <p>
        To see this in action, go to the  <a runat="server" href="~/Menu.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Menu sample">Menu</a> 
        sample. Increase your browser's font size. In Internet Explorer use <strong>View > Text Size > Larger</strong>. 
    </p>
    
    <a id="SamplesStandards"></a>
    <h3>Standards</h3>
    <p>
        The markup <em>rendered by this kit's sample adapters</em> is designed to work on pages adhering to the XHTML 1.1 Strict
        or earlier standards.
    </p>
    <p>
        The markup <em>found within this kit's pages</em> is also XHTML 1.1 Strict. You can test these or your own
        public pages with the
        <a href="http://validator.w3.org/" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="W3C markup validator">markup validator</a>
        provided by the W3C organization.
    </p>
    <p>
        <strong>Quick demo:</strong> Validate the <a runat="server" href="~/Menu.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Menu sample">Menu</a>
        sample page to confirm that the page conforms to the XHTML 1.1 Strict standard.
    </p>
    <p>
        Generally these sample adapters only need to carefully choose the tags and attributes they render
        in order to produce markup that conforms to the XHTML 1.1 Strict standard.  There are exceptions,
        however. Most notably, when the server-side attribute named <strong>Target</strong> is set to the value <strong>_blank</strong> the
        adapters <em>do not render a simple target attribute in the HTML</em>.  Rather, they use the <strong>onclick</strong> and
        <strong>onkeypress</strong> attributes. This achieves the same purpose as setting target to _blank in the HTML but is
        XHTML 1.1 Strict compliant.
     </p>
    
    <a id="SamplesTreeViewNotes"></a>
    <h3>Special TreeView Notes</h3>
    <h4>OnClientClickedCheckbox</h4>
    <p>
        When using the adapter, you may optionally include the new <strong>OnClientClickedCheckbox</strong> attribute on
        the &lt;asp:TreeView&gt; tag to provide a JavaScript statement to execute on the client whenever one
        of the tree's checkboxes is changed. This kit includes an 
        <a runat="server" href="~/walkthru/CascadingCheckboxTreeView.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Cascading Checkboxes sample">example</a>
        of using OnClientClickedCheckbox to allow checkmarks to cascade without a postback to the server.
    </p>
    <h4>Adapted Events</h4>
    <p>
        To handle the TreeView's <strong>SelectedNodeChanged</strong> or <strong>TreeNodeCheckChanged</strong> events you must use a new attribute
        called <strong>OnAdapted[eventname]</strong>.  Set that attribute to the name of a <strong>public</strong> (not protected)
        method of the page that contains the TreeView.
    </p>
    <p>
        No special attributes or handling is needed for the <strong>TreeNodePopulate</strong> event.
    </p>
    <wilco:SyntaxHighlighter id="SelectedNodeChangedSnippetCS" runat="server" Language="C#" Mode="Source" Text='
&lt;script runat=&quot;server&quot;&gt;
    public void OnClick(Object sender, EventArgs e)
    {
        // do something with foobar.SelectedNode
    }
&lt;/script&gt;' />
    <wilco:SyntaxHighlighter id="SelectedNodeChangedSnippetVB" runat="server" Language="VisualBasic" Mode="Source" Text='
&lt;script runat=&quot;server&quot;&gt;
    Public Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
        &#39; do something with foobar.SelectedNode
    End Sub
&lt;/script&gt;' />
    <wilco:SyntaxHighlighter id="SelectedNodeChangedSnippetASPX" runat="server" Language="ASPX" Mode="Source" Text='
&lt;asp:TreeView ID=&quot;foobar&quot; runat=&quot;server&quot; OnSelectedNodeChanged=&quot;OnClick&quot; OnAdaptedSelectedNodeChanged=&quot;OnClick&quot; /&gt;' />
    
    <a id="SamplesDisablingAdapters"></a>
    <h3>Disabling Adapters</h3>
    <p>
        If you explicitly add <strong>AdapterEnabled="false"</strong> to your server-side tag, these sample adapters will attempt to
        use the ASP.NET framework's native rendering for the control.  Beware: this is not supported and often does
        not work well.  Fundamentally, the framework does not support disabling adapters on a per control basis.
        The <strong>AdapterEnabled</strong> attribute is only intended to be used experimentally.
    </p>

    <a id="HiddenNuggets"></a>
    <h2>Hidden Nuggets</h2>

    <a id="HiddenNuggetsSyntaxHighlighter"></a>
    <h3>Syntax Highlighter</h3>
    <p>
        This sample web site includes a source code viewer that employs various text colors to highlight
        language keywords, etc. The logic behind how to colorize and display the source code text is 
        entirely encapsulated in a custom control generously
        <a href="http://www.wilcob.com/Wilco/Toolbox/SyntaxHighlighter.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Wilco Bauwer's syntax highlighter">contributed</a>
        to the ASP.NET community (and used herein with permission) by Wilco Bauwer.
    </p>

    <a id="HiddenNuggetsSourceCodeViewer"></a>
    <h3>Source Code Viewer</h3>
    <p>
        The very first SDK for ASP.NET (v1.0) came with a source code viewer that various authors have
        <a href="http://aspalliance.com/55" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="ASP Alliance">integrated</a> into their own web sites. Rather than recycling
        this somewhat aging technology, a new source code viewer was developed for this site by combining
        Wilco Bauwer's syntax highlighter with a TreeView control.
    </p>
    <p>
        With just a few simple 
        <a href="SrcViewer.aspx?inspect=~/SrcViewer.aspx&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="source viewer tags">tags</a>
        and a few lines of
        <a href="SrcViewer.aspx?inspect=~/SrcViewer.aspx.cs&amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="source viewer code">code</a>
        we end up with a powerful and effective source
        code viewer.  You are, of course, welcome to use this approach in your own web sites.
    </p>
    
    <a id="Conclusion"></a>
    <h2>Conclusion</h2>
    <p>
        Copy, modify and improve the markup, CSS and code demonstrated and documented here.  Or, invent entirely
        new adapters for a completely different set of ASP.NET controls.
    </p>
    <p>
        Control adapters let you take charge of your web site's markup and design in a totally new way. Their
        potential to shape and change the way we look at web site architecture is enormous and completely untapped.
        Truly, this is a frontier, an area where clever web designers and developers can push the boundaries of
        what we thought possible.
    </p>
    <p>
        We're looking forward to hearing from you.  Please post any comments, questions, or bug reports to the
        CSS Adapters Forum at 
        <a href="http://forums.asp.net/1018/ShowForum.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="ASP.NET 2.0 CSS Friendly Control Adapters forum">http://forums.asp.net/1018/ShowForum.aspx</a>.
    </p>
  </div>
</asp:Content>
