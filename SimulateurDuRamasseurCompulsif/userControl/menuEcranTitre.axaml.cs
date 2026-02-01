using System;
using Avalonia.Controls;
using Avalonia.Interactivity;


namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class menuEcranTitre : UserControl {
    public menuEcranTitre() {
        InitializeComponent();
        verifierBoutons();
    }

    private void OnNouvellePartieClick(object? sender, RoutedEventArgs e) {
        MainWindow.Instance.changerEcran(new saisieNomJoueur());
    }
    
    private void OnChargerClick(object? sender, RoutedEventArgs e) {
        throw new NotImplementedException();
    }
    
    private void OnQuitterClick(object? sender, RoutedEventArgs e) {
        if (this.VisualRoot is Window mainWindow) {
            mainWindow.Close();
        }
    }

    private void verifierBoutons() {
        boutonCharger.Opacity = 0.5;
        boutonCharger.IsEnabled = false;
    }
}