using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Mage : HerosClasse {
    
    public Mage() : base() {
        bonusClasseStats.force = -2;
        bonusClasseStats.agilite = -2;
        bonusClasseStats.chance = 3;
    }
    
    private Random lancerDe = new Random();

    public override int attaqueSpeciale(Personnage personnage) {
        //Champs de force, lancer de dés, si 3 ou - alors +15% de défense (agilité)
        
        int resultatDe = lancerDe.Next(1, 7);
        int defense;
        if (resultatDe <= 3) {
            defense = personnage.race.stats.agilite + (personnage.race.stats.agilite * 15 / 100);
            Console.WriteLine("Le champs de force est en place. C'est moche mais ça protège");
            
        }
        else {
            defense = personnage.race.stats.agilite;
            Console.WriteLine("Erreur 404, talent non trouvé");
        }
        return defense;
    }
}