using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CSSFriendly;
using Wilco.SyntaxHighlighting;
using Wilco.Web.SyntaxHighlighting;

public partial class SrcViewer : DynamicAdaptersPage
{
    public string InspectUrl
    {
        get
        {
            string strRet = "";
            TreeNode node = null;

            if (SrcCodeViewerTree.SelectedNode != null)
            {
                strRet = UrlForNode(SrcCodeViewerTree.SelectedNode);
            }
            else if (!String.IsNullOrEmpty(Request.QueryString["inspect"]))
            {
                strRet = UrlForNode(NodeForUrl(Request.QueryString["inspect"]));
            }

            return strRet;
        }
    }

    public string InspectDiskPath
    {
        get { return (!String.IsNullOrEmpty(InspectUrl)) ? Server.MapPath(InspectUrl) : ""; }
    }

    public string Language
    {
        get
        {
            string lang = "XML";
            if (!String.IsNullOrEmpty(InspectDiskPath))
            {
                FileInfo fInfo = new FileInfo(InspectDiskPath);
                if (fInfo != null)
                {
                    string extension = fInfo.Extension.ToLower().Substring(1);
                    foreach (HighlighterBase h in Register.Instance.Highlighters)
                    {
                        if (h.FileExtensions.Contains(extension))
                        {
                            lang = h.Name;
                            break;
                        }
                    }
                }
            }
            return lang;
        }
    }

    public string FileContents
    {
        get
        {
            string str = "";
            if (!String.IsNullOrEmpty(InspectUrl))
            {
                using (StreamReader sr = File.OpenText(InspectDiskPath))
                {
                    String input;
                    while ((input = sr.ReadLine()) != null)
                    {
                        str += input + "\n";
                    }
                    sr.Close();
                }
            }
            return str;
        }
    }

    public bool ShowTree
    {
        get { return (Request.QueryString["notree"] == null) || (Request.QueryString["notree"].IndexOf("true", StringComparison.OrdinalIgnoreCase) == -1); }
    }

    public void Page_Load(Object sender, EventArgs e)
    {
        string ctrl = "";
        if (!ShowTree)
        {
            SourceTreeDS.XPath = "./assets/logicalUnit";
        }
        else if (Request.Cookies["LastVisitedExampleControl"] != null)
        {
            ctrl = Request.Cookies["LastVisitedExampleControl"].Value;
            if (!String.IsNullOrEmpty(ctrl))
            {
                SourceTreeDS.XPath = "./assets/logicalUnit[@id='" + ctrl + "']";
            }
        }

        DataBind();

        FileBanner.InnerText = InspectUrl;
        SrcCodeViewerPanel.Language = Language;
        SrcCodeViewerPanel.Text = FileContents;
        
        ReturnBtn.Attributes["xml:lang"] = "en";
        ReturnBtn.Attributes["onmouseover"] = "this.className='button-hover'";
        ReturnBtn.Attributes["onmouseout"] = "this.className='button'";

        SCVTree.Visible = ShowTree;
    }

    protected override void RaisePostBackEvent(IPostBackEventHandler sourceControl, string eventArgument)
    {
        base.RaisePostBackEvent(sourceControl, eventArgument);

        FileBanner.InnerText = InspectUrl;
        SrcCodeViewerPanel.Language = Language;
        SrcCodeViewerPanel.Text = FileContents;
    }

    protected void ReturnBtnClicked(object sender, EventArgs e)
    {
        if (Request.Cookies["LastVisitedExampleUrl"] != null)
        {
            Response.Redirect(Request.Cookies["LastVisitedExampleUrl"].Value);
        }
    }

    protected string UrlForNode(TreeNode node)
    {
        string strRet = "";
        if (node != null)
        {
            string parentFolderPath = "";
            TreeNode parent = node.Parent;
            if ((parent != null) && (parent.ValuePath.IndexOf("/") > -1))
            {
                parentFolderPath = parent.ValuePath.Substring(parent.ValuePath.IndexOf("/") + 1);
                parentFolderPath += "/";
            }
            strRet += "~/" + parentFolderPath + node.Text;
        }
        return strRet;
    }

    protected TreeNode NodeForUrl(string url)
    {
        return NodeForUrl(url, SrcCodeViewerTree.Nodes);
    }

    protected TreeNode NodeForUrl(string url, TreeNodeCollection nodes)
    {
        string givenPath = Server.MapPath(url);

        TreeNode answer = null;
        foreach (TreeNode node in nodes)
        {
            if (Server.MapPath(UrlForNode(node)).Equals(givenPath, StringComparison.OrdinalIgnoreCase))
            {
                answer = node;
                break;
            }
            if (node.ChildNodes.Count > 0)
            {
                answer = NodeForUrl(url, node.ChildNodes);
            }
            if (answer != null)
            {
                break;
            }
        }
        return answer;
    }
}
