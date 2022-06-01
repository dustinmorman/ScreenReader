using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenReader
{
    public partial class ControlPanel : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]

        
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        public Form1 captureForm = null;


        private Form m_InstanceRef = null;


        public Form InstanceRef
        {

            get
            {

                return m_InstanceRef;

            }
            set
            {

                m_InstanceRef = value;

            }

        }

        public ControlPanel()
        {

            InitializeComponent();
            this.KeyPreview = true;

            ghk = new KeyHandler(Keys.F1, this);
            ghk.Register();

        }

        //void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.ToString() == "F1")
        //    {
        //        BeginCapture();
        //    }
        //}
        public ControlPanel(bool Save)
        {

            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form_Close);

        }

        public void key_press(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }


        private void keyTest(KeyEventArgs e)
        {

            if (e.KeyCode.ToString() == "S")
            {

                screenCapture(true);

            }

        }


        private void Form_Close(object sender, FormClosedEventArgs e)
        {

            Application.Exit();

        }
        private void HandleHotkey()
        {
            BeginCapture();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }
        private void bttCaptureArea_Click(object sender, EventArgs e)
        {

            BeginCapture();

        }
        private void BeginCapture()
        {
            if(captureForm == null)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.InstanceRef = this;
                form1.Show();
                form1.parent = this;
                captureForm = form1;
            }
           
        }
        public void screenCapture(bool showCursor)
        {

            Point curPos = new Point(Cursor.Position.X, Cursor.Position.Y);
            Size curSize = new Size();
            curSize.Height = Cursor.Current.Size.Height;
            curSize.Width = Cursor.Current.Size.Width;

            //Conceal this form while the screen capture takes place
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.TopMost = false;

            //Allow 250 milliseconds for the screen to repaint itself (we don't want to include this form in the capture)
            System.Threading.Thread.Sleep(250);

            Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));




            ScreenShot.CaptureImage(showCursor, curSize, curPos, Point.Empty, Point.Empty, bounds);







        }

        private void bttCaptureScreen_Click(object sender, EventArgs e)
        {

            screenCapture(false);

        }





        private void ControlPanel_Load(object sender, EventArgs e)
        {

            this.KeyUp += new KeyEventHandler(key_press);

            System.Text.Encoding Encoder = System.Text.ASCIIEncoding.Default;
            Byte[] buffer = new byte[] { (byte)149 };
            string bullet = System.Text.Encoding.GetEncoding(1252).GetString(buffer);






            this.Width = 140;

        }


        private void saveToClipboard_KeyUp(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }

        private void bttCaptureArea_KeyUp(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }

        private void bttTips_KeyUp(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }

        private void bttCaptureScreen_KeyUp(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }

        private void txtTips_KeyUp(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }

        private void ControlPanel_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }

        }
        private void notifyIcon_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;

        }

        private void AudioButton_Click(object sender, EventArgs e)
        {
            TextToSpeechHelper t = new TextToSpeechHelper();
            t.ReadTextAloud(InstructionsLabel.Text);
        }
    }
    public static class Constants
    {
        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312;
    }
    public class KeyHandler
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int key;
        private IntPtr hWnd;
        private int id;

        public KeyHandler(Keys key, Form form)
        {
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, 0, key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
}
