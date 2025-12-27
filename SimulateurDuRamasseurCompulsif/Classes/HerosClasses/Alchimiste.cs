using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Alchimiste : HerosClasse {
    
    public Alchimiste() : base() {
        bonusClasseStats.force = -2;
        bonusClasseStats.charisme = -1;
        bonusClasseStats.vitalite = 1;
        bonusClasseStats.chance = 2;
    }
    
    private Random lancerDe = new Random();

    public override int attaqueSpeciale(Personnage personnage) {
        //La fiole de Schrödinger, lancer de dés, si pair alors +15% défense (agilité),
        //si impaire alors -15% defense
        
        int resultatDe = lancerDe.Next(1, 7);
        int defense = personnage.race.stats.agilite;
        
        if (resultatDe %2 == 0) {
            defense += (personnage.race.stats.agilite * 15 / 100);
            Console.WriteLine("Youpi, le chat est vivant et a un bouclier !");
        }
        else {
            defense -= (personnage.race.stats.force * 15 / 100);
            Console.WriteLine("Mauvaise pioche, le chat est mort et l'armure s'effrite...");
        }
        return defense;
    }
}