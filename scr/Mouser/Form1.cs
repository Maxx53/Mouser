using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace Mouser
{
    public partial class Form1 : Form
    {
        const int WM_HOTKEY = 0x0312;
        const uint WM_VSCROLL = 0x0115;
        const uint SB_BOTTOM = 7;
        
        bool copyItem = false;
        bool inTray = false;
        bool forceClose = false;

        const string op_p = "Point:";
        const string op_w = "Wait:";
        const string op_c = "Click:";
        const string op_k = "Keys:";

        const string _start = "Start";
        const string _filter = "Text (*.txt)|*.txt";
        const string _info = "Copyright © 2013, Maxx53\r\ndemmaxx@gmail.com";

        Semaphore s = new Semaphore(0, 1);

        Keys modif = Keys.Alt;
        Keys keyHot = Keys.X;

        string tempStr = string.Empty;
        string lastfile = "default.txt";

        int trackingItem = 0;

        [DllImport("User32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);


        public Form1()
        {
            InitializeComponent();
        }

        public void ClickOn(int curX, int curY, string param)
        {
            switch (param)
            {
                case "Left":
                    mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, curX, curY, 0, UIntPtr.Zero);
                    mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, curX, curY, 0, UIntPtr.Zero);
                    break;
                case "Rignt":
                    mouse_event(MouseFlags.Absolute | MouseFlags.RightDown, curX, curY, 0, UIntPtr.Zero);
                    mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, curX, curY, 0, UIntPtr.Zero);
                    break;
                case "Left_Double":
                    mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, curX, curY, 0, UIntPtr.Zero);
                    mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, curX, curY, 0, UIntPtr.Zero);
                    Thread.Sleep(150);
                    mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, curX, curY, 0, UIntPtr.Zero);
                    mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, curX, curY, 0, UIntPtr.Zero);
                    break;
                case "Left_Down":
                    mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, curX, curY, 0, UIntPtr.Zero);
                    break;
                case "Left_Up":
                    mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, curX, curY, 0, UIntPtr.Zero);
                    break;
                case "Rignt_Down":
                    mouse_event(MouseFlags.Absolute | MouseFlags.RightDown, curX, curY, 0, UIntPtr.Zero);
                    break;
                case "Rignt_Up":
                    mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, curX, curY, 0, UIntPtr.Zero);
                    break;
                default:
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HotKeyId)
            {
                if (bw.IsBusy != true)
                {
                    listBox.Enabled = false;
                    bw.RunWorkerAsync();
                }
                else s.Release();
                //bw.CancelAsync();
            }
            base.WndProc(ref m);
        }

        public int HotKeyId { get; set; }

        private void Form1_Activated(object sender, EventArgs e)
        {
           // this.Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forceClose = true;
            this.Close();
        }

        private void chooseButton_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Cross;
            timer1.Enabled = true;
            
        }


        private void chooseButton_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            xcoordBox.Text = Cursor.Position.X.ToString();
            ycoordBox.Text = Cursor.Position.Y.ToString();
        }

        public void ScrollDown()
        {
            SendMessage(listBox.Handle, WM_VSCROLL, SB_BOTTOM, 0);
        }

        public void AddToList()
        {
            if (listBox.Enabled)
            {
                string toadd = string.Empty;

                if (pointRadioBut.Checked)
                {
                    int i;
                    if (int.TryParse(xcoordBox.Text, out i))
                        toadd = string.Format("{0} {1}x{2}", op_p, xcoordBox.Text, ycoordBox.Text);
                    else toadd = string.Format("{0} {1}", op_p, _start);
                }
                else
                    if (waitRadioBut.Checked)

                        toadd = string.Format("{0} {1}", op_w, waitBox.Text);
                    else
                        if (clickRadioBut.Checked)

                            toadd = string.Format("{0} {1}", op_c, mouseButBox.SelectedItem.ToString());
                        else
                            if (keysRadioBut.Checked)
                                toadd = string.Format("{0} {1}", op_k, keysBox.Text);

                if (listBox.SelectedIndex != -1)
                {
                    listBox.Items.Insert(listBox.SelectedIndex, toadd);
                    listBox.SelectedIndex -= 1;
                }
                else
                {
                    listBox.Items.Add(toadd);
                    ScrollDown();
                }
            }
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddToList();
        }



        private void LoadSettings()
        {
            var settings = Properties.Settings.Default;

            //Size = settings.MainWindowSize;
           // Location = settings.savedWinPos;

            modif = (Keys)settings.hotMod;
            keyHot = (Keys)settings.hotKey;

            lastfile = settings.LastFile;
            readFile(lastfile);

            hideOnCloseMenuItem.Checked = settings.toTray;
            inTray = settings.inTray;

            if (inTray)
            {
                this.ShowInTaskbar = false;
                this.Hide();

            }
         
        }


        private void SaveSettings()
        {
            var settings = Properties.Settings.Default;

            settings.hotMod = Convert.ToInt32(modif);
            settings.hotKey =  Convert.ToInt32(keyHot);

            settings.LastFile = lastfile;
            writeFile(lastfile);

            settings.toTray = hideOnCloseMenuItem.Checked;
            settings.inTray = inTray;

            settings.Save();
        }


        public void regHotKey()
        {
            HotKeys.Unregister(this, this.HotKeyId);
            HotKeys.Register(this, this.HotKeyId, HotKeys.GetMod(modif), keyHot);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            hotkeyBox.Text = string.Format("{0} + {1}", modif.ToString(), keyHot.ToString());
            regHotKey();
            
            mouseButBox.SelectedIndex = 0;
            radioButton1_CheckedChanged(sender, e);
            radioButton2_CheckedChanged(sender, e);
            radioButton3_CheckedChanged(sender, e);
            radioButton4_CheckedChanged(sender, e);

            toolTip1.SetToolTip(this.hotkeyBox, "Click here and Push your HotKey");
            toolTip1.SetToolTip(this.setButton, "Click here to Set your HotKey");
            toolTip1.SetToolTip(this.chooseButton, "Hold this Button and Move your Cursor to сhange Point Coordinates\r\nPress SPACE to Add It to List");
            toolTip1.SetToolTip(this.listBox, "Hold CTRL while Dragging Item to Copy\r\nPress DEL to Delete Item");
            toolTip1.SetToolTip(this.addButton, "You also may Press SPACE to add selected Value to the List");
            toolTip1.SetToolTip(this.delButton, "You also may Press DEL to Delete Item from the List");


            LoadSettings();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && hideOnCloseMenuItem.Checked == true && forceClose == false)
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                this.Hide();
                regHotKey();
                inTray = true;
            }
            else
            {
                SaveSettings();
                notifyIcon1.Dispose();
                //System.Windows.Forms.Application.Exit();
            }

       }


        public void writeFile(string name)
        {
                using (var sw = new StreamWriter(name, false))
                    foreach (var item in listBox.Items)
                        sw.Write(item.ToString() + Environment.NewLine);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog();
            saveFile.Filter = _filter;
            if (saveFile.ShowDialog() == DialogResult.OK)
                writeFile(saveFile.FileName);
        }


        public void readFile(string name)
        {
            if (File.Exists(name) != false)
            {
                listBox.Items.Clear();
                using (StreamReader sr = new StreamReader(name, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        listBox.Items.Add(sr.ReadLine());
                    }
                    sr.Close();
                }

                lastfile = name;

                if (listBox.Items.Count > 0)
                {
                    listBox.SelectedIndex = 0;
                    readFromLst();
                }
                //ScrollDown();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = _filter;
            if (openFile.ShowDialog() == DialogResult.OK)
                readFile(openFile.FileName);
        }


        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            trackingItem = listBox.SelectedIndex;
            if (trackingItem >= 0)
            {
                tempStr = listBox.Items[listBox.SelectedIndex].ToString();
            }
        }


        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int tempInd = listBox.SelectedIndex;

            if (tempInd >= 0)
            {
                if (tempInd != trackingItem)
                {
                    if (!copyItem)
                        listBox.Items.RemoveAt(trackingItem);
                    listBox.Items.Insert(tempInd, tempStr);
                    listBox.SelectedIndex = tempInd;
                    Cursor = Cursors.Default;
                } 

                readFromLst();
            }
        }


        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listBox.SelectedIndex != trackingItem)
                {
                    if (copyItem)
                        Cursor = Cursors.HSplit;
                    else
                        Cursor = Cursors.SizeNS;
                }
                else
                  Cursor = Cursors.Default;
 
            }

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                xcoordBox.Enabled = pointRadioBut.Checked;
                ycoordBox.Enabled = pointRadioBut.Checked;
                chooseButton.Enabled = pointRadioBut.Checked;
                xcoordBox.Text = "0";
                ycoordBox.Text = "0";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            waitBox.Enabled = waitRadioBut.Checked;
            waitBox.Text = "50";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            mouseButBox.Enabled = clickRadioBut.Checked;
            mouseButBox.SelectedItem = 0;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            keysBox.Enabled = keysRadioBut.Checked;
            keysBox.Text = "{}";
        }


        public void readFromLst()
        {
            if (listBox.Items.Count != 0)
            {
                
                string currIt = listBox.SelectedItem.ToString();

                string[] parts = currIt.Split(' ');
                string mainWord = parts[0];
                string param = parts[1];

                switch (mainWord)
                {

                    case op_c:
                        clickRadioBut.Checked = true;
                        mouseButBox.SelectedIndex = mouseButBox.FindStringExact(param);
                        break;

                    case op_p:
                        pointRadioBut.Checked = true;

                        if (param == _start)
                        {
                            xcoordBox.Text = _start;
                            ycoordBox.Text = string.Empty;
                        }
                        else
                        {
                            string[] curpos = param.Split('x');
                            xcoordBox.Text = curpos[0];
                            ycoordBox.Text = curpos[1];
                        }
                        break;
                    case op_w:

                        waitRadioBut.Checked = true;
                        waitBox.Text = param;
                        break;

                    case op_k:

                        keysRadioBut.Checked = true;
                        keysBox.Text = param;
                        break;

                    default:
                        break;
                }
            }
        }


        public void editItem()
        {
            if (listBox.Enabled)
            {

                if (pointRadioBut.Checked)
                    listBox.Items[listBox.SelectedIndex] = string.Format("{0} {1}x{2}", op_p, xcoordBox.Text, ycoordBox.Text);
                else
                    if (waitRadioBut.Checked)
                        listBox.Items[listBox.SelectedIndex] = string.Format("{0} {1}", op_w, waitBox.Text);
                    else
                        if (clickRadioBut.Checked)
                            listBox.Items[listBox.SelectedIndex] = string.Format("{0} {1}", op_c, mouseButBox.SelectedItem.ToString());
                        else
                            if (keysRadioBut.Checked)
                                listBox.Items[listBox.SelectedIndex] = string.Format("{0} {1}", op_k, keysBox.Text);
            }
        }


        private void editButton_Click(object sender, EventArgs e)
        {
            editItem();
        }

        public void deleteItem()
        {
            int selec = listBox.SelectedIndex;

            if (listBox.Items.Count > 0 && selec !=-1)
            {
                
                listBox.Items.RemoveAt(selec);

                if (selec < listBox.Items.Count)
                    listBox.SelectedIndex = selec;
                else if (selec == listBox.Items.Count)
                    listBox.SelectedIndex = listBox.Items.Count - 1;

                if (listBox.Items.Count != 0)
                    readFromLst();
            }

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                deleteItem();
            }

            if (e.Modifiers == Keys.Control)
                copyItem = true;

        }

        private void hotkeyBox_KeyDown(object sender, KeyEventArgs e)
        {

                if (e.Modifiers != Keys.None)
                {
                    hotkeyBox.Text = e.Modifiers.ToString();

                    if (e.KeyCode.ToString().Length == 1)
                        hotkeyBox.Text += " + " + e.KeyCode;
                }
                else
                {
                    if (e.KeyCode.ToString().Length == 1)
                        hotkeyBox.Text = e.KeyCode.ToString();
                }

                modif = e.Modifiers;
                keyHot = e.KeyCode;
        }

 


        private void setButton_Click(object sender, EventArgs e)
        {
            if (modif == Keys.None)
            {
                hotkeyBox.Text = "Wrong Combo!";
                return;
            }

            regHotKey();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_info , "About " + Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


        private void chooseButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                AddToList();
            }
        }


        private void addstButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Add(op_p + _start);
        }

        private void bw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (listBox.Items.Count != 0)
            {
                Point StartPos = new Point(Cursor.Position.X, Cursor.Position.Y);

                for (int i = 0; i < listBox.Items.Count; i++)
                {

                    string currIt = listBox.Items[i].ToString();
                    string[] parts = currIt.Split(' ');

                    string mainWord = parts[0];
                    string param = parts[1];


                    switch (mainWord)
                    {

                        case op_c:
                            ClickOn(Cursor.Position.X, Cursor.Position.Y, param);
                            break;

                        case op_p:
                            if (param == _start)
                            {
                                Cursor.Position = StartPos;
                            }
                            else
                            {
                                string[] curpos = param.Split('x');
                                Cursor.Position = new Point(Convert.ToInt16(curpos[0]), Convert.ToInt16(curpos[1]));
                            }

                            break;
                        case op_w:

                            int time = Convert.ToInt32(param);

                            s.WaitOne(time);

                            break;
                        case op_k:

                            //How to add command Keys read here:
                            //http://msdn.microsoft.com/en-us//library/system.windows.forms.sendkeys.aspx

                            SendKeys.SendWait(param);

                            break;
                        default:
                            break;
                    }
                }

            }

        }

        private void bw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            listBox.Enabled = true;
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.ControlKey)
            {
                copyItem = false;
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            deleteItem();
        }



        private void Form1_SizeChanged(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Hide();
                regHotKey();
                inTray = true;
            }

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (inTray)
                {
                    this.ShowInTaskbar = true;
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Focus();
                    inTray = false;
                    regHotKey();
                }
                else
                {
                    this.ShowInTaskbar = false;
                    this.Hide();
                    regHotKey();
                    inTray = true;
                }
            }
        }





    }
}