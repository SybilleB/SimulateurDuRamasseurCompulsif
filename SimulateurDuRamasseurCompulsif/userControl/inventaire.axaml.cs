using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SimulateurDuRamasseurCompulsif.Classes;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class inventaire : UserControl {
    
    public string nomJoueur;
    public string choixRaceDefinitif;
    public string choixClasseDefinitif;
    public string genre;
    
    public inventaire() {
        InitializeComponent();
        imgAvatarJoueur.Source = DonneesTemporaires.photoProfil;
        txtNomJoueur.Text = DonneesTemporaires.nomJoueur;
        titreHonorifique.Text = DonneesTemporaires.titreHonorifique;
    }
    
    public void onRetourClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new competences();
        }
    }
}