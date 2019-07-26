namespace FileExplorer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView_list = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView_show = new System.Windows.Forms.ListView();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button_back = new System.Windows.Forms.Button();
            this.richTextBox_txtShow = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_copy = new System.Windows.Forms.Button();
            this.button_cut = new System.Windows.Forms.Button();
            this.button_parse = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Mini = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Mini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView_list
            // 
            this.treeView_list.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.treeView_list.Font = new System.Drawing.Font("Consolas", 12F);
            this.treeView_list.ImageIndex = 11;
            this.treeView_list.ImageList = this.imageList1;
            this.treeView_list.Location = new System.Drawing.Point(12, 118);
            this.treeView_list.Name = "treeView_list";
            this.treeView_list.SelectedImageIndex = 11;
            this.treeView_list.Size = new System.Drawing.Size(232, 561);
            this.treeView_list.TabIndex = 0;
            this.treeView_list.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_list_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "7zL.png");
            this.imageList1.Images.SetKeyName(1, "archiveL.png");
            this.imageList1.Images.SetKeyName(2, "ascL.png");
            this.imageList1.Images.SetKeyName(3, "aspL.png");
            this.imageList1.Images.SetKeyName(4, "aviL.png");
            this.imageList1.Images.SetKeyName(5, "c++L.png");
            this.imageList1.Images.SetKeyName(6, "codeL.png");
            this.imageList1.Images.SetKeyName(7, "csL.png");
            this.imageList1.Images.SetKeyName(8, "cssL.png");
            this.imageList1.Images.SetKeyName(9, "dllL.png");
            this.imageList1.Images.SetKeyName(10, "exeL.png");
            this.imageList1.Images.SetKeyName(11, "folderL.png");
            this.imageList1.Images.SetKeyName(12, "gifL.png");
            this.imageList1.Images.SetKeyName(13, "htmlL.png");
            this.imageList1.Images.SetKeyName(14, "jpgL.png");
            this.imageList1.Images.SetKeyName(15, "jsL.png");
            this.imageList1.Images.SetKeyName(16, "jspL.png");
            this.imageList1.Images.SetKeyName(17, "movL.png");
            this.imageList1.Images.SetKeyName(18, "mp3L.png");
            this.imageList1.Images.SetKeyName(19, "mysqlL.png");
            this.imageList1.Images.SetKeyName(20, "pdfL.png");
            this.imageList1.Images.SetKeyName(21, "pngL.png");
            this.imageList1.Images.SetKeyName(22, "pptL.png");
            this.imageList1.Images.SetKeyName(23, "pyL.png");
            this.imageList1.Images.SetKeyName(24, "rarL.png");
            this.imageList1.Images.SetKeyName(25, "sqlL.png");
            this.imageList1.Images.SetKeyName(26, "txtL.png");
            this.imageList1.Images.SetKeyName(27, "wavl.png");
            this.imageList1.Images.SetKeyName(28, "wmaL.png");
            this.imageList1.Images.SetKeyName(29, "wordL.png");
            this.imageList1.Images.SetKeyName(30, "xamlL.png");
            this.imageList1.Images.SetKeyName(31, "xlsL.png");
            this.imageList1.Images.SetKeyName(32, "xmlL.png");
            this.imageList1.Images.SetKeyName(33, "zipL.png");
            // 
            // listView_show
            // 
            this.listView_show.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_show.Location = new System.Drawing.Point(250, 118);
            this.listView_show.Name = "listView_show";
            this.listView_show.Size = new System.Drawing.Size(622, 269);
            this.listView_show.TabIndex = 3;
            this.listView_show.UseCompatibleStateImageBehavior = false;
            this.listView_show.View = System.Windows.Forms.View.List;
            this.listView_show.SelectedIndexChanged += new System.EventHandler(this.listView_show_SelectedIndexChanged_1);
            // 
            // button_back
            // 
            this.button_back.BackColor = System.Drawing.Color.Transparent;
            this.button_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_back.FlatAppearance.BorderSize = 0;
            this.button_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back.Font = new System.Drawing.Font("Bodoni MT Condensed", 12F);
            this.button_back.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_back.Image = ((System.Drawing.Image)(resources.GetObject("button_back.Image")));
            this.button_back.Location = new System.Drawing.Point(468, 45);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(76, 67);
            this.button_back.TabIndex = 4;
            this.button_back.Text = "Back";
            this.button_back.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_back.UseVisualStyleBackColor = false;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // richTextBox_txtShow
            // 
            this.richTextBox_txtShow.Font = new System.Drawing.Font("Consolas", 12F);
            this.richTextBox_txtShow.Location = new System.Drawing.Point(250, 393);
            this.richTextBox_txtShow.Name = "richTextBox_txtShow";
            this.richTextBox_txtShow.Size = new System.Drawing.Size(622, 288);
            this.richTextBox_txtShow.TabIndex = 5;
            this.richTextBox_txtShow.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(398, 393);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(324, 286);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // button_copy
            // 
            this.button_copy.FlatAppearance.BorderSize = 0;
            this.button_copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_copy.Font = new System.Drawing.Font("Bodoni MT Condensed", 12F);
            this.button_copy.Image = ((System.Drawing.Image)(resources.GetObject("button_copy.Image")));
            this.button_copy.Location = new System.Drawing.Point(550, 45);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(76, 67);
            this.button_copy.TabIndex = 7;
            this.button_copy.Text = "Copy";
            this.button_copy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_copy.UseVisualStyleBackColor = false;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // button_cut
            // 
            this.button_cut.FlatAppearance.BorderSize = 0;
            this.button_cut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cut.Font = new System.Drawing.Font("Bodoni MT Condensed", 12F);
            this.button_cut.Image = ((System.Drawing.Image)(resources.GetObject("button_cut.Image")));
            this.button_cut.Location = new System.Drawing.Point(632, 45);
            this.button_cut.Name = "button_cut";
            this.button_cut.Size = new System.Drawing.Size(76, 67);
            this.button_cut.TabIndex = 8;
            this.button_cut.Text = "Cut";
            this.button_cut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_cut.UseVisualStyleBackColor = false;
            this.button_cut.Click += new System.EventHandler(this.button_cut_Click);
            // 
            // button_parse
            // 
            this.button_parse.Enabled = false;
            this.button_parse.FlatAppearance.BorderSize = 0;
            this.button_parse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_parse.Font = new System.Drawing.Font("Bodoni MT Condensed", 12F);
            this.button_parse.Image = ((System.Drawing.Image)(resources.GetObject("button_parse.Image")));
            this.button_parse.Location = new System.Drawing.Point(714, 45);
            this.button_parse.Name = "button_parse";
            this.button_parse.Size = new System.Drawing.Size(76, 67);
            this.button_parse.TabIndex = 9;
            this.button_parse.Text = "Paste";
            this.button_parse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_parse.UseVisualStyleBackColor = false;
            this.button_parse.Click += new System.EventHandler(this.button_parse_Click);
            // 
            // button_delete
            // 
            this.button_delete.FlatAppearance.BorderSize = 0;
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete.Font = new System.Drawing.Font("Bodoni MT Condensed", 12F);
            this.button_delete.Image = ((System.Drawing.Image)(resources.GetObject("button_delete.Image")));
            this.button_delete.Location = new System.Drawing.Point(796, 45);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(76, 67);
            this.button_delete.TabIndex = 10;
            this.button_delete.Text = "Delete";
            this.button_delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 694);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(887, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.StatuUpdate);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // btn_Mini
            // 
            this.btn_Mini.Image = ((System.Drawing.Image)(resources.GetObject("btn_Mini.Image")));
            this.btn_Mini.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Mini.Location = new System.Drawing.Point(834, 3);
            this.btn_Mini.Name = "btn_Mini";
            this.btn_Mini.Size = new System.Drawing.Size(22, 25);
            this.btn_Mini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Mini.TabIndex = 15;
            this.btn_Mini.TabStop = false;
            this.btn_Mini.Click += new System.EventHandler(this.Btn_Mini_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Close.Location = new System.Drawing.Point(856, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(31, 27);
            this.btn_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Close.TabIndex = 14;
            this.btn_Close.TabStop = false;
            this.btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(887, 716);
            this.Controls.Add(this.btn_Mini);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_parse);
            this.Controls.Add(this.button_cut);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBox_txtShow);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.listView_show);
            this.Controls.Add(this.treeView_list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "资源管理器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Mini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_list;
        private System.Windows.Forms.ListView listView_show;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.RichTextBox richTextBox_txtShow;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Button button_cut;
        private System.Windows.Forms.Button button_parse;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btn_Mini;
        private System.Windows.Forms.PictureBox btn_Close;
        private System.Windows.Forms.ImageList imageList1;
    }
}

