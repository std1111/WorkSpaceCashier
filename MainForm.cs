using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WorkSpaceCashier
{
    public partial class MainForm : Form
    {
        private static readonly string pathToIniFile = Application.StartupPath + "\\INI\\Settings.ini";
        private INIManager iniManager;
        public static string workingFolder;
        public static string pathFolderNewChecks;
        public static string pathFolderSendChecks;
        public static string pathFolderPrintChecks;

        public MainForm()
        {
            InitializeComponent();
            iniManager = new INIManager(pathToIniFile);
            workingFolder = iniManager.GetPrivateString("main", "PathToWorkFolder");
            tbPathToWorkFolder.Text = workingFolder;
            SetPaths();
        }

        private void SetPaths()
        {

            try
            {
                if (String.IsNullOrWhiteSpace(workingFolder)){
                    BtnPathWorkFolder_Click(null, null);
                    if ((String.IsNullOrWhiteSpace(workingFolder)))
                    {
                        MessageBox.Show("Не выбрана рабочая папка РРО! Процесс создания папок прерван. Приложение будет закрыто!");
                        Application.Exit();
                    }
                }


                // Determine whether the directory exists.
                    if (!Directory.Exists(workingFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(workingFolder);
                    richTextBoxCommandOutput.AppendText(String.Format("The directory {0} was created successfully at {1}. \n", workingFolder, Directory.GetCreationTime(workingFolder)));
                }
                string currFolder = DateTime.Now.ToString("yyyy-MM-dd");
                pathFolderNewChecks = Path.Combine(workingFolder, "Checks", currFolder, "New");
                pathFolderSendChecks = Path.Combine(workingFolder, "Checks", currFolder, "Send");
                pathFolderPrintChecks = Path.Combine(workingFolder, "Checks", currFolder, "Print");

                if (!Directory.Exists(pathFolderNewChecks))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathFolderNewChecks);
                    richTextBoxCommandOutput.AppendText(String.Format("The directory {0} was created successfully at {1}. \n", pathFolderNewChecks, Directory.GetCreationTime(pathFolderNewChecks)));
                }

                if (!Directory.Exists(pathFolderSendChecks))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathFolderSendChecks);
                    richTextBoxCommandOutput.AppendText(String.Format("The directory {0} was created successfully at {1}. \n", pathFolderSendChecks, Directory.GetCreationTime(pathFolderSendChecks)));
                }

                fileSystemWatcherNewChecks.Path = pathFolderNewChecks;

                if (!Directory.Exists(pathFolderPrintChecks))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathFolderPrintChecks);
                    richTextBoxCommandOutput.AppendText(String.Format("The directory {0} was created successfully at {1}. \n", pathFolderPrintChecks, Directory.GetCreationTime(pathFolderPrintChecks)));
                }

            }
            catch (Exception e)
            {
                richTextBoxCommandOutput.AppendText(String.Format("The process failed: {0}", e.ToString()));
            }
            finally { }
        }





        private void AddResultText(RichTextBox rtBox, List<string> addText)
        {
            rtBox.AppendText("-------" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "-------\n");
            foreach (var str in addText)
            {
                rtBox.AppendText(str);
            }
            richTextBoxCommandOutput.AppendText("\n");
        }

        private async void BtnSigninCashier_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            controller.WorkingFolder = tbPathToWorkFolder.Text;
            await controller.Post_SignIn_Cashier_CheckBoxAPI();
            AddResultText(richTextBoxCommandOutput, controller.ResultText);
        }

        private void BtnPathWorkFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                tbPathToWorkFolder.Text = fbd.SelectedPath;
            workingFolder = fbd.SelectedPath;
        }


        private async void BtnNewShift_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            controller.WorkingFolder = tbPathToWorkFolder.Text;
            await controller.Post_OpenShift_CheckBoxAPI();
            AddResultText(richTextBoxCommandOutput, controller.ResultText);
        }

        private async void BtnInfoShift_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            controller.WorkingFolder = tbPathToWorkFolder.Text;
            await controller.Get_InfoShift_CheckBoxAPI();
            AddResultText(richTextBoxCommandOutput, controller.ResultText);
        }

        private async void BtnCloseShift_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            controller.WorkingFolder = tbPathToWorkFolder.Text;
            await controller.Post_CloseShift_CheckBoxAPI();
            AddResultText(richTextBoxCommandOutput, controller.ResultText);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tbPathToWorkFolder.Text = iniManager.GetPrivateString("main", "PathToWorkFolder");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {     
            iniManager.WritePrivateString("main", "PathToWorkFolder", tbPathToWorkFolder.Text);
        }

        private void fileSystemWatcherNewChecks_Created(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            MessageBox.Show(value);
            string message = "Зарегистрировать чек в системе Checkbox?";
            string caption = "Получен чек для регистрации";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                MessageBox.Show("Регистрируем чек!");
            }



        }
    }
}
