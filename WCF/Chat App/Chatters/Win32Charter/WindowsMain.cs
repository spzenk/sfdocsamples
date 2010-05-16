using System;
using System.Windows.Forms;
using Common;
using WPFChatter;

namespace Win32Charter
{
    public delegate void AddButtonClick(object s); 
    public partial class WindowsMain : Form
    {   
        #region Instance Fields
        Person currPerson;
        bool chatControlShown = false;
        private Proxy_Singleton ProxySingleton = Proxy_Singleton.GetInstance();
        #endregion

        private  event AddButtonClick _AddButtonClickEvent;

        private void OnAddButtonClickEvent(object s)
        {
            if (_AddButtonClickEvent != null)
                _AddButtonClickEvent(s);
        }
        public event AddButtonClick TerminoIntervaloEvent
        {
            add
            {
                _AddButtonClickEvent = (AddButtonClick)Delegate.Combine(_AddButtonClickEvent, value);

            }
            remove
            {
                _AddButtonClickEvent = (AddButtonClick)Delegate.Remove(_AddButtonClickEvent, value);
            }
        }
        #region Instance Fields
        string photoPath;
        Person currentPerson;
        #endregion

        public Person CurrentPerson
        {
            get { return currentPerson; }
            set { currentPerson = value; }
        }
        
        public WindowsMain()
        {
            InitializeComponent();
            
        }

      

        private void PhotoBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

            if (fileNames.Length > 0)
            {
                photoPath = fileNames[0];
                //photoSrc.Source = new BitmapImage(new Uri(photoPath));
                PhotoBox.Image = System.Drawing.Bitmap.FromFile(photoPath);
                
            }

            // Mark the event as handled, so the control's native Drop handler is not called.
            //e.Handled = true;
        }

        private void PhotoBox_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            if (fileNames.Length > 0)
            {
                photoPath = fileNames[0];
                //photoSrc.Source = new BitmapImage(new Uri(photoPath));
                PhotoBox.Image = System.Drawing.Bitmap.FromFile(photoPath);
                PhotoBox.Refresh();
            }

          
        }

        private void AddButton_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) &&
               !string.IsNullOrEmpty(photoPath))
            {
                currentPerson = new Person();
                currentPerson.ImageURL = photoPath;
                currentPerson.Name = txtName.Text;

                //RaiseEvent(new RoutedEventArgs(AddButtonClickEvent));
                OnAddButtonClickEvent(this);
            }
            else
            {
                MessageBox.Show("You need to pick a screen name and image", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Add()
        {
            //lstChatters.Items.Clear();
            //currenPerson = this.SignInControl.CurrentPerson;
            //connect to proxy, and subscribe to its events
            //ProxySingleton.Connect(currPerson);
            ProxySingleton.Connect(currentPerson);
            
            
            ProxySingleton.ProxyEvent += new Proxy_Singleton.ProxyEventHandler(ProxySingleton_ProxyEvent);
            //one event subscription for the embedded ChatControl
            //ProxySingleton.ProxyCallBackEvent += new Proxy_Singleton.ProxyCallBackEventHandler(this.ChatControl.ProxySingleton_ProxyCallBackEvent);
            ProxySingleton.ProxyCallBackEvent += new Proxy_Singleton.ProxyCallBackEventHandler(ProxySingleton_ProxyCallBackEvent);
            //one event subscription for this window
            ProxySingleton.ProxyCallBackEvent += new Proxy_Singleton.ProxyCallBackEventHandler(this.ProxySingleton_ProxyCallBackEvent);
            //set the UI elements using signin data
            //this.photoBig.Source = new BitmapImage(new Uri(currPerson.ImageURL));
            //this.SignInControl.Visibility = Visibility.Hidden;
            //this.MainBorder.Visibility = Visibility.Visible;
            //this.mnuBorder.Visibility = Visibility.Visible;
            //this.lblInstructions.Content = "You can click on the gridview below to launch a chat window. When the window is opened you may\r\n" +
            //                            "either chat using either the Whisper button which will ONLY chat to the person you selected in\r\n" +
            //                            "the gridview, or you can use the Say button, which will allow ALL connected people to see the message.\r\n";
            //this.txtPerson.Content = "Hello " + currPerson.Name;
        }

        void ProxySingleton_ProxyCallBackEvent(object sender, ProxyCallBackEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void ProxySingleton_ProxyEvent(object sender, ProxyEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}