using Avalonia.Controls;
using Avalonia.Interactivity;


namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class saisieNomJoueur : UserControl {
    public saisieNomJoueur() {
        InitializeComponent();
        verifierNom();
    }

    public void onConfirmerNomClick(object? sender, RoutedEventArgs e) {
        DonneesTemporaires.nomJoueur = inputNomJoueur.Text;
        MainWindow.Instance.changerEcran(new choixRace());
    }
    public void verifierNom() {
        if (string.IsNullOrWhiteSpace(inputNomJoueur.Text)) {
            boutonConfirmer.IsEnabled = false;
        } else {
            boutonConfirmer.IsEnabled = true;
        }
    }
    
    public void OnTextChanged(object? sender, TextChangedEventArgs e) {
        verifierNom();
    }

    public void onRetourClick(object? sender, RoutedEventArgs e) {
        MainWindow.Instance.changerEcran(new menuEcranTitre());
    }
}
