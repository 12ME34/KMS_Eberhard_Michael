using System;
using System.Collections.Generic;
using System.Windows;

namespace KMS_Eberhard_Michael
{
    
    public partial class CustomerAccounts : Window
    {
        //Lists for the custom Orders an for multiple accounts per person
        public static List<Orders> iSendList = new List<Orders>();
        public static List<Orders> iReceivedList = new List<Orders>();
        public static List<Accounts> matchesNew = new List<Accounts>();
        MainWindow main;
        public CustomerAccounts(List<Accounts> matches, MainWindow mainWindow)
        {
            //Window will be initialized
            InitializeComponent();
            ListViewAccounts.ItemsSource=matches;
            matchesNew=matches;          
            lblCustomerID.Content = "CustomerID is: " + matchesNew[0].CustomerID;

            //Is filtering the customers list with the CustomerID to find the Customer Name nad display it am the label
            string name="";
            foreach(var item in Customers.customers)
            {
                if (item.Id == matchesNew[0].CustomerID)
                {
                    name = item.Name;
                }
            }
            lblCustomerName2.Content = "Account owner: "+name;

            main = mainWindow;
        }

        private void btnCustAccOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                iSendList.Clear();
                iReceivedList.Clear();
                int index = ListViewAccounts.SelectedIndex;               
                string match = matchesNew[index].CustomerNumber;
                //is looking for all transactions
                foreach (var det in Orders.orders)
                {
                    if (det.Sender == match)
                    {
                        iSendList.Add(det);

                    }
                    else if (det.Recepient == match)
                    {
                        iReceivedList.Add(det);
                    }

                }

                //summs amounts from all transactions
                double sumReceived = 0, sumSent = 0;
                for (int i = 0; i < iReceivedList.Count; i++)
                {
                    sumReceived += (Convert.ToDouble(iReceivedList[i].Amount) / 100);
                }

                for (int i = 0; i < iSendList.Count; i++)
                {
                    sumSent += (Convert.ToDouble(iSendList[i].Amount) / 100);
                }

                Details details = new Details(iSendList, iReceivedList, sumReceived, sumSent, this);
                details.Show();
                this.Hide();

            }
            catch
            {
                MessageBox.Show("Please choose an account");
            }                   

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Exception has to be there, otherwise the probramm will break when the Quit Button will be manipulated            
            
            try
            {                
                main.Show();                
            }
            catch
            {
                main.Close();
            }
            
        }
    }
}
