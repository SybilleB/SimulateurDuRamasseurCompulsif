using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;
using SimulateurDuRamasseurCompulsif.Classes.Races;
using SimulateurDuRamasseurCompulsif.Classes.Items;
using System.Collections.Generic;
using System;

namespace SimulateurDuRamasseurCompulsif.Classes;

public class Personnage {
    public string nomJoueur { get; set; }
    public Race race { get; set; }
    public HerosClasse classe { get; set; }
    public Stats statsPerso { get; set; }
    
    public List<InventaireStuff> Inventaire { get; set; } = new List<InventaireStuff>();
    
    public int capaciteMax = 10;
    
    public Personnage(string _nomJoueur, Race _race, HerosClasse _classe, Stats _statsChoix) {
        
        nomJoueur = _nomJoueur;
        race = _race;
        classe = _classe;
        statsPerso = new Stats();
        
        statsPerso.ajouterStats(race.statsRace);
        statsPerso.ajouterStats(classe.statsClasse);
        statsPerso.ajouterStats(_statsChoix);
        
        affinités(); 
    }
    
    public void affinités() {
        if (race is Humain && classe is Guerrier) {
            statsPerso.force += 2;
        }
        if (race is Elfe && classe is Voleur) {
            statsPerso.agilite += 2;
        }
        if (race is Nain && classe is Alchimiste) {
            statsPerso.vitalite += 2;
        }
        if (race is Gobelin && classe is Troubadour) {
            statsPerso.chance += 2;
        }
        if (race is Fee && classe is Mage) {
            statsPerso.intelligence += 2;
        }
    }

    public void afficherInventaire() {
        foreach (var item in Inventaire) {
            Console.WriteLine(item.nomItem + item.descriptionItem + item.rareteItem);
        }
    }

    public void ajouterItem(InventaireStuff inventaireStuff) {
        if (Inventaire.Count < capaciteMax) {
            Inventaire.Add(inventaireStuff);
            Console.WriteLine("Hop ! Emballé, c'est pesé. " + inventaireStuff.nomItem + " a bien été ajouté à l'inventaire");
        }
        else {
            Console.WriteLine("Même en tassant avec le pied, ça ne rentre plus");
        }
    }

    public void retirerItem(InventaireStuff inventaireStuff) {
        Inventaire.Remove(inventaireStuff);
        Console.WriteLine("C'était encombrant, et honnêtement, un peu moche. " + inventaireStuff.nomItem + " a bien été retiré de l'inventaire");
    }
    
}