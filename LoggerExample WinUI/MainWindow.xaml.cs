using Microsoft.UI.Xaml;

namespace LoggerExample;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
    }

    private void myButton_Click(object sender, RoutedEventArgs e)
    {
        myButton.Content = "Clicked";

        var db = new ConsoleLogger();
        db.Connect("my-imaginary-database");
        db.Trace("general", "Programm button clicked", new { button = myButton.Name });

        myButton.Content += " - Logged";
    }
}
