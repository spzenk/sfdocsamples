<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="WalkThrough.aspx.cs" Inherits="Walkthrough" Title="The Walkthrough: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" StylesheetTheme="Enhanced" Theme="Enhanced" %>

<%@ Register TagPrefix="wilco" Namespace="Wilco.Web.SyntaxHighlighting" Assembly="Wilco.SyntaxHighlighter" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="Server">
    <div id="WalkThrough">
        <h1>ASP.NET 2.0 CSS Friendly Control Adapters: The Walkthrough</h1>
        
        <a id="Summary"></a>
        <h2>Summary</h2>
        <p>
            This is a step-by-step tutorial of how to install and use this sample kit. Please
            refer to this kit's <a runat="server" href="~/WhitePaper.aspx" title="white paper">white paper</a> for
            more information.
        </p>
        <a id="Introduction"></a>
        <h2>Introduction</h2>
        <p>
            Relax. This tutorial is going to explain everything. You'll soon discover the power
            of ASP.NET 2.0 control adapters. In particular, we'll look at how adapters can help
            you create an ASP.NET 2.0 web site that uses more CSS and renders fewer (and better)
            &lt;table&gt; tags.
        </p>
        <p>
            This tutorial moves you through the following tasks, building upon each in turn.
        </p>
        <ul>
            <li><a title="Download and install" href="#DownloadAndInstall">Download and install this sample kit.</a></li>
            <li><a title="Run a local copy" href="#RunLocally">Run a local copy of the kit.</a></li>
            <li><a title="Explore the files" href="#ExploreKitFiles">Explore the files in the kit.</a></li>
            <li><a title="Experiment with the CSS" href="#ExperimentWithCss">Experiment with changing the kit's CSS.</a></li>
            <li><a title="Build a simple page that can use the kit's adapters" href="#BuildSkeletonPage">Build a simple page that can use the kit's adapters.</a></li>
            <li><a title="Make a pure CSS menu" href="#SimpleMenu">Make a &quot;pure CSS menu&quot; with an adapter for &lt;asp:Menu&gt;.</a></li>
            <li><a title="Add a simple tree view" href="#SimpleTreeView">Add a simple adapted &lt;asp:TreeView&gt; to a page.</a></li>
            <li><a title="Populate-on-demain tree view" href="#PopulateOnDemandTreeView">Populate-on-demand an adapted &lt;asp:TreeView&gt;.</a></li>
            <li><a title="Checkboxes in a tree view" href="#CheckboxesTreeView">Add checkboxes to an adapted &lt;asp:TreeView&gt;.</a></li>
            <li><a title="Cascading Checkboxes in a tree view" href="#CascadingCheckboxTreeView">Cascade checkmarks in an adapted &lt;asp:TreeView&gt;.</a></li>
        </ul>
        <!-- Download And Install -->
        <a id="DownloadAndInstall"></a>
        <h2>Download and Install this Sample Kit</h2>
        <p>
            This sample kit can be run on any computer where
            <a href="http://msdn.microsoft.com/vstudio/express/vwd/download/" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Visual Web Developer">Visual Web Developer</a>
            or
            <a href="http://msdn.microsoft.com/vstudio/" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Visual Studio 2005">Visual Studio 2005</a> 
            is installed.
        </p>
        <p>
            Using any web browser, visit <a href="http://www.asp.net/cssadapters/" title="download source">http://www.asp.net/cssadapters/</a>
            and click the <strong>download source</strong> button.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/KitLandingPage.gif" alt="The Kit's Home Page" />
        </p>
        <p>
            Click the <strong>Open</strong> button to download and run this sample kit's
            <a href="http://msdn2.microsoft.com/en-us/library/ms165096.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Get the VSI file">VSI file</a>.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/FileDownloadDialog.gif" alt="The File Download dialog" />
        </p>
        <p>
            The <strong>Visual Studio Content Installer</strong> will add several new web site templates
            to Visual Studio. You'll learn more about these templates when you 
            <a href="#RunLocally">build a web site that can be run locally.</a>
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VSContentInstaller.gif" alt="The Visual Studio Content Installer" />
            <img runat="server" src="~/images/WalkThru/VSFinishContentInstallation.gif" alt="Visual Studio Content Installer - click Finish" />
        </p>
        <p>
            If you've installed this kit previously, you'll be asked if the old version can
            be overwritten.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VSOverwriteExistingFile.gif" alt="Visual Studio Content Installer - it's okay to overwrite the existing files" />
        </p>
        <p>
            Click the <strong>Close</strong> button when the VS Content Installation completes.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VSContentInstallationComplete.gif" alt="Visual Studio Content Installer - Complete"  />
        </p>
        <!-- Create New Website -->
        <a id="RunLocally"></a>
        <h2>Run a Local Copy of the Kit</h2>
        <p>
            Create a new web site within Visual Studio using the <strong>File &gt; New Web Site ...</strong>
            menu command.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VWDNewWebSite.gif" alt="Create a new website" />
        </p>
        <p>
            The <strong>New Web Site</strong> dialog provides a variety of templates to get you started.
        </p>
        <p>
            After completing this tutorial you'll be ready to create new web sites that use these
            CSS Friendly control adapters.  The template named <strong>ASP.NET CSS Friendly Web Site</strong>
            is ideal for that task.  It contains just the adapter files plus a small handful of simple
            sample pages that you can clone or modify. 
        </p>
        <p>
            First, though, it's important to learn about adapters in general and the
            CSS Friendly sample adapters in particular. So, you will want to select the template named
            <strong>Tutorial on ASP.NET CSS Friendly Control Adapters</strong>. It will create a
            somewhat more complex web site intended to help you learn about adapters. Remember that
            you'll want to use the slimmer <strong>ASP.NET CSS Friendly Web Site</strong> web site template
            when you are ready to do your own development.  The tutorial template is provided simply to
            speed the learning process.
        </p>
        <p>
            Specify a <strong>Location</strong> and <strong>Language</strong> for the site and then click
            <strong>OK</strong>.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdNewWebSiteCssAdapterTemplate.gif" alt="Create the new site using the CSS Adapter Template" />
        </p>
        <p>
            This will create a copy of this sample kit's web site on your local computer. In
            a moment you'll run this local web site using Visual Studio's built-in Cassini web
            server. First, though, you should take a quick look at the notes found in the
            <strong>readme.txt</strong> file that appears when you first create this local web site.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/KitReadmeFile.gif" alt="Be sure to read the readme.txt file" />
        </p>
        <p>
            The <strong>Solution Explorer</strong> lists the files created. To see a detailed
            discussion of the files and folders created, please see
            <a href="#ExploreKitFiles" title="Explore the Files" >Explore the Files in the Kit</a>. The rest of this section shows
            you how to view the kit's pages in a browser and highlights some interesting features.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdSolutionExplorer.gif" alt="Files created using the CSS Adapter Template" />
        </p>
        <p>
            Click the <strong>Start Debugging</strong> button on Visual Studio's toolbar or
            use the menu command <strong>Debug &gt; Start Debugging</strong>.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdStartDebugging.gif" alt="Run the web site"  />
        </p>
        <p>
            In order to run these web pages locally on your PC you need a web server. Visual
            Studio uses a light-weight web server called Cassini. It will be running as a result
            of your having told Visual Studio to start running your local version of this kit.
            The Cassini icon should be visible in your Windows task tray. And, when the browser
            starts, you'll see the port number used by Cassini displayed in the browser's address
            bar.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/Cassini.gif" alt="Using Cassini to serve the pages" />
        </p>
        <p>
            Now let's take a look at some of the files in the kit. Sample pages for each of
            the adapted controls are listed in the menu at the top of the page, under <strong>Examples</strong>.
            This is your first chance to use an adapted &lt;asp:Menu&gt; control.
            It uses nested &lt;ul&gt; rather than &lt;table&gt; tags.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/SamplePagesNav.gif" alt="Main navigation menu for the kit" />
        </p>
        <p>
            Now go to the <a runat="server" href="~/Menu.aspx" title="Menu example page">Menu example 
            page</a>. It will help us see more clearly how page that use adapters differ from those that don't.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/SamplePagesNavGoToMenu.gif" alt="Navigating to the Menu sample" />
        </p>
        <p>
            All the sample pages in the kit are organized alike. Each has a working example
            of a particular control whose resultant HTML is shown in a pair of &quot;snippets&quot; at
            the bottom of the page. The snippet on the left shows the HTML sent to the browser
            by the control adapter. The snippet on the right shows the unadapted HTML that is
            produced by the ASP.NET 2.0 framework. Radio buttons that appear on the left side
            of each sample page let you see what happens if you turn off the sample adapter
            or swap in a new set of CSS rules (a different theme).
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/KitSamplePageLayout.gif" alt="Layout of the kit's sample pages" />
        </p>
        <p>
            Each sample page can be run with or without the adapters by setting the radio button
            labeled <strong>Use Adapters?</strong>.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/KitSamplePageUseAdaptersToggle.gif" alt="Enable/disable adapters" />
        </p>
        <p>
            The &quot;acid test&quot; for CSS is altering the appearance of that web site merely by swapping
            style sheets and images without touching the HTML markup. You can test these sample
            pages by switching between themes. 
        </p>
        <p>
            Use the Theme Chooser to switch style sheets. Two themes are provided: Basic and Enhanced.
            There is one set of style sheets for the Basic theme. There's another set for the Enhanced theme.
            They live in the folders below App_Themes. 
        </p>
        <p>
            Set the Theme Chooser to None to decouple the page from all its style sheets. 
            Ideally, the markup should look simple. Try this with and without the adapters enabled. 
        </p>
        <p>
            The screenshots below show the sample &lt;asp:Menu&gt;
            control styled with the Basic and Enhanced themes. The last screenshot shows the
            page decoupled from its style sheets.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/KitSamplePageUseThemeChooser.gif" alt="The Theme Chooser" />
        </p>
        <p>
            To see how each sample is implemented click the <strong>view source code</strong> button.
            This will show a simple but effective code viewer, included with the kit. It not only
            helps you examine the code for each sample but can be studied as a sample itself.  After all,
            the code viewer page also uses an adapted &lt;asp:TreeView&gt; control.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/KitSamplePageSourceCodeLayout.gif" alt="Layout of the source code viewer page" />
        </p>
        <!-- Solution Explorer -->
        <a id="ExploreKitFiles"></a>
        <h2>Explore the Files in the Kit</h2>
        <p>
            There are three kinds of server-side ASP.NET 2.0 code used by this sample web site:
        </p>
        <ul>
            <li>Code behind files with logic for individual pages. The found in the same folder
                as the page (ASPX file). For example, the 
                <a runat="server" href="~/Menu.aspx" title="menu sample page">menu sample page</a> for this kit is 
                <a runat="server" href="~/SrcViewer.aspx?inspect=~/Menu.aspx&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Menu.aspx">Menu.aspx</a>. 
                It is found in the root folder for this web site. That same folder contains that
                page's code behind file (Menu.aspx.cs or Menu.aspx.vb). Other pages may be
                found in the Membership and WalkThru folders. </li>
            <li>Code that helps these samples run but probably won't be useful in other web sites.
                For example, these samples use a 
                <a runat="server" href="~/SrcViewer.aspx?inspect=~/App_Code/SiteSpecific/FakeMembershipProvider.cs&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="fake membership provider">fake 
                membership provider</a> in lieu of a real membership system that would typically use a database. This sort of logic is stored in files
                in the App_Code\SiteSpecific folder. </li>
            <li>Code for the sample CSS Friendly adapters. This is code that you may want to use
                in your web sites, too. For example, the adapter for the TreeView control is TreeViewAdapter.cs/TreeViewAdapter.vb. 
                These files are kept separate from the other parts of the web site so
                you can find them easily. Look for the files in the App_Code\Adapters folder. </li>
        </ul>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdSolutionExplorerApp_CodeFolderAndFiles.gif" alt="Files in the App_Code folder" />
        </p>
        <p>
            ASP.NET 2.0 introduces the notion of Themes. These are merely subfolders below the
            App_Themes folder. These theme folders are where you put the style sheets and images
            that are unique to one particular &quot;look&quot; for your pages. An ASP.NET page indicates its
            theme, typically, in its @Page directive.  This tells the ASP.NET framework which theme
            folder should be used.  When the page is rendered to the browser its &lt;head&gt;
            automatically includes &lt;link&gt; tags for each CSS file found in the theme folder
            used by that page. </p>
        <p>
            Each of the adapted controls in the kit has its own style sheet. For example, the &lt;asp:GridView&gt; control
            has a style sheet named GridViewSample.css. The kit contains two themes: Basic and Enhanced. Therefore, 
            the kit has a GridViewSample.css file in the 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/App_Themes/Basic/GridViewExample.css&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="GridViewExample.css in the Basic folder">Basic folder</a>  
            and another in the 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/App_Themes/Enhanced/GridViewExample.css&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="GridViewExample.css in the Enhanced folder">Enhanced folder</a>.            
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdSolutionExplorerApp_ThemesFiles.gif" alt="Folders and files in the App_Themes folders" />
        </p>
        <p>
            The bin folder for this sample kit includes a copy of 
            <a href="http://www.wilcob.com/Wilco/Toolbox/SyntaxHighlighter.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Wilco Bauer's Syntax Highlighter">Wilco Bauer's handy utility</a>
            for displaying highlighted markup and code on ASP.NET pages. This has nothing to do with the
            adapters.  It is used whenever markup or code is described in the documentation in this kit.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdSolutionExplorerBinFolder.gif" alt="The files in the bin folder" />
        </p>
        <p>
            Some of the pages in this kit use sample data stored in XML files.  These kit-specific data
            files are stored in the App_Data folder. You probably won't need to use these files in your
            web sites. For example, 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/App_Data/Contacts.xml&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Contacts.xml">Contacts.xml</a>
            is used as the data source for the three sample pages highlighted below.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdSolutionExplorerContactsXmlFileUsage.gif" alt="The Contacts.xml file is the data source for three sample pages" />
        </p>
        <p>
            Previously, you saw that style sheets and images that constitute the &quot;look&quot; for your pages
            should be put in a particular theme subfolder below App_Themes.  In addition, there are
            style sheets that are used by the adapters without regard to the current theme.  These
            special style sheets contain rules that govern the behavior of the adapted controls, not
            their appearance.  For example, when implementing a 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/CSS/Menu.css&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Menu.css">pure CSS</a> 
            menu, there are some rules that govern the color, font, etc. for the menu items but there are other 
            rules that govern how the menu fundamentally works, how its submenus appear and disappear depending 
            on whether or not you hover your cursor over parts of the menu, etc. These are the sort of rules that 
            you find in the style sheets in the CSS folder and in its subfolder that contains browser-specific
            behavioral rules.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdSolutionExplorerCssFolder.gif" alt="The CSS folder" title="The CSS folder" />
            <img runat="server" src="~/images/WalkThru/VwdSolutionExplorerCssBrowserSpecificFolder.gif" alt="The browser specific CSS files" title="The browser specific CSS files" />
        </p>
        <a id="DotBrowser"></a>
        <p>
            Your web site can be configured to always use these control adapters, regardless of what kind 
            of browser is used to visit your pages.  Or, you can fine tune your configuration so the 
            adapters are used only with specific versions of specific browsers. Either way, if you want 
            to use control adapters in your site then it must include a folder in its root called 
            App_Browsers.  Any file with the extension .browser that is in the App_Browsers folder is used 
            by the ASP.NET framework to specify how your pages should respond to various browsers.
        </p>
        <p>
            This sample adapter kit comes with a .browser file called CSSFriendlyAdapters.browser
            that lives in the App_Browsers folder. It configures the web site to use the CSS
            friendly adapters by default. You can, of course, modify this by changing the refID
            value to IE6to9, Gecko, Opera8to9, etc.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdSolutionExplorerDotBrowserFile.gif" alt="The kit's .browser file" />
        </p>
        <p>
            A few of these sample adapters require a small amount of JavaScript.  The kit puts this
            client-side logic into JS files in a folder called JavaScript. For example, 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/JavaScript/TreeViewAdapter.js&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="TreeViewAdapter.js">TreeViewAdapter.js</a>. 
            However, you can customize this folder location by changing the CSSFriendly-JavaScript-Path 
            key in the appSettings section of the site's 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/web.config&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="web.config">web.config</a> 
            file.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdSolutionExplorerJavaScriptFolder.gif" alt="The files in the JavaScript folder" />
        </p>
        <p>
            A subset of this kit is devoted to demonstrating how to adapt the various membership
            controls in the ASP.NET 2.0 framework.  The pages used as examples for these adapted
            controls are in the Membership folder. For example, the 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/Membership/login.aspx&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="login.aspx">login</a> 
            page.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/VwdSolutionExplorerMembershipFolderAndFiles.gif" alt="The sample pages in the Membership folder" />
        </p>
        <!-- Modify Menu Sample -->
        <a id="ExperimentWithCss"></a>
        <h2>Experiment with Changing the Kit's CSS</h2>
        <p>
            At this point you've installed and run these samples locally.  You've looked over
            the organization of the web site's files. Ultimately though, you'll want to clone and
            modify these files to create your own designs in your own web sites. Let's start by
            making a very small modification to these sample pages to gain confidence that we
            can successfully customize and change things.  This will be our first step towards
            bigger, more challenging tasks like adding these sample adapters to entirely new web sites.
        </p>
        <p>
            We're going to modify the sample menu to use a different shade of blue for the background
            items being hovered over.
        </p>
        <p>
            In Visual Studio, open the file 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/App_Themes/Basic/MenuExample.css&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="App_Themes\Basic\MenuExample.css">App_Themes\Basic\MenuExample.css</a>. 
            Find this rule:
        </p>
        <wilco:SyntaxHighlighter id="simplemenu1" runat="server" Language="CSS" Mode="Source" Text='
.PrettyMenu ul.AspNet-Menu li:hover, 
.PrettyMenu ul.AspNet-Menu li.AspNet-Menu-Hover
{
    background:#4682B3;
}' />
        <p>
            Change the color value to something different, like #27408B.  Save the style sheet and refresh
            the <a runat="server" href="~/Menu.aspx" title="menu sample page">menu sample page</a>.  The new color should appear
            when you hover over the sample menus. </p>
        <p>
            <img runat="server" src="~/images/WalkThru/ExperimentWithCss.gif" alt="The menu sample with the original and new background hover color" />
        </p>
        <p> 
            For parity in situations when the adapters are not used,
            you should also modify the skin file used for the Basic theme.  Open the file 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/App_Themes/Basic/Basic.skin&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="App_Themes\Basic\Basic.skin">App_Themes\Basic\Basic.skin</a>. 
            Locate the two DynamicHoverStyle tags whose BackColor 
            attribute is #4682B3.  Change this to your new color (like #27408B).
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/DynamicHoverStyle.gif" alt="The Basic.skin file" />
        </p>
        <!-- Simple Page (skeleton of stripped down page ready for an adapted control)-->
        <a id="BuildSkeletonPage"></a>
        <h2>Build a Simple Page that Can Use the Kit's Adapters</h2>
        <p>
            The code block below is the skeleton of the page that is ready to use the sample
            adapters included in this kit. The @Page directive declares the
            Language used by the page but does not mention theme, master page,
            code behind file, inherited class, etc. Our intent is to examine a simple page
            that uses these sample adapters. The pages in this kit that you visit via the Examples
            menu, by contrast, use master pages and other complexities that can make it more
            difficult to see the bare skeleton of the page that is really needed to accommodate
            these sample adapters.  That is what we will look at now.
        </p>
        <p>
            Within the &lt;head&gt; the page links in several style sheets. The first 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/CSS/Import.css&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Import.css">imports</a>             
            the theme-independent style sheets that dictate the behavioral CSS rules for each sample
            control adapter (e.g., 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/CSS/Menu.css&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Menu.css">Menu.css</a>). 
            You will rarely (if ever) need to change the rules in these styles sheets.
            Generally, you link them in and forget about them.
        </p>
        <p>
            The page also conditionally links to a style sheet needed by previous versions of Internet Explorer 
            (<a runat="server" href="~/SrcViewer.aspx?inspect=~/CSS/BrowserSpecific/IEMenu6.css&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="IEMenu6.css">IEMenu6.css</a>).
        </p>
        <p>
            The rest of the page is a standard, empty ASP.NET page.  You would normally start
            adding your markup within the server-side form (or its inner &lt;div&gt;).
        </p>
    
    <wilco:SyntaxHighlighter id="skeletonPageCode" runat="server" Language="ASPX" Mode="Source" Text='
    &lt;%@ Page Language="C# or VB" %&gt;    
    &lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.1//EN&quot; &quot;http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd&quot;&gt;
    &lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;
    &lt;head runat="server"&gt;
        &lt;link runat="server" rel="stylesheet" href="~/CSS/Import.css" type="text/css" id="AdaptersInvariantImportCSS" /&gt;
        &lt;!--[if lt IE 7]&gt;
            &lt;link runat="server" rel="stylesheet" href="~/CSS/BrowserSpecific/IEMenu6.css" type="text/css" id="IEMenu6CSS" /&gt;
        &lt;![endif]--&gt; 
    &lt;/head&gt;
    &lt;body&gt;
        &lt;form id="form1" runat="server"&gt;
            &lt;!-- adapted control(s) here--&gt;
        &lt;/form&gt;
    &lt;/body&gt;
    &lt;/html&gt;' />
        <p>
            The files the kit's <strong>WalkThru</strong> folder use this page structure.
        </p>
        <!-- Simple Menu page (shows postback) -->
        <a id="SimpleMenu"></a>
        <h2>Make a &quot;Pure CSS Menu&quot; with an Adapter for &lt;asp:Menu&gt;</h2>
        <h3>
            <a href="SimpleMenu.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="run the sample"><img runat="server" src="~/images/WalkThru/RunIt.gif" class="RunIt" alt="click to run the example" title="Run the 'simple menu' example in a new browser." /></a>SimpleMenu.aspx</h3>
        <p>
            Menus on web sites tend to have one of two goals:
        </p>
        <ul>
            <li>Navigate to various pages in the site.</li>
            <li>Postback to the current page indicating that a particular menu item was chosen.</li>
        </ul> 
        <p>
            Earlier versions of this sample kit included an adapter for the &lt;asp:Menu&gt;
            control that supported the first goal: 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/Menu.aspx&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Menu.aspx">navigation to an explicit URL</a>. 
            This is, of course, still supported
            in the current version of the kit.  Now, though, the adapted &lt;asp:Menu&gt; 
            supports the second goal, too.  That is, the sample adapter can be used to create 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/WalkThru/SimpleMenu.aspx&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="SimpleMenu.aspx">menus that postback</a>. 
            A simple example of this is found in WalkThru\SimpleMenu.aspx.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/SimpleMenu1.gif" alt="The SimpleMenu.aspx page" />
        </p>
        <p>
            Here is the &lt;asp:Menu&gt; markup used in 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/WalkThru/SimpleMenu.aspx&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="SimpleMenu.aspx">SimpleMenu.aspx</a>. 
            The menu items do not set the NavigateUrl property so the adapter assumes that the page should 
            postback. The &quot;Movie&quot; node is marked as being unselectable, which means that it does not cause a 
            postback or any navigation. Finally, notice that a server-side event handler is used to process 
            click events. With few exceptions, server-side events are handled by the framework regardless of 
            whether or not an adapter is being used. In this example, the server-side event handler updates a 
            label to demonstrate that the selected menu item is known.  Presumably, in your own web sites, such 
            a handler would do much more inventive and useful things!
        </p>
        <wilco:SyntaxHighlighter id="simplemenu2" runat="server" Language="ASPX" Mode="Source" Text='
&lt;asp:Menu ID="EntertainmentMenu" runat="server" Orientation="Horizontal" onmenuitemclick="OnClick" CssSelectorClass="SimpleEntertainmentMenu"&gt;
    &lt;Items&gt;
        &lt;asp:MenuItem Text="Music"&gt;
            &lt;asp:MenuItem Text="Classical" /&gt;
            &lt;asp:MenuItem Text="Rock"&gt;
                &lt;asp:MenuItem Text="Electric" /&gt;
                &lt;asp:MenuItem Text="Acoustical" /&gt;
            &lt;/asp:MenuItem&gt;
            &lt;asp:MenuItem Text="Jazz" /&gt;
        &lt;/asp:MenuItem&gt;
        &lt;asp:MenuItem Text="Movies" Selectable="false"&gt;
            &lt;asp:MenuItem Text="Action" /&gt;
            &lt;asp:MenuItem Text="Drama" /&gt;
            &lt;asp:MenuItem Text="Musical" /&gt;
        &lt;/asp:MenuItem&gt;
    &lt;/Items&gt;
&lt;/asp:Menu&gt;' />
        <p>
            It's possible visually distinguish the selected menu item, its parents or children using an adapted 
            &lt;asp:Menu&gt; control. The adapter automatically adds a class called .AspNet-Menu-Selected on the anchor tag
            within the &lt;li&gt; tag that is rendered for the selected menu item.  The anchor in the
            &lt;li&gt; tag that is &quot;above&quot; this selected menu item in the hierarchy is similarly flagged;
            this time with the .AspNet-Menu-ParentSelected class. Likewise, the anchors in the submenus of the
            selected menu item are classed as .AspNet-Menu-ChildSelected. With these classes in mind
            you can use 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/WalkThru/SimpleMenu.css&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="SimpleMenu.css">CSS</a> 
            to visually distinguish these parts of the menu.            
        </p>
        <wilco:SyntaxHighlighter id="selectedMenuClasses" runat="server" Language="CSS" Mode="Source" Text='
 .SimpleEntertainmentMenu .AspNet-Menu-Selected
{
    border: solid 1px #00ff00 !important;
}

.SimpleEntertainmentMenu .AspNet-Menu-ChildSelected
{
    border: solid 1px #ff0000 !important;
}

.SimpleEntertainmentMenu .AspNet-Menu-ParentSelected
{
    border: solid 1px #0000ff !important;
}' />        
        <p>
            These CSS rules produce the visual cues shown in the menu below.  You may wish to use other
            CSS properties, instead, like background color, font family, etc. Changing the border color
            is merely an easy way to demonstrate the concept here.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/SimpleMenu2.gif" alt="The SimpleMenu.aspx page." />
        </p>
        <!-- Simple TreeView page (shows postback)-->
        <a id="SimpleTreeView"></a>
        <h2>Add a Simple Adapted &lt;asp:TreeView&gt; to a Page</h2>
        <h3>
            <a runat="server" href="SimpleTreeView.aspx" title="run the example" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;"><img runat="server" src="~/images/WalkThru/RunIt.gif" class="RunIt" alt="run the example" title="Run the 'simple tree view' example in a new browser." /></a>SimpleTreeView.aspx</h3>
        <p>
            The kit's WalkThru folder includes a 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/WalkThru/SimpleTreeView.aspx&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="SimpleTreeView.aspx">SimpleTreeView.aspx</a> page. 
            It is very similar to the 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/WalkThru/SimpleMenu.aspx&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="SimpleMenu.aspx">SimpleMenu.aspx</a> 
            page but presents the data as a tree, instead of a menu.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/SimpleTreeView1.gif" alt="The SimpleTreeView.aspx page showing postback" />
        </p>
        <p>
            Like the menu adapter, the sample adapter for the TreeView control uses 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/WalkThru/SimpleTreeView.css&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="SimpleTreeView.css">CSS</a> 
            classes to distinguish the selected node, its parents and children.  These classes can
            be optionally defined in your style sheets to provide visual cues that quickly bring the
            user's eye to the most important portions of the tree.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/SimpleTreeView2.gif" alt="The SimpleTreeView.aspx page showing selected node styling" />
        </p>
        <!-- Simple TreeView page (uses populate on demand)-->
        <a id="PopulateOnDemandTreeView"></a>
        <h2>Populate-on-demand an Adapted &lt;asp:TreeView&gt;</h2>
        <h3>
            <a runat="server" href="PopulateOnDemandTreeView.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="run the example"><img runat="server" src="~/images/WalkThru/RunIt.gif" class="RunIt" alt="run the example" title="Run the 'populate-on-demain tree view' example in a new browser." /></a>PopulateOnDemandTreeView.aspx</h3>
        <p>
            A TreeView is sometimes used to display vast hierarchies of information. For example,
            a large company might show its employee directory as a tree whose first branches
            indicate the continent, country and region where the employee works. Rather than building
            the page with a tree immediately capable of showing all the employees you might wish to
            initially show just the continents (the first set of tree nodes).  If one of these nodes
            is expanded, the page would postback to the server to fill in the countries where the
            company has offices.  Likewise, expanding the node in the tree for a country would postback
            to get the nodes for the regions within that country, and so on.
        </p>
        <p>
            The TreeView in the ASP.NET 2.0 framework includes this sort of populate-on-demand feature.
            The sample CSS Friendly adapter for the TreeView now provides this functionality, too.
            The WalkThru folder includes a 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/WalkThru/PopulateOnDemandTreeView.aspx&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="PopulateOnDemandTreeView.aspx">PopulateOnDemandTreeView.aspx</a> 
            page to get you started.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/SimplePopOnDemandTreeView1.gif" alt="The PopulateOnDemandTreeView.aspx page showing populate-on-demand" />
        </p>
        <!-- Simple TreeView page (uses checkboxes)-->
        <a id="CheckboxesTreeView"></a>
        <h2>Add Checkboxes to an Adapted &lt;asp:TreeView&gt;</h2>
        <h3>
            <a runat="server" href="CheckboxTreeView.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="run the example"><img runat="server" src="~/images/WalkThru/RunIt.gif" class="RunIt" alt="run the example" title="Run the 'checkbox tree view' example in a new browser." /></a>CheckboxTreeView.aspx</h3>
        <p>
            Not only can a TreeView help you present complex hierarchical data, it can offer your
            visitors a way to choose one or more of those nodes.  This is done by adding a checkbox
            next to particular nodes in the tree.  The ASP.NET 2.0 framework includes this ability
            for the unadapted TreeView control; the sample CSS Friendly TreeView adapter offers this
            same ability, now, too. The 
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/WalkThru/CheckboxTreeView.aspx&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CheckboxTreeView.aspx">CheckboxTreeView.aspx</a> 
            sample in the WalkThru folder shows you how this is done.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/SimpleCBTreeView1.gif" alt="The CheckboxTreeView.aspx page" />
        </p>
        <!-- Simple TreeView page (uses cascading checkboxes)-->
        <a id="CascadingCheckboxTreeView"></a>
        <h2>Cascade Checkmarks in an Adapted &lt;asp:TreeView&gt;</h2>
        <h3>
            <a runat="server" href="CascadingCheckboxTreeView.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="run the example"><img runat="server" src="~/images/WalkThru/RunIt.gif" class="RunIt" alt="run the example" title="Run the 'cascading checkbox tree view' example in a new browser." /></a>CascadingCheckboxTreeView.aspx</h3>
        <p>
            A checkbox accompanying an expandable tree node suggests a quick way to set the checkmarks on
            all the child nodes at once. A parent node's checkmark can appear to <em>cascade</em> to its children.
            Clever people have
            <a href="http://forums.asp.net/thread/1397908.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="Forum thread discussing cascading heuristics using JavaScript">published</a>
            the JavaScript needed to accomplish this cascade. Still, the adapted TreeView needs to somehow know
            to use that JavaScript.
        </p>
        <p>
            For this, the TreeView adapter includes a new (expando) property called OnClientClickedCheckbox.  Add it to
            your &lt;asp:TreeView&gt; tag and set its value as a string of JavaScript to be executed in the browser
            (on the client) when a checkbox in the tree is checked or unchecked.
        </p>
        <p>
            The
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/WalkThru/CascadingCheckboxTreeView.aspx&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CascadingCheckboxTreeView.aspx">CascadingCheckboxTreeView.aspx</a> 
            and its accompanying
            <a runat="server" href="~/SrcViewer.aspx?inspect=~/WalkThru/CascadeCheckmarks.js&amp;amp;notree=true" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;" title="CascadingCheckboxTreeView.aspx">CascadeCheckmarks.js</a>
            demonstrate this idea.
        </p>
        <p>
            <img runat="server" src="~/images/WalkThru/SimpleCascadeCBTreeView1.gif" alt="The CascadingCheckboxTreeView.aspx page" />
        </p>
    </div>
</asp:Content>
