    using System;
    using System.Collections.Generic;
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Input;
    using Avalonia.Interactivity;
    using Avalonia.Markup.Xaml;
    using Avalonia.Media;
    using Avalonia.Media.Imaging;
    using Avalonia.Platform;
    using SimulateurDuRamasseurCompulsif.Classes;
    using SimulateurDuRamasseurCompulsif.Classes.Items;

    namespace SimulateurDuRamasseurCompulsif.userControl;

    public partial class inventaire : UserControl {
        
        public inventaire() {
            InitializeComponent();
            remplirSacoche();
            creerItemAleatoire();
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
            
            Dictionary<string, InventaireStuff> listeItems = new Dictionary<string, InventaireStuff>();
            listeItems.Add("armureCommune", new InventaireStuff("T-shirt \"J'aime ma maman\"",
                "Offre un soutien émotionnel, mais aucune protection physique", TypeItem.Armure, 
                Rarete.Commune, "armure_commune.png"));
            listeItems.Add("armureRare", new InventaireStuff("Plastron de cuir renforcé",
                "Du cuir bouilli avec quelques plaques de métal aux endroits vitaux.", TypeItem.Armure, 
                Rarete.Rare, "armure_rare.png"));
            listeItems.Add("armureEpique", new InventaireStuff("Cotte de Mailles en Mithril",
                "Légère comme une plume, dure comme du diamant. Idéal pour les dos fragiles.", TypeItem.Armure, 
                Rarete.Epique, "armure_epique.png"));
            listeItems.Add("armureLegendaire", new InventaireStuff("L'Égide du Gardien Éternel",
                "Une armure qui brille tellement qu'elle aveugle les ennemis. On raconte qu'elle est impénétrable.", TypeItem.Armure, 
                Rarete.Legendaire, "armure_legendaire.png"));
            
            listeItems.Add("livreCommun", new InventaireStuff("Le Coloriage pour Barbares",
                "Aide à se détendre entre deux massacres. Ne dépassez pas les lignes!", TypeItem.Livre, 
                Rarete.Commune, "livre_commun.png"));
            listeItems.Add("livreRare", new InventaireStuff("Traité Élémentaire de Pyromancie",
                "Sent le brûlé. Contient des sorts de base pour allumer un feu de camp... ou un gobelin.", TypeItem.Livre, 
                Rarete.Rare, "livre_rare.png"));
            listeItems.Add("livreEpique", new InventaireStuff("Codex des Ombres Mouvantes",
                "Les pages murmurent quand on les tourne. Augmente la puissance magique.", TypeItem.Livre, 
                Rarete.Epique, "livre_epique.png"));
            listeItems.Add("livreLegendaire", new InventaireStuff("L'Omniscience pour les Nuls",
                "Contient la réponse à tout, y compris le sens de la vie et la recette parfaite des crêpes.", TypeItem.Livre, 
                Rarete.Legendaire, "livre_legendaire.png"));
            
            listeItems.Add("bijouCommun", new InventaireStuff("Collier de Nouilles Séchées",
                "Un cadeau d'anniversaire fait main. Très croustillant en cas de famine.", TypeItem.Bijou, 
                Rarete.Commune, "bijou_commun.png"));
            listeItems.Add("bijouRare", new InventaireStuff("Anneau de Vif-Argent",
                "Un anneau simple qui rend les doigts plus agiles.", TypeItem.Bijou, 
                Rarete.Rare, "bijou_rare.png"));
            listeItems.Add("bijouEpique", new InventaireStuff("Pendentif du Vampire",
                "Une pierre rouge sang qui semble battre au rythme de votre cœur.", TypeItem.Bijou, 
                Rarete.Epique, "bijou_epique.png"));
            listeItems.Add("bijouLegendaire", new InventaireStuff("La Couronne du Roi Mendiant",
                "Un simple bandeau terni qui force pourtant le respect des rois et des dragons.", TypeItem.Bijou, 
                Rarete.Legendaire, "bijou_legendaire.png"));
            
            listeItems.Add("potionCommune", new InventaireStuff("Jus d'Orange (Périmé)",
                "Rend quelques PV, mais donne mal au ventre.", TypeItem.Potion, 
                Rarete.Commune, "potion_commune.png"));
            listeItems.Add("potionRare", new InventaireStuff("Potion de Soin Majeure",
                "Un liquide rouge vif au goût de cerise chimique.", TypeItem.Potion, 
                Rarete.Rare, "potion_rare.png"));
            listeItems.Add("potionEpique", new InventaireStuff("Élixir du Berserker",
                "Rend fou de rage. Double la force pendant 3 tours, mais vous ne pouvez plus fuir.", TypeItem.Potion, 
                Rarete.Epique, "potion_epique.png"));
            listeItems.Add("potionLegendaire", new InventaireStuff("Larmes de Phénix Concentrées",
                "Soigne tout, répare tout, et donne l'impression d'avoir dormi 12 heures.", TypeItem.Potion, 
                Rarete.Legendaire, "potion_legendaire.png"));
            
            listeItems.Add("instrumentCommun", new InventaireStuff("L'Ocarina du Temps... Perdu",
                "Un artefact légendaire... pour jouer \"Au clair de la lune\". Le seul temps qu'il manipule, c'est celui que vous perdez à essayer d'en tirer une note.", TypeItem.Instrument, 
                Rarete.Commune, "instrument_commun.png"));
            listeItems.Add("instrumentRare", new InventaireStuff("Le Didgeridoo-Bélier en Eucalyptus",
                " Tronc évidé de deux mètres. Produit un son qui fait vibrer les dents et un impact qui fait sauter les plombages. La musique adoucit les mœurs, le bois les fracasse.", TypeItem.Instrument, 
                Rarete.Rare, "instrument_rare.png"));
            listeItems.Add("instrumentEpique", new InventaireStuff("Le Triangle des Bermudes",
                "Un \"Ting !\" si pur qu'il déchire la réalité. Désarme vos ennemis ou fait disparaître vos clés. Prudence est mère de sûreté.", TypeItem.Instrument, 
                Rarete.Epique, "instrument_epique.png"));
            listeItems.Add("instrumentLegendaire", new InventaireStuff("La Gibson de l'Ombre",
                "Relique en métal noir forgée pour le chaos. Ses solos sont littéralement mortels et ses accords brisent les os.", TypeItem.Instrument, 
                Rarete.Legendaire, "instrument_legendaire.png"));
            
            
            Random random = new Random();
            int rng;
            Rarete rarete = Rarete.Autre;
            TypeItem type = TypeItem.ObjetQuete;
            
            if (DonneesTemporaires.choixRaceDefinitif == "Nain") {
                rng = random.Next(1, 4);
            } else {
                rng = random.Next(3, 4);
            }
            //modifier et remettre Next(0,4)
            if (rng == 0) {
                rarete = Rarete.Commune;
                
            }
            if (rng == 1) {
                rarete = Rarete.Rare;
            }
            if (rng == 2) {
                rarete = Rarete.Epique;
            }
            if (rng == 3) {
                rarete = Rarete.Legendaire;
            }
            

            if (DonneesTemporaires.choixClasseDefinitif == "Guerrier") {
                type = TypeItem.Armure;
            }
            if (DonneesTemporaires.choixClasseDefinitif == "Mage") {
                type = TypeItem.Livre;
            }
            if (DonneesTemporaires.choixClasseDefinitif == "Voleur") {
                type = TypeItem.Bijou;
            }
            if (DonneesTemporaires.choixClasseDefinitif == "Alchimiste") {
                type = TypeItem.Potion;
            }
            if (DonneesTemporaires.choixClasseDefinitif == "Troubadour") {
                type = TypeItem.Instrument;
            }

            InventaireStuff itemTrouve = null;

            foreach (var item in listeItems) {
                if (item.Value.typeItem == type && item.Value.rareteItem == rarete)
                {
                    itemTrouve = item.Value;
                    break;
                }
            }

            sacoche.Add("item4", itemTrouve);
            afficherItems();
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

                if (item.Value.rareteItem == Rarete.Commune)
                {
                    borderDisplay.BorderBrush = SolidColorBrush.Parse("#3498DB");
                } else if (item.Value.rareteItem == Rarete.Rare) {
                    borderDisplay.BorderBrush = SolidColorBrush.Parse("#2ECC71");
                } else if (item.Value.rareteItem == Rarete.Epique) {
                    borderDisplay.BorderBrush = SolidColorBrush.Parse("#D400FF");
                } else if (item.Value.rareteItem == Rarete.Legendaire) {
                    borderDisplay.BorderBrush = SolidColorBrush.Parse("#FFD700");
                }
                
                borderDisplay.BorderThickness = new Thickness(1);
                
            }
            
            int nbItemsSacoche = sacoche.Count + 1;

            for (int i = nbItemsSacoche; i < 9; i++) {
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
                
                rareteItemDetail.Text = objetRecupere.rareteItem.ToString();
                
                if (objetRecupere.rareteItem == Rarete.Commune) {
                    borderRareteItem.BorderBrush =  SolidColorBrush.Parse("#3498DB");
                    borderRareteItem.Background = SolidColorBrush.Parse("#0E1B26");
                } else if (objetRecupere.rareteItem == Rarete.Rare) {
                    borderRareteItem.BorderBrush =  SolidColorBrush.Parse("#2ECC71");
                    borderRareteItem.Background = SolidColorBrush.Parse("#14261C");
                } else if (objetRecupere.rareteItem == Rarete.Epique) {
                    borderRareteItem.BorderBrush =  SolidColorBrush.Parse("#D400FF");
                    borderRareteItem.Background = SolidColorBrush.Parse("#120A1A");
                } else if (objetRecupere.rareteItem == Rarete.Legendaire) {
                    borderRareteItem.BorderBrush =  SolidColorBrush.Parse("#FFD700");
                    borderRareteItem.Background = SolidColorBrush.Parse("#0F0F0F");
                }
                else {
                    borderRareteItem.BorderBrush =  SolidColorBrush.Parse("#333");
                    borderRareteItem.Background =  SolidColorBrush.Parse("#333");
                }
                
                descriptionItemDetail.Text = objetRecupere.descriptionItem;
                borderDetail.IsVisible = true;
                borderTypeItem.IsVisible = true;
                borderRareteItem.IsVisible = true;
                borderRareteItem.BorderThickness = new Thickness(1);
                borderImgDetail.BorderBrush = borderClick.BorderBrush;
            }
        }
        
        public void onRetourClick(object? sender, RoutedEventArgs e) {
            if (VisualRoot is MainWindow mainWindow){
                mainWindow.ecranTitre.Content = new competences();
            }
        }

        private void onCreationPersonnageClick(object? sender, RoutedEventArgs e) {
            if (VisualRoot is MainWindow mainWindow) {
                mainWindow.ecranTitre.Content = new validerCreation();
            }
        }
    }