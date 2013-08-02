namespace Mouser
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideOnCloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xcoordBox = new System.Windows.Forms.TextBox();
            this.ycoordBox = new System.Windows.Forms.TextBox();
            this.chooseButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.waitBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mouseButBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.pointRadioBut = new System.Windows.Forms.RadioButton();
            this.waitRadioBut = new System.Windows.Forms.RadioButton();
            this.clickRadioBut = new System.Windows.Forms.RadioButton();
            this.editButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.keysRadioBut = new System.Windows.Forms.RadioButton();
            this.keysBox = new System.Windows.Forms.TextBox();
            this.setButton = new System.Windows.Forms.Button();
            this.addstButton = new System.Windows.Forms.Button();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.delButton = new System.Windows.Forms.Button();
            this.hotkeyBox = new Mouser.ReadOnlyTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Mouser";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideOnCloseMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 70);
            this.contextMenuStrip1.Text = "Выход";
            // 
            // hideOnCloseMenuItem
            // 
            this.hideOnCloseMenuItem.CheckOnClick = true;
            this.hideOnCloseMenuItem.Name = "hideOnCloseMenuItem";
            this.hideOnCloseMenuItem.Size = new System.Drawing.Size(158, 22);
            this.hideOnCloseMenuItem.Text = "Hide on Closing";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.оПрограммеToolStripMenuItem.Text = "About";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.выходToolStripMenuItem.Text = "Exit";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // xcoordBox
            // 
            this.xcoordBox.Location = new System.Drawing.Point(76, 166);
            this.xcoordBox.Name = "xcoordBox";
            this.xcoordBox.Size = new System.Drawing.Size(36, 20);
            this.xcoordBox.TabIndex = 1;
            // 
            // ycoordBox
            // 
            this.ycoordBox.Location = new System.Drawing.Point(137, 166);
            this.ycoordBox.Name = "ycoordBox";
            this.ycoordBox.Size = new System.Drawing.Size(36, 20);
            this.ycoordBox.TabIndex = 2;
            // 
            // chooseButton
            // 
            this.chooseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chooseButton.Location = new System.Drawing.Point(179, 166);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(20, 20);
            this.chooseButton.TabIndex = 3;
            this.chooseButton.Tag = "";
            this.chooseButton.Text = "+";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chooseButton_KeyUp);
            this.chooseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chooseButton_MouseDown);
            this.chooseButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chooseButton_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(187, 147);
            this.listBox.TabIndex = 5;
            this.listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            this.listBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyUp);
            this.listBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            this.listBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            this.listBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseUp);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 272);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(59, 27);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // waitBox
            // 
            this.waitBox.Location = new System.Drawing.Point(76, 193);
            this.waitBox.Name = "waitBox";
            this.waitBox.Size = new System.Drawing.Size(97, 20);
            this.waitBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ms";
            // 
            // mouseButBox
            // 
            this.mouseButBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mouseButBox.FormattingEnabled = true;
            this.mouseButBox.Items.AddRange(new object[] {
            "Left",
            "Right",
            "Left_Double",
            "Left_Down",
            "Left_Up",
            "Right_Down",
            "Right_Up"});
            this.mouseButBox.Location = new System.Drawing.Point(76, 219);
            this.mouseButBox.Name = "mouseButBox";
            this.mouseButBox.Size = new System.Drawing.Size(123, 21);
            this.mouseButBox.TabIndex = 11;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 303);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(91, 25);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save as...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(108, 303);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(91, 25);
            this.openButton.TabIndex = 16;
            this.openButton.Text = "Open...";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // pointRadioBut
            // 
            this.pointRadioBut.AutoSize = true;
            this.pointRadioBut.Checked = true;
            this.pointRadioBut.Location = new System.Drawing.Point(12, 167);
            this.pointRadioBut.Name = "pointRadioBut";
            this.pointRadioBut.Size = new System.Drawing.Size(49, 17);
            this.pointRadioBut.TabIndex = 17;
            this.pointRadioBut.TabStop = true;
            this.pointRadioBut.Text = "Point";
            this.pointRadioBut.UseVisualStyleBackColor = true;
            this.pointRadioBut.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.pointRadioBut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chooseButton_KeyUp);
            // 
            // waitRadioBut
            // 
            this.waitRadioBut.AutoSize = true;
            this.waitRadioBut.Location = new System.Drawing.Point(12, 192);
            this.waitRadioBut.Name = "waitRadioBut";
            this.waitRadioBut.Size = new System.Drawing.Size(47, 17);
            this.waitRadioBut.TabIndex = 18;
            this.waitRadioBut.Text = "Wait";
            this.waitRadioBut.UseVisualStyleBackColor = true;
            this.waitRadioBut.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            this.waitRadioBut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chooseButton_KeyUp);
            // 
            // clickRadioBut
            // 
            this.clickRadioBut.AutoSize = true;
            this.clickRadioBut.Location = new System.Drawing.Point(12, 220);
            this.clickRadioBut.Name = "clickRadioBut";
            this.clickRadioBut.Size = new System.Drawing.Size(46, 17);
            this.clickRadioBut.TabIndex = 19;
            this.clickRadioBut.Text = "Click";
            this.clickRadioBut.UseVisualStyleBackColor = true;
            this.clickRadioBut.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            this.clickRadioBut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chooseButton_KeyUp);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(76, 272);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(59, 27);
            this.editButton.TabIndex = 20;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Hotkey";
            // 
            // keysRadioBut
            // 
            this.keysRadioBut.AutoSize = true;
            this.keysRadioBut.Location = new System.Drawing.Point(12, 247);
            this.keysRadioBut.Name = "keysRadioBut";
            this.keysRadioBut.Size = new System.Drawing.Size(48, 17);
            this.keysRadioBut.TabIndex = 23;
            this.keysRadioBut.TabStop = true;
            this.keysRadioBut.Text = "Keys";
            this.keysRadioBut.UseVisualStyleBackColor = true;
            this.keysRadioBut.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            this.keysRadioBut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chooseButton_KeyUp);
            // 
            // keysBox
            // 
            this.keysBox.Location = new System.Drawing.Point(76, 246);
            this.keysBox.Name = "keysBox";
            this.keysBox.Size = new System.Drawing.Size(123, 20);
            this.keysBox.TabIndex = 24;
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(153, 333);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(46, 20);
            this.setButton.TabIndex = 25;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // addstButton
            // 
            this.addstButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addstButton.Location = new System.Drawing.Point(114, 166);
            this.addstButton.Name = "addstButton";
            this.addstButton.Size = new System.Drawing.Size(21, 20);
            this.addstButton.TabIndex = 26;
            this.addstButton.Tag = "";
            this.addstButton.Text = "Х";
            this.addstButton.UseVisualStyleBackColor = true;
            this.addstButton.Click += new System.EventHandler(this.addstButton_Click);
            // 
            // bw
            // 
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(141, 272);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(58, 27);
            this.delButton.TabIndex = 27;
            this.delButton.Text = "Delete";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // hotkeyBox
            // 
            this.hotkeyBox.BackColor = System.Drawing.SystemColors.Menu;
            this.hotkeyBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.hotkeyBox.Location = new System.Drawing.Point(56, 333);
            this.hotkeyBox.Name = "hotkeyBox";
            this.hotkeyBox.ReadOnly = true;
            this.hotkeyBox.Size = new System.Drawing.Size(91, 20);
            this.hotkeyBox.TabIndex = 21;
            this.hotkeyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hotkeyBox_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 362);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.addstButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.keysBox);
            this.Controls.Add(this.keysRadioBut);
            this.Controls.Add(this.clickRadioBut);
            this.Controls.Add(this.hotkeyBox);
            this.Controls.Add(this.waitRadioBut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pointRadioBut);
            this.Controls.Add(this.mouseButBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.waitBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ycoordBox);
            this.Controls.Add(this.xcoordBox);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.addButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mouser";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.TextBox xcoordBox;
        private System.Windows.Forms.TextBox ycoordBox;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox waitBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox mouseButBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.RadioButton pointRadioBut;
        private System.Windows.Forms.RadioButton waitRadioBut;
        private System.Windows.Forms.RadioButton clickRadioBut;
        private System.Windows.Forms.Button editButton;
        private ReadOnlyTextBox hotkeyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton keysRadioBut;
        private System.Windows.Forms.TextBox keysBox;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Button addstButton;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.ToolStripMenuItem hideOnCloseMenuItem;
    }
}

