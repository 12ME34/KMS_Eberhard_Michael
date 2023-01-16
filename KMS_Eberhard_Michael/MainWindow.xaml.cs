﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace KMS_Eberhard_Michael
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        



        public MainWindow()
        {
            InitializeComponent();
            listViewMain.ItemsSource = Customers.customers;
            
        }

        
        private void btnLoadDataMain_Click(object sender, RoutedEventArgs e)
        {

            LoadData.LoadDataFromFolder();


            //foreach (var item in Customers.customers)

            //    listViewMain.Items.Add(item.Id + item.Name);

        }


        
    }
}