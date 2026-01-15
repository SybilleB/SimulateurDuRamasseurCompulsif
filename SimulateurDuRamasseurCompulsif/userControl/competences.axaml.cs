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
    
    public Stats statsBase;
    public Stats statsActualisees;
    
    public competences() {
        InitializeComponent();
        desactiverBoutons();
        initialiserPoints();
    }

    public void initialiserPoints() {
        
        Race raceTemporaire = null;
        HerosClasse classeTemporaire = null;
        
        if (DonneesTemporaires.choixRaceDefinitif == "Humain") {
            raceTemporaire = new Humain();
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Elfe") {
            raceTemporaire = new Elfe();
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Nain") {
            raceTemporaire = new Nain();
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Gobelin") {
            raceTemporaire = new Gobelin();
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Fée") {
            raceTemporaire = new Fee();
        }

        if (DonneesTemporaires.choixClasseDefinitif == "Guerrier") {
            classeTemporaire = new Guerrier();
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Mage") {
            classeTemporaire = new Mage();
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Voleur") {
            classeTemporaire = new Voleur();
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Alchimiste") {
            classeTemporaire = new Alchimiste();
        }
        if (DonneesTemporaires.choixClasseDefinitif == "Troubadour") {
            classeTemporaire = new Troubadour();
        }
        
        statsBase = new Stats();
        statsBase.ajouterStats(raceTemporaire.statsRace);
        statsBase.ajouterStats(classeTemporaire.statsClasse);

        statsActualisees = new Stats();
        statsActualisees.ajouterStats(statsBase);
        
        actualiserAffichage();
    }
    
    public void onLancerDesClick(object? sender, RoutedEventArgs e) {
        Random rng = new Random();
        int lancer1 = rng.Next(1, 7);
        int lancer2 = rng.Next(1, 7);
        
        de1.Text = lancer1.ToString();
        de2.Text = lancer2.ToString();
        
        pointsDispos = lancer1 + lancer2;
        
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
        }
        if (nomStat == ptsAgilite) {
            statsActualisees.agilite += modificateur;
        }
        if (nomStat == ptsVitalite) {
            statsActualisees.vitalite += modificateur;
        }
        if (nomStat == ptsIntelligence) {
            statsActualisees.intelligence += modificateur;
        } 
        if (nomStat == ptsCharisme) {
            statsActualisees.charisme += modificateur;
        } 
        if (nomStat == ptsChance) {
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
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new inventaire();
        }
    }

    public void onRetourClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new donneesPersonnage();
        }
    }
    
}