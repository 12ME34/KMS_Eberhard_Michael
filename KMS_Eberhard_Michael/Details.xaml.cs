using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;



namespace KMS_Eberhard_Michael
{  
    public partial class Details : Window
    {
        //Window Deatails will be generated
        CustomerAccounts cAccounts;
        public Details(List<Orders> iSendList, List<Orders> iReceivedList, double sumReceived, double sumSent, CustomerAccounts customerAccounts)
        {
            InitializeComponent();
            AccountOutgoings.ItemsSource=iSendList;
            AccountReceipts.ItemsSource=iReceivedList;
            int totalSent = iSendList.Count;
            int totalReceived = iReceivedList.Count;

            lblSent.Content= "Total Orders Sent: " + totalSent;
            lblReceived.Content= "Total Orders Received: " + totalReceived;            

            lblCalculation.Content = 
                "You totally received: " + "€ "+sumReceived + 
                "\nYou totally sent:        " + "€ " + sumSent + 
                "\n-------------------------------------"+
                "\nYour balance is:         " + "€ " + Math.Round(sumReceived - sumSent, 2);
            cAccounts=customerAccounts;            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "CSV file(*.csv)|*.csv|All files(*.*)|*.*";           
            

            if (saveFileDialog.ShowDialog() == true)
            {
                //Path is neccessary to adress where the document shouold be safed
                string filePath = saveFileDialog.FileName;

                using(StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    
                    streamWriter.WriteLine("--Received transactions -- \n\nSender, Recepient, Cause, Amount, Date");
                    //every item in the list iReceivedList
                    foreach (var item in CustomerAccounts.iReceivedList)
                    {
                        streamWriter.WriteLine(item.Sender + "," + item.Recepient + "," + item.Cause + "," + item.Amount + "," + item.Date);                        
                    }

                    //every item in the list iSendList
                    streamWriter.WriteLine("\n\n--Sent transactions -- \n\nSender, Recepient, Cause, Amount, Date");

                    foreach (var item in CustomerAccounts.iSendList)
                    {
                        streamWriter.WriteLine(item.Sender + "," + item.Recepient + "," + item.Cause + "," + item.Amount + "," + item.Date);                        
                    }                   
                }                
            }             
        }
        
        //Is closing the whole application
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {          
            App.Current.Shutdown();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Exception has to be there, otherwise the probramm will break when the Quit Button will be maipulated
            try
            {
                cAccounts.Show();
            }
            catch
            {
                cAccounts.Close();
            }            
        }
    }
}
