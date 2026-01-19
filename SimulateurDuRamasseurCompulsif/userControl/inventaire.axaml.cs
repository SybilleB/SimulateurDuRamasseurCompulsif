using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using SimulateurDuRamasseurCompulsif.Classes;
using SimulateurDuRamasseurCompulsif.Classes.Items;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class inventaire : UserControl {
    
    public inventaire() {
        InitializeComponent();
        remplirSacoche();
        afficherItems();
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

    public void creerItemAleatoire() {
        Random random = new Random();
        int rng;
        if (DonneesTemporaires.choixRaceDefinitif == "Nain") {
            rng = random.Next(1, 4);
        } else {
            rng = random.Next(0, 4);
        }
        
        if (rng == 0) {
            string b = "Commun";
            string bordercolor = "#B87333";
        }
        if (rng == 1) {
            string b = "Rare";
            string bordercolor = "#C0C0C0 (ou un gris bleuté brillant : #BDC3C7";
        }
        if (rng == 2) {
            string b = "Epique";
            string bordercolor = "#FFD700 (ou un jaune ambre riche : #F1C40F ou violet : #312244";
        }
        if (rng == 3) {
            string b = "Legendaire";
            string bordercolor = "#00FFFF (Cyan électrique pour le diamant)";
        }

        

        if (DonneesTemporaires.choixClasseDefinitif == "Guerrier")
        {
            string a = "Armure";
            
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Mage") {
            string a = "Livre";
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Voleur") {
            string a = "Bijou";
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Alchimiste") {
            string a = "Potion";
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Troubadour") {
            string a = "Instrument";
        }
        
    }
    
    
    Dictionary<string, InventaireStuff> sacoche = new Dictionary<string, InventaireStuff>();

    public void remplirSacoche() {
        sacoche.Add("item1", new InventaireStuff("Carte du Monde", "Tellement mal repliée qu'elle a créé de nouvelles montagnes et supprimé deux villages.",
            TypeItem.ObjetQuete, Rarete.Autre, "map.png"));
        
        sacoche.Add("item2", new InventaireStuff("Pain rassi", "A survécu à trois guerres, deux famines et au fond de votre sac. Le goût est en option, mais les calories sont bien là.",
            TypeItem.Consommable, Rarete.Autre, "pain.png"));
        
        sacoche.Add("item3", new InventaireStuff("Couteau à beurre", "Officiellement une arme blanche. Ne coupe absolument rien, au moins vous ne risquez pas de vous blesser en le rangeant.",
            TypeItem.Arme, Rarete.Commune, "couteau_a_beurre.png"));
        
    }

    public void afficherItems() {

        foreach (var item in sacoche) {
            
            string indexItem = item.Key;
            Border borderDisplay = this.FindControl<Border>(indexItem);
            Image imgItem = (Image)borderDisplay.Child;
            imgItem.Source=item.Value.fichierImage;
            
        }
        
        int nbItemsSacoche = sacoche.Count + 1;

        for (int i = nbItemsSacoche; i < 9; i++)
        {
            string numeroItem = "item" + i;
            Border carteInutilisee = this.FindControl<Border>(numeroItem);
            carteInutilisee.Opacity = 0.3;
            carteInutilisee.IsEnabled = false;
        }
        
    }

    private void OnItemClick(object? sender, PointerPressedEventArgs e) {
        var borderClick = sender as Border;

        if (sacoche.ContainsKey(borderClick.Name)) {
            InventaireStuff objetRecupere = sacoche[borderClick.Name];
            imgItemDetail.Source = objetRecupere.fichierImage;
            titreItemDetail.Text = objetRecupere.nomItem;
            if (objetRecupere.typeItem == TypeItem.ObjetQuete)
            {
                typeItemDetail.Text  = "Objet de quête";
            } else {
                typeItemDetail.Text = objetRecupere.typeItem.ToString();
            }
            
            descriptionItemDetail.Text = objetRecupere.descriptionItem;
            test.IsVisible = true;
            borderTypeItem.IsVisible = true;
        }
        
    }
    
    public void onRetourClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new competences();
        }
    }

    private void onCreationPersonnageClick(object? sender, RoutedEventArgs e) {
        
    }
}