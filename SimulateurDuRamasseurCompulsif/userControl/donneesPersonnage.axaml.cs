using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using System.IO;
using Avalonia.Input;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class donneesPersonnage : UserControl {

    public donneesPersonnage() {
        InitializeComponent();
        gererBoutonConfirmer();
        affichageRace();
        affichageClasse();
        nbHP.Text = $"{DonneesTemporaires.hp} HP";
        nbOr.Text = $"{DonneesTemporaires.or} Or";
        
        txtNomJoueur.Text = DonneesTemporaires.nomJoueur;
        photoProfilDefaut();
    }

    public void gererBoutonConfirmer() {
        
        bool genreChecked = false;
        bool titreRempli = false;
        string contenuTitre = titreHonorifique.Text;
        
        if (Femme.IsChecked == true || Homme.IsChecked == true || Troll.IsChecked == true) {
            genreChecked = true;
        }

        if (!string.IsNullOrWhiteSpace(contenuTitre)) {
            titreRempli = true;
        }

        if (genreChecked == true && titreRempli == true) {
            confirmerIdentite.IsEnabled = true;
        } else {
            confirmerIdentite.IsEnabled = false;
        }
    }

    public void determinerGenre() {

        if (Femme.IsChecked == true) {
            DonneesTemporaires.genre = "Femme";
        } else if (Homme.IsChecked == true) {
            DonneesTemporaires.genre = "Male";
        } else if (Troll.IsChecked == true) {
            DonneesTemporaires.genre = "Troll";
        }
    }
    
    public void affichageRace() {

        if (DonneesTemporaires.choixRaceDefinitif == "Humain") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgRaces/humain_v2.png");
            imgRace.Source = new Bitmap(AssetLoader.Open(uri));
            txtRaceTalent.Text = "Volonté de fer";
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Elfe") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgRaces/elfe_v2.png");
            imgRace.Source = new Bitmap(AssetLoader.Open(uri));
            txtRaceTalent.Text = "Vision Nocturne";
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Nain") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgRaces/nain_v2.png");
            imgRace.Source = new Bitmap(AssetLoader.Open(uri));
            txtRaceTalent.Text = "Forgeron";
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Gobelin") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgRaces/gobelin_v2.png");
            imgRace.Source = new Bitmap(AssetLoader.Open(uri));
            txtRaceTalent.Text = "Pillard";
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Fée") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgRaces/fee_v3.png");
            imgRace.Source = new Bitmap(AssetLoader.Open(uri));
            txtRaceTalent.Text = "Providence Ailée";
        }
        txtRaceNom.Text = DonneesTemporaires.choixRaceDefinitif;

    }

    public void affichageClasse() {

        if (DonneesTemporaires.choixClasseDefinitif == "Guerrier") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgClasses/guerrier_v1.png");
            imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
            txtClasseTalent.Text = "Cri de guerre";
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Mage") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgClasses/mage_v1.png");
            imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
            txtClasseTalent.Text = "Champs de force";
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Voleur") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgClasses/voleur_v2.png");
            imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
            txtClasseTalent.Text = "Festin de l'ombre";
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Alchimiste") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgClasses/alchimiste_v1.png");
            imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
            txtClasseTalent.Text = "La fiole de Schrödinger";
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Troubadour") {
            var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgClasses/troubadour_v1.png");
            imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
            txtClasseTalent.Text = "Concerto des Cieux";
        }
        txtClasseNom.Text = DonneesTemporaires.choixClasseDefinitif;
    }

    public void photoProfilDefaut() {
        var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/defaultPP.png");
        var bitmap = new Bitmap(AssetLoader.Open(uri));
        imgAvatarJoueur.Source = bitmap;
        DonneesTemporaires.photoProfil = bitmap;
    }

    public async void onImporterPpClick(object? sender, RoutedEventArgs e) {
        var explorateurFichier = TopLevel.GetTopLevel(this);
        var fichierChoisi = await explorateurFichier.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions{});
        
        if (fichierChoisi.Count >= 1) {
            var imgFinale = fichierChoisi[0];
            
            using (var stream = await imgFinale.OpenReadAsync()) {
                var bitmap = new Bitmap(stream);
                imgAvatarJoueur.Source = bitmap;
                DonneesTemporaires.photoProfil = bitmap;
            }
        }
    }

    public void OnAleatoireClick(object? sender, RoutedEventArgs e) {

        string[] titresHonorifiques = {
            "Le Sherpa officiel à durée déterminée",
            "L'aimant à ennui",
            "Le fléau des pots de fleur",
            "Le cauchemar des aubergistes",
            "La légende (dans sa tête)",
            "L'expert en fuite tactique",
            "L'ami des rats",
            "Le porteur de poisse",
            "Le couteau le moins aiguisé du tiroir",
            "Le collectionneur de cailloux",
            "Le héros par intérim",
            "Le délégoat de la B2-B"
        };
        
        Random rng = new Random();
        int titreAleatoire = rng.Next(0, titresHonorifiques.Length);
        titreHonorifique.Text = titresHonorifiques[titreAleatoire];
        gererBoutonConfirmer();
    }
    
    private void verifierConditions_Event(object? sender, RoutedEventArgs e) {
        gererBoutonConfirmer();
    }
    
    public void verifierConditions_KeyUp(object? sender, KeyEventArgs keyEventArgs) {
        gererBoutonConfirmer();
    }
    
    public void onRetourClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixClasse();
        }
    }
    
    public void onValiderClick(object? sender, RoutedEventArgs e) {
        
        determinerGenre();
        DonneesTemporaires.titreHonorifique = titreHonorifique.Text;
        
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new competences();
        }
    }
}