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
using ScheduleDataModel.Model;
using System.Collections.ObjectModel;

namespace ScheduleApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new ViewModel.MainWindow();
            InitializeComponent();            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (this.DataContext as ViewModel.MainWindow).ScheduleSelectedCommand.Execute(e.AddedItems[0]);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ViewModel.MainWindow).WindowLoadedCommand.Execute(null);
        }
    }
}
