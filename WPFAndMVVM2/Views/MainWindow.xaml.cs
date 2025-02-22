﻿using System;
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
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm;
        public MainWindow()
        {
            InitializeComponent();

            mvm = new MainViewModel();
            DataContext = mvm;
        }

        private void btnNewPerson_Click(object sender, RoutedEventArgs e)
        {
            mvm.AddDefaultPerson();
            lstBox.ScrollIntoView(lstBox.SelectedItem);
        }

        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            mvm.DeleteSelectedPerson();
        }
    }
}
