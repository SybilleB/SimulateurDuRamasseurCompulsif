using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using System.IO;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class donneesPersonnage : UserControl {
    
    public string nomJoueur;
    public string choixRaceDefinitif;
    public string choixClasseDefinitif;
    
    public donneesPersonnage() {
        InitializeComponent();
    }

    public donneesPersonnage(string _nomJoueur, string _choixRaceDefinitif, string _choixClasseDefinitif) {
        InitializeComponent();
        nomJoueur = _nomJoueur;
        choixRaceDefinitif = _choixRaceDefinitif;
        choixClasseDefinitif = _choixClasseDefinitif;
        affichageRace();
        affichageClasse();
        var txtNomJoueur = this.FindControl<TextBlock>("txtNomJoueur");
        txtNomJoueur.Text = nomJoueur;
    }

    public void affichageRace() {
        var imgRace = this.FindControl<Image>("imgRace");
        var txtRaceNom = this.FindControl<TextBlock>("txtRaceNom");
        var txtRaceTalent = this.FindControl<TextBlock>("txtRaceTalent");

        if (choixRaceDefinitif == "Humain") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/humain_v2.png");
            imgRace.Source = new Bitmap(AssetLoader.Open(uri));
            txtRaceTalent.Text = "Volonté de fer";
        }
        if (choixRaceDefinitif == "Elfe") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/elfe_v2.png");
            imgRace.Source = new Bitmap(AssetLoader.Open(uri));
            txtRaceTalent.Text = "Vision Nocturne";
        }
        if (choixRaceDefinitif == "Nain") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/nain_v2.png");
            imgRace.Source = new Bitmap(AssetLoader.Open(uri));
            txtRaceTalent.Text = "Forgeron";
        }
        if (choixRaceDefinitif == "Gobelin") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/gobelin_v2.png");
            imgRace.Source = new Bitmap(AssetLoader.Open(uri));
            txtRaceTalent.Text = "Pillard";
        }
        if (choixRaceDefinitif == "Fée") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/fee_v3.png");
            imgRace.Source = new Bitmap(AssetLoader.Open(uri));
            txtRaceTalent.Text = "Providence Ailée";
        }
        txtRaceNom.Text = choixRaceDefinitif;

    }

    public void affichageClasse() {
        var imgClasse = this.FindControl<Image>("imgClasse");
        var txtClasseNom = this.FindControl<TextBlock>("txtClasseNom");
        var txtClasseTalent = this.FindControl<TextBlock>("txtClasseTalent");

        if (choixClasseDefinitif == "Guerrier") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/guerrier_v1.png");
            imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
            txtClasseTalent.Text = "Cri de guerre";
        }
        if (choixClasseDefinitif == "Mage") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/mage_v2.png");
            imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
            txtClasseTalent.Text = "Champs de force";
        }
        if (choixClasseDefinitif == "Voleur") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/voleur_v2.png");
            imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
            txtClasseTalent.Text = "Festin de l'ombre";
        }
        if (choixClasseDefinitif == "Alchimiste") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/alchimiste_v1.png");
            imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
            txtClasseTalent.Text = "La fiole de Schrödinger";
        }
        if (choixClasseDefinitif == "Troubadour") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/troubadour_v1.png");
            imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
            txtClasseTalent.Text = "Concerto des Cieux";
        }
        txtClasseNom.Text = choixClasseDefinitif;
    }

    private void onRetourClick(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixClasse(nomJoueur, choixRaceDefinitif);
        }
    }

    private void onValiderClick(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixClasse(nomJoueur, choixRaceDefinitif);
        }
    }

    private async void onImporterPPClick(object? sender, RoutedEventArgs e) {
        var explorateurFichier = TopLevel.GetTopLevel(this);
        
        var fichierChoisi = await explorateurFichier.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions{});
        
        if (fichierChoisi.Count >= 1) {
            var imgFinale = fichierChoisi[0];
        
            using (var stream = await imgFinale.OpenReadAsync()) {
                var bitmap = new Bitmap(stream);
                var imgAvatar = this.FindControl<Image>("imgAvatarJoueur");
                imgAvatar.Source = bitmap;
            }
        }

    }
}