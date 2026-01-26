using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class chargerPersonnage : UserControl
{
    public chargerPersonnage()
    {
        InitializeComponent();
    }

    private void onRetourClick(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow) {
            mainWindow.ecranTitre.Content = new menuEcranTitre();
        }
    }

    private void OnJouerClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}