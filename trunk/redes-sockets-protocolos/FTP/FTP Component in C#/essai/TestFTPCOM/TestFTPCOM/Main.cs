using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TestFTPCOM
{
    public partial class Main : Form
    {
        private string m_previousfilename;
        private FTPCom.FTPC ftpc;
        private const string CRLF = "\r\n";
        private Shell32.Shell m_Shell;
        private Shell32.Folder m_RootShell;
        private Shell32.Folder m_currentFolder;
        private Icon m_IconFolder;
        public Main()
        {
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            SplitView.SplitPosition = this.Width / 2;

            m_Shell = new Shell32.ShellClass();
            m_RootShell = m_Shell.NameSpace(Shell32.ShellSpecialFolderConstants.ssfDRIVES);

            InitializeIconFolder();
            FillLocalView(m_RootShell);
        }
        private void InitializeIconFolder()
        {
            Shell32.Folder FolderShell = m_Shell.NameSpace(Shell32.ShellSpecialFolderConstants.ssfWINDOWS);
            Shell32.FolderItems items = FolderShell.Items();

            foreach (Shell32.FolderItem item in items)
                if (item.IsFolder)
                {
                    m_IconFolder = ExtractIcon.GetIcon(item.Path, true);
                    break;
                }
        }
        private void FillLocalView(Shell32.Folder folder)
        {

            this.Cursor = Cursors.WaitCursor;

            m_currentFolder = folder;
            // Notify that update begins
            LocalView.BeginUpdate();

            // Erase last view items
            LocalView.Items.Clear();

            // Erase previous lists image
            ImgListViewSmall.Images.Clear();
            ImgListViewLarge.Images.Clear();

            int idImage = 0;

            ListViewItem lvItem = new ListViewItem("..");
            lvItem.Tag = folder;

            LocalView.Items.Add(lvItem);

            Shell32.FolderItems items = folder.Items();

            // Folder enumeration
            foreach (Shell32.FolderItem item in items)
            {
                if (item.IsFolder)
                {
                    AddViewItem(item, ref idImage);
                }
            }

            // Other files 
            foreach (Shell32.FolderItem item in items)
            {
                if (!item.IsFolder)
                {
                    
                    AddViewItem(item, ref idImage);
                }
            }

            // End update view
            LocalView.EndUpdate();

            //ftpc.LocalFolder = folder.Title;

            this.Cursor = Cursors.Default;

        }
        private void AddViewItem(Shell32.FolderItem item, ref int idImage)
        {
            string[] sValues = new string[10];

            sValues[0] = item.Name;
            if (item.Size == 0)
                sValues[1] = "";
            else
                sValues[1] = Convert.ToString(item.Size / 1024) + " KB";
            sValues[2] = item.Type;
            sValues[3] = item.ModifyDate.ToString();
            /*
            sValues[4] = item.Path;
            sValues[5] = item.IsBrowsable.ToString();
            sValues[6] = item.IsFileSystem.ToString();
            sValues[7] = item.IsFolder.ToString();
            sValues[8] = item.IsLink.ToString();
            */
            try
            {
                ImgListViewSmall.Images.Add(ExtractIcon.GetIcon(item.Path, true));
            }
            catch { }
            ListViewItem lvItem = new ListViewItem(sValues, idImage++);
            lvItem.Tag = item;
            LocalView.Items.Add(lvItem);
        }

        private void BTConnect_Click(object sender, System.EventArgs e)
        {
        

            ftpc.Username = EFUsername.Text;
            ftpc.Password = EFPassword.Text;

            ftpc.Hostname = CBFTPServer.Text;
            ftpc.Connect();
        }
        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            ftpc.Disconnect();
            ServerView.Items.Clear();
        }
        private void LocalView_ItemActivate(object sender, System.EventArgs e)
        {
            if (LocalView.SelectedItems[0].Text == "..")
            {
                Shell32.Folder item;

                item = (Shell32.Folder)LocalView.SelectedItems[0].Tag;
                FillLocalView((Shell32.Folder)item.ParentFolder);
            }
            else
            {
                Shell32.FolderItem item;

                item = (Shell32.FolderItem)LocalView.SelectedItems[0].Tag;
                if (item.IsFolder)
                {
                    ftpc.LocalFolder = item.Path;
                    FillLocalView((Shell32.Folder)item.GetFolder);
                }
            }
        }

        private void LocalView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
        }
        private void LocalView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void LocalView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string msg = e.Data.GetData(DataFormats.Text).ToString();
            //MessageBox.Show (msg);

            string[] filename = msg.Split(new char[] { '\n' });
            foreach (string sfile in filename)
            {
                ftpc.FileDownload(sfile);
            }
        }
        private void ftpc_DirCompleted(object sender, FTPCom.FTPEventArgs e)
        {
            int i = 0;
            int idimage = 0;
            string msg;

            msg = "Transfered " + e.TotalBytes.ToString() + " bytes in " + ((float)e.TimeElapsed / 1000).ToString() + " seconds" + CRLF;
            TextLog.SelectionColor = Color.Black;
            TextLog.AppendText(msg);

            ServerView.BeginUpdate();
            ServerView.Items.Clear();
            ImgListServerSmall.Images.Clear();

            ListViewItem lvItem = new ListViewItem("..");
            ServerView.Items.Add(lvItem);

            for (i = 0; i < ftpc.FileCount; i++)
            {
                if (ftpc.IsFolder(i))
                {
                    string[] items = new String[2];
                    items[0] = ftpc.GetFileName(i);
                    items[1] = ftpc.GetFileSize(i).ToString();
                    ImgListServerSmall.Images.Add(m_IconFolder);
                    ServerView.Items.Add(new ListViewItem(items, idimage++));
                }
            }
            for (i = 0; i < ftpc.FileCount; i++)
            {
                if (!ftpc.IsFolder(i))
                {
                    string[] items = new String[2];
                    items[0] = ftpc.GetFileName(i);
                    items[1] = ftpc.GetFileSize(i).ToString();
                    ImgListServerSmall.Images.Add(ExtractIcon.GetIcon(items[0], false));
                    ServerView.Items.Add(new ListViewItem(items, idimage++));
                }
            }
            ServerView.EndUpdate();
            this.Cursor = Cursors.Default;
        }
        private void ftpc_FileDownloadCompleted(object sender, FTPCom.FTPEventArgs e)
        {
            string msg = "Transfered " + e.TotalBytes.ToString() + " bytes in " + ((float)e.TimeElapsed / 1000).ToString() + " seconds" + CRLF;
            TextLog.SelectionColor = Color.Black;
            TextLog.AppendText(msg);
            FillLocalView(m_currentFolder);
        }
        private void ftpc_FileUploadCompleted(object sender, FTPCom.FTPEventArgs e)
        {
            string msg = "Transfered " + e.TotalBytes.ToString() + " bytes in " + ((float)e.TimeElapsed / 1000).ToString() + " seconds" + CRLF;
            TextLog.SelectionColor = Color.Black;
            TextLog.AppendText(msg);
            ftpc.Dir();
        }

        private void ftpc_FTPCommand(object sender, FTPCom.FTPEventArgs e)
        {
            TextLog.SelectionColor = Color.Blue;
            if (e.Message != string.Empty)
                TextLog.AppendText(e.Message);
            TextLog.AppendText("\n");
            TextLog.SelectionStart = TextLog.TextLength;
            TextLog.ScrollToCaret();
        }
        public void ftpc_ConnectionTerminated(object sender, FTPCom.FTPEventArgs e)
        {

        }

        private void ServerView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }
        private void ServerView_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != 0)
            {
                string msg = "";

                for (int i = 0; i < ServerView.SelectedItems.Count; i++)
                {
                    msg += ServerView.SelectedItems[i].Text + "\n";
                }

                ServerView.DoDragDrop(msg, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void ServerView_ItemActivate(object sender, System.EventArgs e)
        {
            if (ServerView.SelectedItems[0].Text == "..")
            {
                this.Cursor = Cursors.WaitCursor;
                ftpc.DirUp();
                ftpc.Dir();
            }
            else
            {
                string dirname = ServerView.SelectedItems[0].Text;
                if (ftpc.IsFolder(dirname))
                {
                    this.Cursor = Cursors.WaitCursor;

                    ftpc.DirChange(dirname);
                    ftpc.Dir();
                }
            }
        }

        private void ServerView_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                this.Cursor = Cursors.WaitCursor;

                string newfilename = e.Label;
                if (m_previousfilename == "New Folder")
                {
                    ftpc.DirCreate(newfilename);
                }
                else
                {
                    ftpc.Rename(m_previousfilename, newfilename);
                }
                ftpc.Dir();
            }
        }

        private void ServerView_BeforeLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
        {
            m_previousfilename = ServerView.Items[e.Item].Text;
        }

        private void ServerView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ServerView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string msg = e.Data.GetData(DataFormats.Text).ToString();
            //MessageBox.Show (msg);

            string[] filename = msg.Split(new char[] { '\n' });
            foreach (string sfile in filename)
            {
                ftpc.FileUpload(sfile, GetFileSize(sfile));
            }
        }

        private void MenuDelete_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ServerView.SelectedItems.Count; i++)
            {
                ftpc.Delete(ServerView.SelectedItems[i].Text);
            }
            ftpc.Dir();
        }

        private void MenuDownload_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ServerView.SelectedItems.Count; i++)
            {
                ftpc.FileDownload(ServerView.SelectedItems[i].Text);
            }
        }

        private void MnuServerNewFolder_Click(object sender, System.EventArgs e)
        {
            ImgListServerSmall.Images.Add(m_IconFolder);
            ServerView.Items.Add(new ListViewItem("New Folder", ImgListServerSmall.Images.Count - 1));
            ServerView.Items[ServerView.Items.Count - 1].BeginEdit();
        }

        private void MnuServerRename_Click(object sender, System.EventArgs e)
        {
            ServerView.SelectedItems[0].BeginEdit();
        }

        private int GetFileSize(string filename)
        {
            FileInfo fi = new FileInfo(ftpc.LocalFolder + "\\" + filename);
            return ((int)fi.Length);
        }
    }
}
