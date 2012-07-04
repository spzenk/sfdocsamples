<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="ASP.NET 2.0 CSS Friendly Control Adapters 1.0" StyleSheetTheme="Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>ASP.NET 2.0 CSS Friendly Control Adapters 1.0</h1>
    
	<h2>Version information</h2>
	<p>
	    This version was last updated on 20 November 2006.
	</p>
	<p>
	    <strong>If you downloaded the original version on 4/27/2006 (Beta 1) please update your bits immediately.</strong>
	</p>	
	
	<h2>Download the source</h2>
	<div class="dashboardLink">
   	    <asp:Button runat="server" ID="DownloadSourceBtn" Text="download source" OnClientClick="window.open('http://go.microsoft.com/fwlink/?LinkId=65782')" CssClass="button" onmouseover="this.className='button-hover'" onmouseout="this.className='button'" />
    </div>
    
    <h2>Introduction</h2>
    <p>
        Welcome! ASP.NET is a great technology for building web sites but it would be even
        better if it provided more flexibility for customizing the rendered HTML. For example,
        the Menu control makes it simple to add a menu to a web site, but it would be better
        if it didn't create &lt;table&gt; tags and was easier to style using CSS. Happily,
        it's easy to customize and adapt the Menu control to generate better HTML. Indeed,
        you can modify any ASP.NET control so it produces exactly the HTML you want.
    </p>
    <p>
        The key is to use something that may be new to you: control adapters. These are
        little chunks of logic that you add to your web site to effectively "adapt" an ASP.NET
        control to render the HTML you prefer. The ASP.NET 2.0 CSS Friendly Control Adapters kit
        provides pre-built control adapters that you can easily use to generate CSS friendly
        markup from some of the more commonly used ASP.NET controls.
    </p>
    
    <h2>Getting Started</h2>
    <p>        
        Before trying to learn how control adapters work, it's helpful to see them in action. Use the
        <em>Examples</em> menu at the top of this page to see the impact of adapting some of the ASP.NET
        controls.
    </p>
    <p>
        Each example page lets you enable/disable the adapters so you can immediately see their impact.
        Likewise, you can dynamically change themes, swapping in a different set of CSS files without
        changing the HTML markup.  A source code viewer lets you study how each sample is constructed.
    </p>
    <p>
        These sample control adapters demonstrate how to build an ASP.NET web site that is particularly
        easy to style with CSS. Feel free to use, copy, clone and modify the markup, CSS and code that
        you find here. To experiment with a local copy of this web site:
    </p>
    <ol>
        <li>
            Install
            <a href="http://msdn.microsoft.com/vstudio/express/vwd/download/" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;">Visual Web Developer</a>
            (VWD) or
            <a href="http://msdn.microsoft.com/vstudio/" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;">Visual Studio 2005</a>
            (VS).
        </li>
        <li>
            <a href="http://go.microsoft.com/fwlink/?LinkId=65782" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;">Download</a>
            this kit's
            <a href="http://msdn2.microsoft.com/en-us/library/ms165096.aspx" onclick="window.open(this.href, '_blank', ''); return false;" onkeypress="window.open(this.href, '_blank', ''); return false;">VSI file</a>.
            It adds a new web site template to your installation of VWD/VS.
        </li>
        <li>
            Use the File menu in VWD/VS to create a new web site that uses the new template:
            Tutorial on ASP.NET CSS Friendly Control Adapters.
        </li>
        <li>
            Run the new web site using the built-in Cassini web server (F5 key in VWD/VS).
        </li>
    </ol>
</asp:Content>


