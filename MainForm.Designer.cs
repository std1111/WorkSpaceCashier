namespace WorkSpaceCashier
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSigninCashier = new System.Windows.Forms.Button();
            this.btnNewShift = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.richTextBoxCommandOutput = new System.Windows.Forms.RichTextBox();
            this.btnPathWorkFolder = new System.Windows.Forms.Button();
            this.tbPathToWorkFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBoxAutoRegChecks = new System.Windows.Forms.CheckBox();
            this.checkBoxTestServer = new System.Windows.Forms.CheckBox();
            this.BtnCloseShift = new System.Windows.Forms.Button();
            this.BtnInfoShift = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fileSystemWatcherNewChecks = new System.IO.FileSystemWatcher();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcherServiceDIR = new System.IO.FileSystemWatcher();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherNewChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherServiceDIR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSigninCashier
            // 
            this.btnSigninCashier.BackColor = System.Drawing.SystemColors.Control;
            this.btnSigninCashier.Location = new System.Drawing.Point(4, 5);
            this.btnSigninCashier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSigninCashier.Name = "btnSigninCashier";
            this.btnSigninCashier.Size = new System.Drawing.Size(194, 30);
            this.btnSigninCashier.TabIndex = 0;
            this.btnSigninCashier.Text = "Вхід користувача(касира)";
            this.btnSigninCashier.UseVisualStyleBackColor = false;
            this.btnSigninCashier.Click += new System.EventHandler(this.BtnSigninCashier_Click);
            // 
            // btnNewShift
            // 
            this.btnNewShift.Location = new System.Drawing.Point(4, 40);
            this.btnNewShift.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewShift.Name = "btnNewShift";
            this.btnNewShift.Size = new System.Drawing.Size(194, 30);
            this.btnNewShift.TabIndex = 1;
            this.btnNewShift.Text = " Відкриття нової зміни користувачем (касиром)";
            this.btnNewShift.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnNewShift.UseVisualStyleBackColor = true;
            this.btnNewShift.Click += new System.EventHandler(this.BtnNewShift_Click);
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.SystemColors.Info;
            this.btnSell.Location = new System.Drawing.Point(214, 65);
            this.btnSell.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(194, 75);
            this.btnSell.TabIndex = 2;
            this.btnSell.Text = "Створення чеку продажу, його фіскалізація та доставка клієнту по email";
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // richTextBoxCommandOutput
            // 
            this.richTextBoxCommandOutput.Location = new System.Drawing.Point(4, 158);
            this.richTextBoxCommandOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxCommandOutput.Name = "richTextBoxCommandOutput";
            this.richTextBoxCommandOutput.Size = new System.Drawing.Size(415, 166);
            this.richTextBoxCommandOutput.TabIndex = 3;
            this.richTextBoxCommandOutput.Text = "";
            // 
            // btnPathWorkFolder
            // 
            this.btnPathWorkFolder.Location = new System.Drawing.Point(355, 11);
            this.btnPathWorkFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPathWorkFolder.Name = "btnPathWorkFolder";
            this.btnPathWorkFolder.Size = new System.Drawing.Size(61, 22);
            this.btnPathWorkFolder.TabIndex = 4;
            this.btnPathWorkFolder.Text = "Выбрать";
            this.btnPathWorkFolder.UseVisualStyleBackColor = true;
            this.btnPathWorkFolder.Click += new System.EventHandler(this.BtnPathWorkFolder_Click);
            // 
            // tbPathToWorkFolder
            // 
            this.tbPathToWorkFolder.Location = new System.Drawing.Point(100, 13);
            this.tbPathToWorkFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPathToWorkFolder.Name = "tbPathToWorkFolder";
            this.tbPathToWorkFolder.ReadOnly = true;
            this.tbPathToWorkFolder.Size = new System.Drawing.Size(251, 20);
            this.tbPathToWorkFolder.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Рабочая папка";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 353);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.checkBoxAutoRegChecks);
            this.tabPage1.Controls.Add(this.checkBoxTestServer);
            this.tabPage1.Controls.Add(this.BtnCloseShift);
            this.tabPage1.Controls.Add(this.BtnInfoShift);
            this.tabPage1.Controls.Add(this.btnSigninCashier);
            this.tabPage1.Controls.Add(this.richTextBoxCommandOutput);
            this.tabPage1.Controls.Add(this.btnNewShift);
            this.tabPage1.Controls.Add(this.btnSell);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(424, 327);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Рабочее место";
            // 
            // checkBoxAutoRegChecks
            // 
            this.checkBoxAutoRegChecks.AutoSize = true;
            this.checkBoxAutoRegChecks.Location = new System.Drawing.Point(214, 40);
            this.checkBoxAutoRegChecks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxAutoRegChecks.Name = "checkBoxAutoRegChecks";
            this.checkBoxAutoRegChecks.Size = new System.Drawing.Size(210, 19);
            this.checkBoxAutoRegChecks.TabIndex = 7;
            this.checkBoxAutoRegChecks.Text = "Режим авторегистрации чеков";
            this.checkBoxAutoRegChecks.UseVisualStyleBackColor = true;
            this.checkBoxAutoRegChecks.CheckedChanged += new System.EventHandler(this.checkBoxAutoRegChecks_CheckedChanged);
            // 
            // checkBoxTestServer
            // 
            this.checkBoxTestServer.AutoSize = true;
            this.checkBoxTestServer.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.checkBoxTestServer.Location = new System.Drawing.Point(214, 6);
            this.checkBoxTestServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxTestServer.Name = "checkBoxTestServer";
            this.checkBoxTestServer.Size = new System.Drawing.Size(128, 19);
            this.checkBoxTestServer.TabIndex = 6;
            this.checkBoxTestServer.Text = "Тестовий сервер";
            this.checkBoxTestServer.UseVisualStyleBackColor = true;
            this.checkBoxTestServer.CheckedChanged += new System.EventHandler(this.checkBoxTestServer_CheckedChanged);
            // 
            // BtnCloseShift
            // 
            this.BtnCloseShift.Location = new System.Drawing.Point(4, 110);
            this.BtnCloseShift.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnCloseShift.Name = "BtnCloseShift";
            this.BtnCloseShift.Size = new System.Drawing.Size(194, 30);
            this.BtnCloseShift.TabIndex = 5;
            this.BtnCloseShift.Text = "Закриття зміни";
            this.BtnCloseShift.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnCloseShift.UseVisualStyleBackColor = true;
            this.BtnCloseShift.Click += new System.EventHandler(this.BtnCloseShift_Click);
            // 
            // BtnInfoShift
            // 
            this.BtnInfoShift.Location = new System.Drawing.Point(4, 75);
            this.BtnInfoShift.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnInfoShift.Name = "BtnInfoShift";
            this.BtnInfoShift.Size = new System.Drawing.Size(194, 30);
            this.BtnInfoShift.TabIndex = 4;
            this.BtnInfoShift.Text = "Перевірка статусу зміни";
            this.BtnInfoShift.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnInfoShift.UseVisualStyleBackColor = true;
            this.BtnInfoShift.Click += new System.EventHandler(this.BtnInfoShift_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tbPathToWorkFolder);
            this.tabPage2.Controls.Add(this.btnPathWorkFolder);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(424, 327);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки";
            // 
            // fileSystemWatcherNewChecks
            // 
            this.fileSystemWatcherNewChecks.EnableRaisingEvents = true;
            this.fileSystemWatcherNewChecks.Filter = "*.json";
            this.fileSystemWatcherNewChecks.SynchronizingObject = this;
            this.fileSystemWatcherNewChecks.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcherNewChecks_Created);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileSystemWatcherServiceDIR
            // 
            this.fileSystemWatcherServiceDIR.EnableRaisingEvents = true;
            this.fileSystemWatcherServiceDIR.SynchronizingObject = this;
            this.fileSystemWatcherServiceDIR.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcherServiceDIR_Created);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(452, 366);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рабочее место РРО";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherNewChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherServiceDIR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSigninCashier;
        private System.Windows.Forms.Button btnNewShift;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.RichTextBox richTextBoxCommandOutput;
        private System.Windows.Forms.Button btnPathWorkFolder;
        private System.Windows.Forms.TextBox tbPathToWorkFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnCloseShift;
        private System.Windows.Forms.Button BtnInfoShift;
        private System.IO.FileSystemWatcher fileSystemWatcherNewChecks;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBoxTestServer;
        private System.Windows.Forms.CheckBox checkBoxAutoRegChecks;
        private System.IO.FileSystemWatcher fileSystemWatcherServiceDIR;
    }
}

