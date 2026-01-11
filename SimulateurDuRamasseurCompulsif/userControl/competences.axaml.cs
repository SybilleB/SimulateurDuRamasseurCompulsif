using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.VisualBasic;
using SimulateurDuRamasseurCompulsif.Classes;
using SimulateurDuRamasseurCompulsif.Classes.Races;
using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;


namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class competences : UserControl {
    public string nomJoueur;
    public string choixRaceDefinitif;
    public string choixClasseDefinitif;
    public string genre;

    public bool deslances = false;
    
    public competences() {
        InitializeComponent();
    }
    public competences(string _nomJoueur, string _choixRaceDefinitif, string _choixClasseDefinitif, string _genre) {
        InitializeComponent();
        verifierBoutonConfirmer();
        desactiverBoutonsMoins();
        desactiverBoutonsPlus();
        nomJoueur = _nomJoueur;
        choixRaceDefinitif = _choixRaceDefinitif;
        choixClasseDefinitif = _choixClasseDefinitif;
        genre = _genre;
        
    }

    public void creationPersonnage() {

        Race racePersonnage = null;
        HerosClasse classePersonnage = null;
        
        if (choixRaceDefinitif == "Humain") {
            racePersonnage = new Humain(genre);
        }
        if (choixRaceDefinitif == "Elfe") {
            racePersonnage = new Elfe(genre);
        }
        if (choixRaceDefinitif == "Nain") {
            racePersonnage = new Nain(genre);
        }
        if (choixRaceDefinitif == "Gobelin") {
            racePersonnage = new Gobelin(genre);
        }
        if (choixRaceDefinitif == "Fée") {
            racePersonnage = new Fee(genre);
        }

        if (choixClasseDefinitif == "Guerrier") {
            classePersonnage = new Guerrier();
        }
        if (choixClasseDefinitif == "Mage") {
            classePersonnage = new Mage();
        }
        if (choixClasseDefinitif == "Voleur") {
            classePersonnage = new Voleur();
        }
        if (choixClasseDefinitif == "Alchimiste") {
            classePersonnage = new Alchimiste();
        }
        if (choixClasseDefinitif == "Troubadour") {
            classePersonnage = new Troubadour();
        }

        Personnage p = new Personnage(racePersonnage, classePersonnage);

    }
    
    public void onLancerDesClick(object? sender, RoutedEventArgs e) {
        Random rng = new Random();
        int lancer1 = rng.Next(1, 7);
        int lancer2 = rng.Next(1, 7);
        
        de1.Text = lancer1.ToString();
        de2.Text = lancer2.ToString();
        int nbPointsDispo = lancer1 + lancer2;
        ptsRestants.Text = nbPointsDispo.ToString();
        
        boutonLancer.IsEnabled = false;
        desactiverBoutonsPlus();
        deslances = true;
    }

    public void desactiverBoutonsMoins() {
        if (ptsForce.Text == "0") {
            moinsForce.IsEnabled = false;
        }else {
            moinsForce.IsEnabled = true; 
        }
        if (ptsAgilite.Text == "0") {
            moinsAgilite.IsEnabled = false;
        }else {
            moinsAgilite.IsEnabled = true; 
        }
        if (ptsVitalite.Text == "0") {
            moinsVitalite.IsEnabled = false;
        }else {
            moinsVitalite.IsEnabled = true; 
        }
        if (ptsIntelligence.Text == "0") {
            moinsIntelligence.IsEnabled = false;
        }else {
            moinsIntelligence.IsEnabled = true; 
        }
        if (ptsCharisme.Text == "0") {
            moinsCharisme.IsEnabled = false;
        }else {
            moinsCharisme.IsEnabled = true; 
        }
        if (ptsChance.Text == "0") {
            moinsChance.IsEnabled = false;
        }else {
            moinsChance.IsEnabled = true; 
        }
        
    }

    public void desactiverBoutonsPlus() {
        int ptsDispos = int.Parse(ptsRestants.Text);
        if (ptsDispos <= 0) {
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
    
    public void modifierStats(TextBlock nomStat, int modificateur) {
        
        int forceActuelle = int.Parse(ptsForce.Text);
        int agiliteActuelle = int.Parse(ptsAgilite.Text);
        int intelligenceActuelle = int.Parse(ptsIntelligence.Text);
        int charismeActuelle = int.Parse(ptsCharisme.Text);
        int chanceActuelle = int.Parse(ptsChance.Text);
        
        int ptsDispos = int.Parse(ptsRestants.Text);
        
        
        int stat = int.Parse(nomStat.Text);
        desactiverBoutonsPlus();
        
        stat += modificateur;
        nomStat.Text = stat.ToString();
        ptsDispos -= modificateur;
        ptsRestants.Text = ptsDispos.ToString();
        
        desactiverBoutonsPlus();
        desactiverBoutonsMoins();
        verifierBoutonConfirmer();
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


    public void verifierBoutonConfirmer() {
        
        if (deslances == true && ptsRestants.Text == "0") {
            boutonConfirmerStats.IsEnabled = true;
        }else {
            boutonConfirmerStats.IsEnabled = false;
        }
    }
    public void onValiderClick(object? sender, RoutedEventArgs e) {
        throw new System.NotImplementedException();
    }

    public void onRetourClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new donneesPersonnage(nomJoueur, choixRaceDefinitif, choixClasseDefinitif);
        }
    }
    
}