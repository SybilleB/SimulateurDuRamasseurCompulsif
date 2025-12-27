using Avalonia.Controls;
using Avalonia.Interactivity;
using SimulateurDuRamasseurCompulsif.userControl;

namespace SimulateurDuRamasseurCompulsif;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    private void BoutonCommencer_OnClickCommencerClick(object? sender, RoutedEventArgs e) {
        ecranTitre.Content = new saisieNomJoueur();
    }
}