using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Alchimiste : HerosClasse {
    
    public Alchimiste() : base("Alchimiste", "Mélange des trucs avec d'autres trucs pour créer des miracles ou des explosions. Généralement les deux en même temps.", 
        "La fiole de Schrödinger", "Si le résultat du jet de dé est pair, alors sa défense augmente de 15%. Si c'est impair, elle diminue de 15%.") {
        statsClasse.force = -2;
        statsClasse.charisme = -1;
        statsClasse.vitalite = 1;
        statsClasse.chance = 2;
    }
    
    private Random lancerDe = new Random();

    public override int attaqueSpeciale(Personnage personnage) {
        //La fiole de Schrödinger, lancer de dés, si pair alors +15% défense (agilité),
        //si impaire alors -15% defense
        
        int resultatDe = lancerDe.Next(1, 7);
        int defense = personnage.race.statsRace.agilite;
        
        if (resultatDe %2 == 0) {
            defense += (personnage.race.statsRace.agilite * 15 / 100);
            Console.WriteLine("Youpi, le chat est vivant et a un bouclier !");
        } else {
            defense -= (personnage.race.statsRace.force * 15 / 100);
            Console.WriteLine("Mauvaise pioche, le chat est mort et l'armure s'effrite...");
        }
        return defense;
    }
}