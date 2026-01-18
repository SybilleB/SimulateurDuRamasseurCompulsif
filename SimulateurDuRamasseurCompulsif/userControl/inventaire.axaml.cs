using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SimulateurDuRamasseurCompulsif.Classes;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class inventaire : UserControl {
    public inventaire() {
        InitializeComponent();
        afficherInfosPerso();
    }

    public void afficherInfosPerso() {

        Personnage perso = DonneesTemporaires.personnageFinal;
        imgAvatarJoueur.Source = perso.photoProfil;
        txtNomJoueur.Text = perso.nomJoueur;
        titreHonorifique.Text = perso.titreHonorifique;
        
        forceInventaire.Text = $"⚔️ Force : {perso.statsPerso.force} pts";
        agiliteInventaire.Text = $"🏹 Agilité : {perso.statsPerso.agilite} pts";
        vitaliteInventaire.Text = $"💖 Vitalité : {perso.statsPerso.vitalite} pts";
        intelligenceInventaire.Text = $"📖 Intelligence : {perso.statsPerso.intelligence} pts";
        charismeInventaire.Text = $"👑️ Charisme : {perso.statsPerso.charisme} pts";
        chanceInventaire.Text = $"🎲 Chance : {perso.statsPerso.chance} pts";
    }
    
    public void onRetourClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new competences();
        }
    }

    private void onCreationPersonnageClick(object? sender, RoutedEventArgs e) {
        
    }
}