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
using Newtonsoft.Json;
using System.Globalization;

namespace WorkSpaceCashier
{
    public partial class MainForm : Form
    {
        public static string workingFolder;   
        public static bool autoRegMode;
        public static string pathFolderNewChecks;
        public static string pathFolderSendChecks;
        public static string pathFolderPrintChecks;
        public static string pathFolderServiceDir;

        public bool testMode;
        private Controller controller;

       
        public MainForm()
        {
            InitializeComponent();

            workingFolder = RegManager.GetPathToWorkingFolder();
            this.controller = new Controller(workingFolder);
            tbPathToWorkFolder.Text = workingFolder;

            this.testMode = RegManager.GetTestMode();       
            this.controller.TestMode = this.testMode;        
            checkBoxTestServer.Checked = this.testMode;

            autoRegMode = RegManager.GetAutoRegSell();
            checkBoxAutoRegChecks.Checked = autoRegMode;
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
                pathFolderServiceDir = Path.Combine(workingFolder, "ServiceDIR");
                if (!Directory.Exists(pathFolderServiceDir))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathFolderServiceDir);
                    richTextBoxCommandOutput.AppendText(String.Format("The service directory {0} was created successfully at {1}. \n", pathFolderServiceDir, Directory.GetCreationTime(pathFolderServiceDir)));
                }
                fileSystemWatcherServiceDIR.Path = pathFolderServiceDir;

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

            richTextBoxCommandOutput.SelectionStart = richTextBoxCommandOutput.TextLength;
            richTextBoxCommandOutput.ScrollToCaret();

        }

        private async void BtnSigninCashier_Click(object sender, EventArgs e)
        {          
            await this.controller.Post_SignIn_Cashier_CheckBoxAPI();
            AddResultText(richTextBoxCommandOutput, controller.ResultText);
        }

        private void BtnPathWorkFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                tbPathToWorkFolder.Text = fbd.SelectedPath;
            workingFolder = fbd.SelectedPath;
            RegManager.SetPathToWorkingFolder(workingFolder);
        }


        private async void BtnNewShift_Click(object sender, EventArgs e)
        {
            await this.controller.Post_OpenShift_CheckBoxAPI();
            AddResultText(richTextBoxCommandOutput, controller.ResultText);
        }

        private async void BtnInfoShift_Click(object sender, EventArgs e)
        {

            await this.controller.Get_InfoShift_CheckBoxAPI();
            AddResultText(richTextBoxCommandOutput, controller.ResultText);
        }

        private async void BtnCloseShift_Click(object sender, EventArgs e)
        {
            await this.controller.Post_CloseShift_CheckBoxAPI();
            AddResultText(richTextBoxCommandOutput, controller.ResultText);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //tbPathToWorkFolder.Text = iniManager.GetPrivateString("main", "PathToWorkFolder");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegManager.SetPathToWorkingFolder(tbPathToWorkFolder.Text);
        }


        private async void RegistartionSell(string pathToFile, List<string> result)
        {
            await this.controller.Post_Sell__CheckBoxAPI(pathToFile);
            AddResultText(richTextBoxCommandOutput, controller.ResultText);
            result =  controller.ResultText;
        }


        private async void GetNewCheck(string pathToFile)
        {
            if (autoRegMode)
            {
                List<string> res= new List<string>();
                RegistartionSell(pathToFile, res);
                AddResultText(richTextBoxCommandOutput, res);

            } else {
                    string strInfo = Controller.GetInfoFromJsonCheckFile(pathToFile);

                    string message = "Зарегистрировать чек в системе Checkbox?\n" + strInfo;
                    string caption = "Получен чек для регистрации";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Closes the parent form.
                        MessageBox.Show("Регистрируем чек!");
                        List<string> res = new List<string>();
                        RegistartionSell(pathToFile, res);
                        AddResultText(richTextBoxCommandOutput, res);
                }
            }
        }



        private async void fileSystemWatcherNewChecks_Created(object sender, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            GetNewCheck(e.FullPath);
        }

        private async void btnSell_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файл обмена (*.json)|*.json|All files(*.*)|*.*";
            openFileDialog1.InitialDirectory = pathFolderNewChecks;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            GetNewCheck(filename);

        }



        private void checkBoxTestServer_CheckedChanged(object sender, EventArgs e)
        {
            testMode = checkBoxTestServer.Checked;
            RegManager.SetTestMode(testMode);
            this.controller.TestMode = this.testMode;
        }

        private void checkBoxAutoRegChecks_CheckedChanged(object sender, EventArgs e)
        {
            autoRegMode = checkBoxAutoRegChecks.Checked;
            RegManager.SetAutoRegSell(autoRegMode);
        }

        private async void fileSystemWatcherServiceDIR_Created(object sender, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            List<string> res = new List<string>();
            res.Add("Получен запрос на получение печатной формы чека");
            AddResultText(richTextBoxCommandOutput, res);
            res.Clear();
            
            if (e.Name.Equals("GetPrintFormCheck.json")) {
                var getInfoText = File.ReadAllText(Path.Combine(e.FullPath));
                GetInfo getInfo = JsonConvert.DeserializeObject<GetInfo>(getInfoText);              
                await this.controller.Get_PrintForm_CheckBoxAPI(getInfo.id, res);
                AddResultText(richTextBoxCommandOutput, res);
            }
        }
    }
}
