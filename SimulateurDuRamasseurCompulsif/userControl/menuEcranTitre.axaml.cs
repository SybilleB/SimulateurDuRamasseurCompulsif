using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class menuEcranTitre : UserControl
{
    public menuEcranTitre() {
        InitializeComponent();
        verifierBoutons();
    }

    private void OnNouvellePartieClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new saisieNomJoueur();
        }
    }

    private void OnChargerClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new chargerPersonnage();
        }
    }

    private void OnQuitterClick(object? sender, RoutedEventArgs e) {
        if (this.VisualRoot is Window mainWindow) {
            mainWindow.Close();
        }
    }

    private void verifierBoutons() {
        //boutonCharger.Opacity = 0.5;
        //boutonCharger.IsEnabled = false;
    }
}