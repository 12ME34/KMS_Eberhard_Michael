using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace KMS_Eberhard_Michael
{
    internal class LoadData
    {
        public static void LoadDataFromFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string filePath=fbd.SelectedPath;
            Customers.LoadCustomers(filePath);

            Accounts.LoadAccounts(filePath);
            
            
        }
    }
}
