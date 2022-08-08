using CefSharp;
using CefSharp.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace Replit_Browser_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializedBrowser();
        }

        private void InitializedBrowser()
        {
            CefSettings settings = new CefSettings();

            settings.CachePath = Path.GetFullPath("./Cache");
            Cef.Initialize(settings);

            mainBrowser.LoadUrl("https://replit.com/login");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBrowser.Refresh();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            mainBrowser.Back();
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBrowser.Forward();
        }

        private void inspectElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBrowser.ShowDevTools();
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (topMostToolStripMenuItem.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        // Events!

        private void mainBrowser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            mainBrowser.Invoke((MethodInvoker)(() => statusCode.Text = $"Status: Loading..."));
        }

        private void mainBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            mainBrowser.Invoke((MethodInvoker)(() => statusCode.Text = $"Status: {e.HttpStatusCode}"));
            mainBrowser.Invoke((MethodInvoker)(() => URL.Text = $"URL: {e.Url}"));
        }

        private void mainBrowser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            mainBrowser.Invoke((MethodInvoker)(() => this.Text = $"Replit Browser App | {e.Title}"));
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "D")
            {
                MessageBox.Show("True");
            }
        }
    }
}
