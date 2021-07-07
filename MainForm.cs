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



        private async void BtnSigninCashier_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            controller.WorkingFolder = tbPathToWorkFolder.Text;
            await controller.Post_SignIn_Cashier_CheckBoxAPI();
            foreach (var str in controller.ResultText)
            {
                richTextBoxCommandOutput.AppendText(str);
            }
       
      
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
            foreach (var str in controller.ResultText)
            {
                richTextBoxCommandOutput.AppendText(str);
            }


        }


        private async void BtnCloseShift_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            controller.WorkingFolder = tbPathToWorkFolder.Text;
            await controller.Post_CloseShift_CheckBoxAPI();
            foreach (var str in controller.ResultText)
            {
                richTextBoxCommandOutput.AppendText(str);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tbPathToWorkFolder.Text = iniManager.GetPrivateString("main", "PathToWorkFolder");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {     
            //if (File.Exists(pathToIniFile))
            //    MessageBox.Show("Yes");
            //else

            //    MessageBox.Show(pathToIniFile);


            //INIManager manager = new INIManager(pathToIniFile);
            //MessageBox.Show(manager.GetPrivateString("main", "PathToWorkFolder"));

            iniManager.WritePrivateString("main", "PathToWorkFolder", tbPathToWorkFolder.Text);
            
        }




        private void tbPathToWorkFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBoxCommandOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
