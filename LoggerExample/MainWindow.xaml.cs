﻿using System.Windows;
using System.Windows.Controls;

using Gerege.Framework.Logger;

namespace LoggerExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            button.Content = "Clicked";

            DatabaseLogger db = new ConsoleLogger();
            db.Connect("my-imaginary-database");
            db.Trace("general", "Programm button clicked", new { button = button.Name });

            button.Content += " - Logged";
        }
    }
}