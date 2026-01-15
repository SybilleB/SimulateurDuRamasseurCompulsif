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
    public List<InventaireStuff> Inventaire { get; set; } = new List<InventaireStuff>();
    
    public int capaciteMax = 10;
    
    public Personnage(Race _race, HerosClasse _classe) {
        
        if (!_race.classeAutorisee(_classe)) {
            Console.WriteLine("Erreur, un " + _race.GetType().Name + "ne peut pas être un " + _classe.GetType().Name);
            return; 
        }
        else {
            race = _race;
            classe = _classe;

            race.stats.ajouterStats(classe.bonusClasseStats);
            affinités(); 
        }
        if (_classe is Alchimiste) {
            _race.pv += 25;
        }
    }

    public void affinités() {
        if (race is Humain && classe is Guerrier) {
            race.stats.force += 2;
        }
        if (race is Elfe && classe is Voleur) {
            race.stats.agilite += 2;
        }
        if (race is Nain && classe is Alchimiste) {
            race.stats.vitalite += 2;
        }
        if (race is Gobelin && classe is Troubadour) {
            race.stats.chance += 2;
        }
        if (race is Fee && classe is Mage) {
            race.stats.intelligence += 2;
        }
    }

    private Random lancerDe = new Random();
    /*public void repartirPoints() {
        int resultatDe = lancerDe.Next(1, 7) + lancerDe.Next(1, 7);

        while (resultatDe > 0) {
            
        }
    }*/

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