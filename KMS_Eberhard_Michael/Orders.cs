using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS_Eberhard_Michael
{
    public class Orders
    {
        public static List<Orders> orders = new List<Orders>();

        public Orders(string sender, string recepient, string cause, string amount, string date)
        {
            Sender = sender;
            Recepient = recepient;
            Cause = cause;
            Amount = amount;
            Date = date;
        }

        public string Sender { get; set; }
        public string Recepient { get; set; }
        public string Cause { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }


        public static void LoadOrders(string filePath)
        {
            string totalFilePath = filePath + "\\Buchungen.csv";
            StreamReader sr = new StreamReader(totalFilePath);

            List<string> allCustomerData = File.ReadAllLines(totalFilePath).Skip(1).ToList();
            sr.Close();

            foreach (string file in allCustomerData)
            {

                string[] entries = file.Split(',');

                orders.Add(new Orders(entries[0], entries[1], entries[2], entries[3], entries[4]));

            }
        }
    }
}
