using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using SimulateurDuRamasseurCompulsif.Classes;
using SimulateurDuRamasseurCompulsif.Classes.Races;
using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;


namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class competences : UserControl {

    public bool deslances = false;
    public int pointsDispos = 0;
    
    public Race raceDefinitive = null;
    public HerosClasse classeDefinitive = null;
    
    public Stats statsBase;
    public Stats statsActualisees;
    
    public competences() {
        InitializeComponent();
        desactiverBoutons();
        initialiserPoints();
    }

    public void initialiserPoints() {
        
        if (DonneesTemporaires.choixRaceDefinitif == "Humain") {
            raceDefinitive = new Humain();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Elfe") {
            raceDefinitive = new Elfe();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Nain") {
            raceDefinitive = new Nain();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Gobelin") {
            raceDefinitive = new Gobelin();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Fée") {
            raceDefinitive = new Fee();
        }

        if (DonneesTemporaires.choixClasseDefinitif == "Guerrier") {
            classeDefinitive = new Guerrier();
        } else if (DonneesTemporaires.choixClasseDefinitif == "Mage") {
            classeDefinitive = new Mage();
        } else if (DonneesTemporaires.choixClasseDefinitif == "Voleur") {
            classeDefinitive = new Voleur();
        } else if (DonneesTemporaires.choixClasseDefinitif == "Alchimiste") {
            classeDefinitive = new Alchimiste();
        } else if (DonneesTemporaires.choixClasseDefinitif == "Troubadour") {
            classeDefinitive = new Troubadour();
        }
        
        statsBase = new Stats();
        statsBase.ajouterStats(raceDefinitive.statsRace);
        statsBase.ajouterStats(classeDefinitive.statsClasse);

        statsActualisees = new Stats();
        statsActualisees.ajouterStats(statsBase);
        
        pointsAffinites();
        actualiserAffichage();
    }
    
    public void pointsAffinites() {
        if (DonneesTemporaires.choixRaceDefinitif == "Humain" && DonneesTemporaires.choixClasseDefinitif == "Guerrier"){
            statsActualisees.force += 2;
        } else if (DonneesTemporaires.choixRaceDefinitif == "Elfe" && DonneesTemporaires.choixClasseDefinitif == "Voleur") {
            statsActualisees.agilite += 2;
        } else if (DonneesTemporaires.choixRaceDefinitif == "Nain" && DonneesTemporaires.choixClasseDefinitif == "Alchimiste") {
            statsActualisees.vitalite += 2;
        } else if (DonneesTemporaires.choixRaceDefinitif == "Gobelin" && DonneesTemporaires.choixClasseDefinitif == "Troubadour") {
            statsActualisees.chance += 2;
        } else if (DonneesTemporaires.choixRaceDefinitif == "Fée" && DonneesTemporaires.choixClasseDefinitif == "Mage") {
            statsActualisees.intelligence += 2;
        }
    }
    
    public void onLancerDesClick(object? sender, RoutedEventArgs e) {
        Random rng = new Random();
        int lancer1 = rng.Next(1, 7);
        int lancer2 = rng.Next(1, 7);
        
        de1.Text = lancer1.ToString();
        de2.Text = lancer2.ToString();
        
        if (DonneesTemporaires.choixRaceDefinitif == "Humain") {
            pointsDispos = lancer1 + lancer2 + 3;

        } else {
            pointsDispos = lancer1 + lancer2;
        }
        
        boutonLancer.IsEnabled = false;
        deslances = true;
        
        actualiserAffichage();
    }

    public void actualiserAffichage() {
        ptsForce.Text = statsActualisees.force.ToString();
        ptsAgilite.Text = statsActualisees.agilite.ToString();
        ptsVitalite.Text = statsActualisees.vitalite.ToString();
        ptsIntelligence.Text = statsActualisees.intelligence.ToString();
        ptsCharisme.Text = statsActualisees.charisme.ToString();
        ptsChance.Text = statsActualisees.chance.ToString();

        ptsRestants.Text = pointsDispos.ToString();

        if (DonneesTemporaires.choixRaceDefinitif == "Humain") {
            bonusHumain.IsVisible = true;
        }

        if (deslances == true) {
            moinsForce.IsEnabled = statsActualisees.force > statsBase.force;
            moinsAgilite.IsEnabled = statsActualisees.agilite > statsBase.agilite;
            moinsVitalite.IsEnabled = statsActualisees.vitalite > statsBase.vitalite;
            moinsIntelligence.IsEnabled = statsActualisees.intelligence > statsBase.intelligence;
            moinsCharisme.IsEnabled = statsActualisees.charisme > statsBase.charisme;
            moinsChance.IsEnabled = statsActualisees.chance > statsBase.chance;
        }

        if (deslances == true && pointsDispos == 0) {
            boutonConfirmerStats.IsEnabled = true;
        } else {
            boutonConfirmerStats.IsEnabled = false;
        } 
        
        if (pointsDispos <= 0) {
            plusForce.IsEnabled = false;
            plusAgilite.IsEnabled = false;
            plusVitalite.IsEnabled = false;
            plusIntelligence.IsEnabled = false;
            plusCharisme.IsEnabled = false;
            plusChance.IsEnabled = false;
        } else {
            plusForce.IsEnabled = true;
            plusAgilite.IsEnabled = true;
            plusVitalite.IsEnabled = true;
            plusIntelligence.IsEnabled = true;
            plusCharisme.IsEnabled = true;
            plusChance.IsEnabled = true;
        }
    }
    
    public void desactiverBoutons() {
        plusForce.IsEnabled = false;
        plusAgilite.IsEnabled = false;
        plusVitalite.IsEnabled = false;
        plusIntelligence.IsEnabled = false;
        plusCharisme.IsEnabled = false;
        plusChance.IsEnabled = false;
        
        moinsForce.IsEnabled = false;
        moinsAgilite.IsEnabled = false;
        moinsVitalite.IsEnabled = false;
        moinsIntelligence.IsEnabled = false;
        moinsCharisme.IsEnabled = false;
        moinsChance.IsEnabled = false;
    }
    
    public void modifierStats(TextBlock nomStat, int modificateur) {

        if (nomStat == ptsForce) {
            statsActualisees.force += modificateur;
        } else if (nomStat == ptsAgilite) {
            statsActualisees.agilite += modificateur;
        } else if (nomStat == ptsVitalite) {
            statsActualisees.vitalite += modificateur;
        } else if (nomStat == ptsIntelligence) {
            statsActualisees.intelligence += modificateur;
        } else if (nomStat == ptsCharisme) {
            statsActualisees.charisme += modificateur;
        } else if (nomStat == ptsChance) {
            statsActualisees.chance += modificateur;
        }
        
        pointsDispos -= modificateur;
        actualiserAffichage();
    }
    
    public void onMoinsForceClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsForce,-1);
    }
    public void onPlusForceClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsForce,1);
    }
    public void onMoinsAgiliteClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsAgilite,-1);
    }
    public void onPlusAgiliteClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsAgilite,1);
    }
    public void onMoinsVitaliteClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsVitalite,-1);
    }
    public void onPlusVitaliteClick(object? sender, RoutedEventArgs e){
        modifierStats(ptsVitalite,1);
    }
    public void onMoinsIntelligenceClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsIntelligence,-1);
    }
    public void onPlusIntelligenceClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsIntelligence,1);
    }
    public void onMoinsCharismeClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsCharisme,-1);
    }
    public void onPlusCharismeClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsCharisme,1);
    }
    public void onMoinsChanceClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsChance,-1);
    }
    public void onPlusChanceClick(object? sender, RoutedEventArgs e) {
        modifierStats(ptsChance,1);
    }
    
    
    public void onValiderClick(object? sender, RoutedEventArgs e) {
        
        Personnage personnage = new Personnage(DonneesTemporaires.nomJoueur, DonneesTemporaires.titreHonorifique, 
            DonneesTemporaires.photoProfil, DonneesTemporaires.genre, raceDefinitive, classeDefinitive, statsActualisees);
        
        DonneesTemporaires.personnageFinal = personnage;
        
        var fenetrePerso = new SauvegardePersonnage();
        fenetrePerso.Show();
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.Close();
        }
    }
    public void onRetourClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new donneesPersonnage();
        }
    }
    
}