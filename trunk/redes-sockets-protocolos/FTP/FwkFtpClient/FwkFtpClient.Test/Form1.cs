using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTPTest;

namespace FwkFtpClient
{
    public partial class Form1 : Form
    {
        int logCount = 0;
        static StringBuilder logs;
        public Form1()
        {
            InitializeComponent();
            logs = new StringBuilder();
            //ftpComponent1.OnErrorEvent += new ErrorHandler(ftpComponent1_OnErrorEvent);
            ftpComponent1.OnLoginEvent += new ObjectHandler(ftpComponent1_OnLoginEvent);
            ftpComponent1.OnFileListResivedEvent += new FileListResivedHandler(ftpComponent1_OnFileListResivedEvent);

            //ftpComponent1.OnFileRemovedEvent += new ObjectHandler(ftpComponent1_OnFileRemovedEvent);
            //ftpComponent1.OnFileDowloadEvent += new ObjectHandler(ftpComponent1_OnFileDowloadEvent);
            //ftpComponent1.OnFileUploadedEvent += new ObjectHandler(ftpComponent1_OnFileUploadedEvent);

            //ftpComponent1.OnDirectoryChangedEvent += new ObjectHandler(ftpComponent1_OnDirectoryChangedEvent);
            //ftpComponent1.OnDirectoryCreatedEvent += new ObjectHandler(ftpComponent1_OnDirectoryCreatedEvent);
            //ftpComponent1.OnDirectoryRemovedEvent += new ObjectHandler(ftpComponent1_OnDirectoryRemovedEvent);
        }

        void ftpComponent1_OnDirectoryRemovedEvent(object sender,Exception ex)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new ObjectHandler(ftpComponent1_OnDirectoryRemovedEvent), new object[] { sender,ex });
                return;
            }
        }

        void ftpComponent1_OnDirectoryCreatedEvent(object sender, Exception ex)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new ObjectHandler(ftpComponent1_OnDirectoryCreatedEvent), new object[] { sender });
                return;
            }
        }

        void ftpComponent1_OnDirectoryChangedEvent(object sender, Exception ex)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new ObjectHandler(ftpComponent1_OnDirectoryChangedEvent), new object[] { sender });
                return;
            };
        }

        void ftpComponent1_OnFileUploadedEvent(object sender, Exception ex)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new ObjectHandler(ftpComponent1_OnFileUploadedEvent), new object[] { sender, ex });
                return;
            }
        }

        void ftpComponent1_OnFileDowloadEvent(object sender, Exception ex)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ObjectHandler(ftpComponent1_OnFileDowloadEvent), new object[] { sender, ex });
                return;
            }
        }

        void ftpComponent1_OnFileRemovedEvent(object sender, Exception ex)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new ObjectHandler(ftpComponent1_OnFileRemovedEvent), new object[] { sender, ex });
                return;
            }
        }

        void ftpComponent1_OnFileListResivedEvent(string patch, String[] list, Exception ex)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new FileListResivedHandler(ftpComponent1_OnFileListResivedEvent), new object[] { patch, list ,ex});
                return;
            }
            if (ex != null)
            {
                AddLog(ex.Message);
                return;
            }
            TreeNode parentNode = GetTreeNode_ByName(treeView1.Nodes, patch);

            parentNode.Nodes.Clear();
            TreeNode t;
            StringBuilder str = new StringBuilder();
            List<ServerFileData> listServerFileData = new List<ServerFileData>();
            foreach (string file in list)
            {
                //ServerFileData d = ParseDosDirLine(file);
                str.AppendLine(file);
            }
            foreach (string file in list)
            {
                if (!string.IsNullOrEmpty(file))
                {
                    t = new TreeNode(file);
                    t.Name = string.Concat(patch, @"\", file);
                    t.ImageKey = "doc_16.png";
                    t.SelectedImageKey = "doc_sel_16.ico";
                    t.Tag = "file";
                    parentNode.Nodes.Add(t);
                }
            }

            parentNode.ExpandAll();

        }
        private ServerFileData ParseDosDirLine(string line)
        {
            ServerFileData sfd = new ServerFileData();

            try
            {
                string[] parsed = new string[3];
                int index = 0;
                int position = 0;

                // Parse out the elements
                position = line.IndexOf(' ');
                while (index < parsed.Length)
                {
                    parsed[index] = line.Substring(0, position);
                    line = line.Substring(position);
                    line = line.Trim();
                    index++;
                    position = line.IndexOf(' ');
                }
                sfd.fileName = line;

                if (parsed[2] != "<DIR>")
                    sfd.size = Convert.ToInt32(parsed[2]);

                sfd.date = parsed[0] + ' ' + parsed[1];
                sfd.isDirectory = parsed[2] == "<DIR>";
            }
            catch
            {
                sfd = null;
            }
            return sfd;
        }
        void ftpComponent1_OnLoginEvent(object sender,Exception ex)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new ObjectHandler(ftpComponent1_OnLoginEvent), new object[] { sender, ex });
                return;
            }
            if (ex != null)
            {
                AddLog(ex.Message);
                return;
            }
            TreeNode dir = new TreeNode(ftpComponent1.FTPPath);
            dir.Tag = "dir";
            dir.Name = ftpComponent1.FTPPath;
            dir.ImageKey = "folder_close_16.png";

            treeView1.Nodes.Add(dir);
            AddLog("Conected to server " + ftpComponent1.FTPServer);
            ftpComponent1.BeginGetFileListAsync("*.*");
            
        }

        void ftpComponent1_OnErrorEvent(Exception ex)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new ErrorHandler(ftpComponent1_OnErrorEvent), new object[] { ex });
                return;
            }

            AddLog(ex.Message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ftp://194.44.214.3/pub/music/Dance/
            //172.22.12.22/
            //ftpComponent1.FTPHost = "194.44.214.3";
            ftpComponent1.FTPServer = "172.22.12.22";

            ftpComponent1.FTPPass = "";
            //ftpComponent1.FTPUser = "";

            ftpComponent1.FTPPort = 21;
            ftpComponent1.Debug = true;


            ftpComponent1.Conect();
        }

        void AddLog(string msg)
        {
            logs.AppendLine();
            logs.AppendLine(".................................");

            logs.AppendLine(string.Concat("(", logCount++, ")   t: ", System.DateTime.Now.ToLongTimeString()));
            logs.AppendLine(msg);
            logs.AppendLine(".................................");

            txtLogs.Text = logs.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          string fileName =  Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open(string.Empty, "");
          try
          {
              ftpComponent1.Upload(fileName);
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
          }
        }

        TreeNode GetTreeNode_ByName(TreeNodeCollection nodeList, string name)
        {
            foreach (TreeNode node in nodeList)
            {
                if (node.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return node;

            }
            return null;
        }

        

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag.Equals("dir"))
            {
                e.Node.ImageKey = "folder_open_16.png";
            }
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag.Equals("dir"))
            {
                e.Node.TreeView.BeginUpdate();
                e.Node.ImageKey = "folder_close_16.png";
                e.Node.TreeView.EndUpdate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ftpComponent1.FTPServer = "194.44.214.3";

            ftpComponent1.FTPPass = "";
            //ftpComponent1.FTPUser = "";

   
            //ftpComponent1.FTPPath = "ftp://194.44.214.3/pub/music";

            //ftpComponent1.FTPPath = "./pub/music/Dance/";
            ftpComponent1.FTPPath = "./pub/music/Dance/";
            ftpComponent1.FTPPort = 21;
            ftpComponent1.Debug = false;
            ftpComponent1.BeginConnectAsync();
   
        }

        private void button4_Click(object sender, EventArgs e)
        {
           string[] f= ftpComponent1.GetFileList("*.*");
        }

    }
}
