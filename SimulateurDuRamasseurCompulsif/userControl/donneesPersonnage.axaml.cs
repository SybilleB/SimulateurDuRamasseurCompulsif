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
    public string genre;
    
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

    public void determinerGenre() {
        var femmeChoisi = this.FindControl<RadioButton>("Femme");
        var hommeChoisi = this.FindControl<RadioButton>("Homme");
        var trollChoisi = this.FindControl<RadioButton>("Troll");

        if (femmeChoisi.IsChecked == true) {
            genre = "Femme";
        } else if (hommeChoisi.IsChecked == true) {
            genre = "Male";
        } else if (trollChoisi.IsChecked == true) {
            genre = "Troll";
        }
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

    private void onRetourClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixClasse(nomJoueur, choixRaceDefinitif);
        }
    }

    private void onValiderClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new competences(nomJoueur, choixRaceDefinitif, choixClasseDefinitif, genre);
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

    private void OnAleatoireClick(object? sender, RoutedEventArgs e) {

        Random rng = new Random();
        int nbAleatoire = rng.Next(1,13);
        var titreHonorifique = this.FindControl<TextBox>("titreHonorifique");
        
        if (nbAleatoire == 1) {
            titreHonorifique.Text = "L'aimant à ennui";
        } else if (nbAleatoire == 2) {
            titreHonorifique.Text = "Le fléau des pots de fleur";
        } else if (nbAleatoire == 3) {
            titreHonorifique.Text = "Le cauchemar des aubergistes";
        } else if (nbAleatoire == 4) {
            titreHonorifique.Text = "La légende (dans sa tête)";
        } else if (nbAleatoire == 5) {
            titreHonorifique.Text = "Le porteur de sac officiel";
        } else if (nbAleatoire == 6) {
            titreHonorifique.Text = "L'expert en fuite tactique";
        } else if (nbAleatoire == 7) {
            titreHonorifique.Text = "L'ami des rats";
        } else if (nbAleatoire == 8) {
            titreHonorifique.Text = "Le porteur de poisse";
        } else if (nbAleatoire == 9) {
            titreHonorifique.Text = "Le couteau le moins aiguisé du tiroir";
        } else if (nbAleatoire == 10) {
            titreHonorifique.Text = "Le collectionneur de cailloux";
        } else if (nbAleatoire == 11) {
            titreHonorifique.Text = "Le héros par intérim";
        } else if (nbAleatoire == 12) {
            titreHonorifique.Text = "Le délégoat de la B2B";
        }
    }
}