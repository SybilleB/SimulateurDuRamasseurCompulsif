using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Mage : HerosClasse {
    
    public Mage() : base("Mage", "Lance des sorts complexes, en espérant ne pas se crâmer les sourcils.", 
        "Champs de force", "Augmente sa défense de 15% si le résultat du jet de dé est inférieur à 4.") {
        statsClasse.force = -2;
        statsClasse.agilite = -2;
        statsClasse.chance = 3;
    }
    
    private Random lancerDe = new Random();

    public override int attaqueSpeciale(Personnage personnage) {
        //Champs de force, lancer de dés, si 3 ou - alors +15% de défense (agilité)
        
        int resultatDe = lancerDe.Next(1, 7);
        int defense;
        if (resultatDe <= 3) {
            defense = personnage.race.statsRace.agilite + (personnage.race.statsRace.agilite * 15 / 100);
            Console.WriteLine("Le champs de force est en place. C'est moche mais ça protège");
        } else {
            defense = personnage.race.statsRace.agilite;
            Console.WriteLine("Erreur 404, talent non trouvé");
        }
        return defense;
    }
}