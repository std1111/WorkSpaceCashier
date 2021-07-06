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
            this.btnSigninCashier = new System.Windows.Forms.Button();
            this.btnShifts = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.richTextBoxCommandOutput = new System.Windows.Forms.RichTextBox();
            this.btnPathWorkFolder = new System.Windows.Forms.Button();
            this.tbPathToWorkFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSigninCashier
            // 
            this.btnSigninCashier.BackColor = System.Drawing.SystemColors.Control;
            this.btnSigninCashier.Location = new System.Drawing.Point(6, 6);
            this.btnSigninCashier.Name = "btnSigninCashier";
            this.btnSigninCashier.Size = new System.Drawing.Size(259, 37);
            this.btnSigninCashier.TabIndex = 0;
            this.btnSigninCashier.Text = "Вхід користувача(касира)";
            this.btnSigninCashier.UseVisualStyleBackColor = false;
            this.btnSigninCashier.Click += new System.EventHandler(this.btnSigninCashier_Click);
            // 
            // btnShifts
            // 
            this.btnShifts.Location = new System.Drawing.Point(6, 49);
            this.btnShifts.Name = "btnShifts";
            this.btnShifts.Size = new System.Drawing.Size(259, 37);
            this.btnShifts.TabIndex = 1;
            this.btnShifts.Text = " Відкриття нової зміни користувачем (касиром)";
            this.btnShifts.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnShifts.UseVisualStyleBackColor = true;
            this.btnShifts.Click += new System.EventHandler(this.btnShifts_Click);
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.SystemColors.Info;
            this.btnSell.Location = new System.Drawing.Point(6, 92);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(259, 92);
            this.btnSell.TabIndex = 2;
            this.btnSell.Text = "Створення чеку продажу, його фіскалізація та доставка клієнту по email";
            this.btnSell.UseVisualStyleBackColor = false;
            // 
            // richTextBoxCommandOutput
            // 
            this.richTextBoxCommandOutput.Location = new System.Drawing.Point(271, 6);
            this.richTextBoxCommandOutput.Name = "richTextBoxCommandOutput";
            this.richTextBoxCommandOutput.Size = new System.Drawing.Size(391, 393);
            this.richTextBoxCommandOutput.TabIndex = 3;
            this.richTextBoxCommandOutput.Text = "";
            this.richTextBoxCommandOutput.TextChanged += new System.EventHandler(this.richTextBoxCommandOutput_TextChanged);
            // 
            // btnPathWorkFolder
            // 
            this.btnPathWorkFolder.Location = new System.Drawing.Point(473, 14);
            this.btnPathWorkFolder.Name = "btnPathWorkFolder";
            this.btnPathWorkFolder.Size = new System.Drawing.Size(81, 27);
            this.btnPathWorkFolder.TabIndex = 4;
            this.btnPathWorkFolder.Text = "Выбрать";
            this.btnPathWorkFolder.UseVisualStyleBackColor = true;
            this.btnPathWorkFolder.Click += new System.EventHandler(this.btnPathWorkFolder_Click);
            // 
            // tbPathToWorkFolder
            // 
            this.tbPathToWorkFolder.Location = new System.Drawing.Point(134, 16);
            this.tbPathToWorkFolder.Name = "tbPathToWorkFolder";
            this.tbPathToWorkFolder.Size = new System.Drawing.Size(333, 22);
            this.tbPathToWorkFolder.TabIndex = 5;
            this.tbPathToWorkFolder.TextChanged += new System.EventHandler(this.tbPathToWorkFolder_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Рабочая папка";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(676, 434);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.btnSigninCashier);
            this.tabPage1.Controls.Add(this.richTextBoxCommandOutput);
            this.tabPage1.Controls.Add(this.btnShifts);
            this.tabPage1.Controls.Add(this.btnSell);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(668, 405);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Рабочее место";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tbPathToWorkFolder);
            this.tabPage2.Controls.Add(this.btnPathWorkFolder);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(567, 405);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Рабочее место РРО";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSigninCashier;
        private System.Windows.Forms.Button btnShifts;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.RichTextBox richTextBoxCommandOutput;
        private System.Windows.Forms.Button btnPathWorkFolder;
        private System.Windows.Forms.TextBox tbPathToWorkFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

