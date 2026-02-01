using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using Avalonia.Input;
using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;
using SimulateurDuRamasseurCompulsif.Classes.Items;
using SimulateurDuRamasseurCompulsif.Classes.Races;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class donneesPersonnage : UserControl {

    public donneesPersonnage() {
        InitializeComponent();
        gererBoutonConfirmer();
        affichageRace();
        affichageClasse();
        afficherItems();
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

        if (genreChecked && titreRempli) {
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
        Race raceChoisie = null;
        string nomImage = "";
        
        if (DonneesTemporaires.choixRaceDefinitif == "Humain") {
            nomImage = "humain_v2.png";
            raceChoisie = new Humain();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Elfe") {
            nomImage = "elfe_v2.png";
            raceChoisie = new Elfe();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Nain") {
            nomImage = "nain_v2.png";
            raceChoisie = new Nain();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Gobelin") {
            nomImage = "gobelin_v2.png";
            raceChoisie = new Gobelin();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Fée") {
            nomImage = "fee_v3.png";
            raceChoisie = new Fee();
        }
        txtRaceNom.Text = raceChoisie.nomRace;
        txtRaceTalent.Text = raceChoisie.talent;
        var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgRaces/{nomImage}");
        imgRace.Source = new Bitmap(AssetLoader.Open(uri));
    }

    public void affichageClasse() {
        HerosClasse classeChoisie = null;
        string nomImage = "";
        
        if (DonneesTemporaires.choixClasseDefinitif == "Guerrier") {
            nomImage = "guerrier_v1.png";
            classeChoisie = new Guerrier();
        } else if (DonneesTemporaires.choixClasseDefinitif == "Mage") {
            nomImage = "mage_v1.png";
            classeChoisie = new Mage();
        } else if (DonneesTemporaires.choixClasseDefinitif == "Voleur") {
            nomImage = "voleur_v2.png";
            classeChoisie = new Voleur();
        } else if (DonneesTemporaires.choixClasseDefinitif == "Alchimiste") {
            nomImage = "alchimiste_v1.png";
            classeChoisie = new Alchimiste();
        } else if (DonneesTemporaires.choixClasseDefinitif == "Troubadour") {
            nomImage = "troubadour_v1.png";
            classeChoisie = new Troubadour();
        }
        txtClasseNom.Text = classeChoisie.nomClasse;
        txtClasseTalent.Text = classeChoisie.talent;
        var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/imgClasses/{nomImage}");
        imgClasse.Source = new Bitmap(AssetLoader.Open(uri));
    }

    public void afficherItems() {
        string affichageNomItem = "ITEMS POSSIBLES : ";
        string nomItem = "";
        TypeItem typeItem =  TypeItem.Consommable;
        

        if (DonneesTemporaires.choixClasseDefinitif == "Guerrier") {
            nomItem = "armure";
            affichageNomItem += "Armure";
            typeItem = TypeItem.Armure;
        } else if (DonneesTemporaires.choixClasseDefinitif == "Mage") {
            nomItem = "livre";
            affichageNomItem += "Livre";
            typeItem = TypeItem.Livre;
        } else if (DonneesTemporaires.choixClasseDefinitif == "Voleur") {
            nomItem = "bijou";
            affichageNomItem += "Bijou";
            typeItem = TypeItem.Bijou;
        } else if (DonneesTemporaires.choixClasseDefinitif == "Alchimiste") {
            nomItem = "potion";
            affichageNomItem += "Potion";
            typeItem = TypeItem.Potion;
        } else if (DonneesTemporaires.choixClasseDefinitif == "Troubadour") {
            nomItem = "instrument";
            affichageNomItem += "Instrument";
            typeItem = TypeItem.Instrument;
        }
        itemsPossibles.Text = affichageNomItem;
        
        var itemCommun = new InventaireStuff("Commun", "", typeItem, Rarete.Commune, $"{nomItem}_commun.png");
        var itemRare = new InventaireStuff("Rare", "", typeItem, Rarete.Rare, $"{nomItem}_rare.png");
        var itemEpique = new InventaireStuff("Epique", "", typeItem, Rarete.Epique, $"{nomItem}_epique.png");
        var itemLegendaire = new InventaireStuff("Legendaire", "", typeItem, Rarete.Legendaire, $"{nomItem}_legendaire.png");

        if (DonneesTemporaires.choixRaceDefinitif == "Nain") {
            borderCommun.Opacity = 0.2;
            texteValeurCommun.Text = "Pas concerné";
            texteValeurRare.Text = "50% de chance";
            texteValeurEpique.Text = "33% de chance";
            texteValeurLegendaire.Text = "17% de chance";
        } else {
            texteValeurCommun.Text = "40% de chance";
            texteValeurRare.Text = "30% de chance";
            texteValeurEpique.Text = "20% de chance";
            texteValeurLegendaire.Text = "10% de chance";
        }
        
        imgItemCommun.Source = itemCommun.fichierImage;
        borderCommun.BorderBrush = itemCommun.couleurBorder;
        textCommun.Foreground = itemCommun.couleurBorder;
        
        imgItemRare.Source = itemRare.fichierImage;
        borderRare.BorderBrush = itemRare.couleurBorder;
        textRare.Foreground = itemRare.couleurBorder;
        
        imgItemEpique.Source = itemEpique.fichierImage;
        borderEpique.BorderBrush = itemEpique.couleurBorder;
        textEpique.Foreground = itemEpique.couleurBorder;
        
        imgItemLegendaire.Source = itemLegendaire.fichierImage;
        borderLegendaire.BorderBrush = itemLegendaire.couleurBorder;
        textLegendaire.Foreground = itemLegendaire.couleurBorder;
    }
    
    public void photoProfilDefaut() {
        var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/defaultPP.png");
        var bitmap = new Bitmap(AssetLoader.Open(uri));
        imgAvatarJoueur.Source = bitmap;
        DonneesTemporaires.photoProfil = bitmap;
    }

    public async void onImporterPpClick(object? sender, RoutedEventArgs e) {
        var topLevel = TopLevel.GetTopLevel(this);

        var filtresImages = new FilePickerFileType("Images (PNG, JPEG)") {
            Patterns = new[] { "*.png", "*.jpg", "*.jpeg" }
        };

        var typesImages = new FilePickerOpenOptions {
            Title = "Choisir une photo de profil",
            AllowMultiple = false, 
            FileTypeFilter = new[] { filtresImages }
        };
        
        var fichierChoisi = await topLevel.StorageProvider.OpenFilePickerAsync(typesImages);
        
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
        MainWindow.Instance.changerEcran(new choixClasse());
    }
    
    public void onValiderClick(object? sender, RoutedEventArgs e) {
        determinerGenre();
        DonneesTemporaires.titreHonorifique = titreHonorifique.Text;
        MainWindow.Instance.changerEcran(new competences());
    }
}