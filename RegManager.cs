using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSpaceCashier
{
    class RegManager
    {
        //Registry
        private const string userRoot = "HKEY_CURRENT_USER";
        private const string subkey = "ClientRROCheckbox";
        private const string keyName = userRoot + "\\SOFTWARE\\" + subkey;
        private const string keyPathToWorkingFolder = "PathToWorkingFolder";
        private const string keyAutoRegSell = "AutoRegistrationSell";
        private const string keyTestMode = "TestMode";



        public static string GetPathToWorkingFolder()
        {
            string path = (string) Registry.GetValue(keyName, keyPathToWorkingFolder, "");

            if (path==null){
                path = "";
                Registry.SetValue(keyName, keyPathToWorkingFolder, path, RegistryValueKind.String);

            }

            return path;
        }

        public static void SetPathToWorkingFolder(string path)
        {
            Registry.SetValue(keyName, keyPathToWorkingFolder, path, RegistryValueKind.String);
        }

        public static bool GetAutoRegSell()
        {
            int autoReg = (int)Registry.GetValue(keyName, keyAutoRegSell, -1 );

            if (autoReg == -1)
            {
                autoReg = 1;
                Registry.SetValue(keyName, keyAutoRegSell, autoReg, RegistryValueKind.DWord);
            }
            return Convert.ToBoolean(autoReg);
        }

        public static void SetAutoRegSell(bool autoReg)
        {
            Registry.SetValue(keyName, keyAutoRegSell, Convert.ToInt32(autoReg), RegistryValueKind.DWord);
        }

        public static bool GetTestMode()
        {
            int testMode = (int)Registry.GetValue(keyName, keyTestMode, -1);

            if (testMode == -1)
            {
                testMode = 0;
                Registry.SetValue(keyName, keyTestMode, testMode, RegistryValueKind.DWord);
            }
            return Convert.ToBoolean(testMode);
        }

        public static void SetTestMode(bool testMode)
        {
            Registry.SetValue(keyName, keyTestMode, Convert.ToInt32(testMode), RegistryValueKind.DWord);
        }




    }
}
