using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;
using SimulateurDuRamasseurCompulsif.Classes.Races;
using SimulateurDuRamasseurCompulsif.Classes.Items;
using System.Collections.Generic;
using System;

namespace SimulateurDuRamasseurCompulsif.Classes;

public class Personnage {
    public string nomJoueur;
    public Race race;
    public HerosClasse hero;
    public List<Item> Inventaire = new List<Item>();
    
    public int capaciteMax = 10;
    
    public Personnage(string _nomJoueur, Race _race, HerosClasse _hero) {
        
        if (!_race.classeAutorisee(_hero)) {
            Console.WriteLine("Erreur, un " + _race.GetType().Name + "ne peut pas être un " + _hero.GetType().Name);
            return; 
        }
        else {
            nomJoueur = _nomJoueur;
            race = _race;
            hero = _hero;

            race.stats.ajouterStats(hero.bonusClasseStats);
            affinités(); 
        }
        if (_hero is Alchimiste) {
            _race.pv += 25;
        }
        
        
    }

    public void affinités() {
        if (race is Humain && hero is Guerrier) {
            race.stats.force += 2;
        }
        if (race is Elfe && hero is Voleur) {
            race.stats.agilite += 2;
        }
        if (race is Nain && hero is Alchimiste) {
            race.stats.vitalite += 2;
        }
        if (race is Gobelin && hero is Troubadour) {
            race.stats.chance += 2;
        }
        if (race is Fee && hero is Mage) {
            race.stats.intelligence += 2;
        }
    }

    private Random lancerDe = new Random();
    /*public void repartirPoints() {
        int resultatDe = lancerDe.Next(1, 7) + lancerDe.Next(1, 7);

        while (resultatDe > 0) {
            
        }
    }*/
    public void afficherInfosTotales() {
        Console.WriteLine("===============================");
        Console.WriteLine("Nom du joueur : " +  nomJoueur + "\n");
        race.afficherInfos();
        Console.WriteLine("===============================");
    }

    public void afficherInventaire() {
        foreach (var item in Inventaire) {
            Console.WriteLine(item.nomItem + item.descriptionItem + item.rareteItem + item.valeurOr);
        }
    }

    public void ajouterItem(Item item) {
        if (Inventaire.Count < capaciteMax) {
            Inventaire.Add(item);
            Console.WriteLine("Hop ! Emballé, c'est pesé. " + item.nomItem + " a bien été ajouté à l'inventaire");
        }
        else {
            Console.WriteLine("Même en tassant avec le pied, ça ne rentre plus");
        }
    }

    public void retirerItem(Item item) {
        Inventaire.Remove(item);
        Console.WriteLine("C'était encombrant, et honnêtement, un peu moche. " + item.nomItem + " a bien été retiré de l'inventaire");
    }
    
}