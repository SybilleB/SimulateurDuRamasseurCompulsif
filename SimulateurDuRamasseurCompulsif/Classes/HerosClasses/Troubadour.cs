using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Troubadour : HerosClasse {
    
    public Troubadour() : base("Troubadour") {
        statsClasse.force = -1;
        statsClasse.charisme = 2;
        statsClasse.agilite = -2;
        statsClasse.chance = 3;
    }
    
    private Random lancerDe = new Random();

    public override int attaqueSpeciale(Personnage personnage) {
        //Concerto des Cieux, lancer de dés, si 5 ou plus alors +30% d'esquive (charisme)
        
        int resultatDe = lancerDe.Next(1, 7);
        int esquive = personnage.race.statsRace.charisme;
        
        if (resultatDe >= 5) {
            esquive += (personnage.race.statsRace.charisme * 30 / 100);
            Console.WriteLine("Quelle standing ovation du public !");
        }
        else {
            Console.WriteLine("Une fausse note au mileu du solo. Gênant...");
        }
        return esquive;
    }
}