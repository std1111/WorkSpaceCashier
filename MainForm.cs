﻿using System;
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
        private static string pathToIniFile = Application.StartupPath + "\\INI\\Settings.ini";
        private INIManager iniManager;
        private string workingFolder;


        public MainForm()
        {
            InitializeComponent();
            iniManager = new INIManager(pathToIniFile);
        }

        private void btnShifts_Click(object sender, EventArgs e)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", @"/C python.exe C:/Users/Home/PycharmProjects/UUID/SigninCashier.py > H:\RRO_Exchange\log.log");//+ textBoxInputCommand.Text
            procStartInfo.WorkingDirectory = @"c:\";
            procStartInfo.RedirectStandardOutput = true;
            //procStartInfo.UseShellExecute = true;
            procStartInfo.UseShellExecute = false;
            Process proc = new Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            string result = proc.StandardOutput.ReadToEnd();
            richTextBoxCommandOutput.Text += "dfdfd";
        }


        private async void btnSigninCashier_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            controller.WorkingFolder = this.workingFolder;
            await controller.Post_SignIn_Cashier_CheckBoxAPI();
            foreach (var str in controller.ResultText)
            {
                richTextBoxCommandOutput.AppendText(str);
            }
       
      
        }

        private void btnPathWorkFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                tbPathToWorkFolder.Text = fbd.SelectedPath;
            workingFolder = fbd.SelectedPath;
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
    }
}
