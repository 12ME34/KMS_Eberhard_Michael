using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMS_Eberhard_Michael
{
    public class Customers
    {

        public static List<Customers> customers = new List<Customers>();

        public Customers(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }



        public static void LoadCustomers(string filePath)
        {


            string totalFilePath = filePath + "\\Kunden.csv";
            StreamReader sr = new StreamReader(totalFilePath);

            List<string> allCustomerData = File.ReadAllLines(totalFilePath).Skip(1).ToList();
            sr.Close();

            //BindingSource bs = new BindingSource();
            //bs.DataSource = customers;


            foreach (string file in allCustomerData)
            {

                string[] entries = file.Split(',');
                

                customers.Add(new Customers(entries[0], entries[1]));




            }



        }

    }
}
