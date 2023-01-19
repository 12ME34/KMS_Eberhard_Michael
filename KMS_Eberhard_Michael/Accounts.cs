using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KMS_Eberhard_Michael
{
    public class Accounts
    {
        public static List<Accounts> accounts = new List<Accounts>();

        public Accounts(string customerID, string customerNumber)
        {
            CustomerID = customerID;
            CustomerNumber = customerNumber;
        }

        public string CustomerID { get; set; }
        public string CustomerNumber { get; set; }

        public static void LoadAccounts(string filePath)
        {
            string totalFilePath = filePath + "\\Konten.csv";
            StreamReader sr = new StreamReader(totalFilePath);

            List<string> allCustomerData = File.ReadAllLines(totalFilePath).Skip(1).ToList();
            sr.Close();


            foreach (string file in allCustomerData)
            {

                string[] entries = file.Split(',');

                accounts.Add(new Accounts(entries[0], entries[1]));

            }
        }

    }
}
