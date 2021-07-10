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
        private string workingFolder;


        public MainForm()
        {
            InitializeComponent();
            iniManager = new INIManager(pathToIniFile);
            workingFolder = iniManager.GetPrivateString("main", "PathToWorkFolder");
            tbPathToWorkFolder.Text = workingFolder;
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

    }
}
