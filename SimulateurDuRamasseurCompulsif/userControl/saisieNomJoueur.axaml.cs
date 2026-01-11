using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class saisieNomJoueur : UserControl {
    public saisieNomJoueur() {
        InitializeComponent();
        verifierNom();
    }

    public void onConfirmerNomClick(object? sender, RoutedEventArgs e) {
        string nomJoueurChoisi = inputNomJoueur.Text;
            
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixRace(nomJoueurChoisi);
        }
    }
    public void verifierNom() {
        if (string.IsNullOrWhiteSpace(inputNomJoueur.Text)) {
            ConfirmerBouton.IsEnabled = false;
        }
        else {
            ConfirmerBouton.IsEnabled = true;
        }
    }
    public void OnTextChanged(object? sender, TextChangedEventArgs e) {
        verifierNom();
    }

    public void onRetourClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new menuEcranTitre();
        }
    }
}
