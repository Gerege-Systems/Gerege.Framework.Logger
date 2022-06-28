namespace LoggerExample;

/////// date: 2022.01.29 //////////
///// author: Narankhuu ///////////
//// contact: codesaur@gmail.com //

using System.Windows;
using System.Windows.Controls;

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

        var db = new ConsoleLogger();
        db.Connect("my-imaginary-database");
        db.Trace("general", "Programm button clicked", new { button = button.Name });

        button.Content += " - Logged";
    }
}
