using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Guerrier : HerosClasse { 
    
    public Guerrier() : base() {
        bonusClasseStats.force = 2;
        bonusClasseStats.charisme = 1;
        bonusClasseStats.agilite = -2;
    }

    private Random lancerDe = new Random();
    
    public override int attaqueSpeciale(Personnage personnage) {
        //Cri de guerre, jet de dés avant chaque tour, si 5 ou + alors +20 dégats

        int resultatDe = lancerDe.Next(1, 7);
        int attaque = personnage.race.stats.force;
        
        if (resultatDe >= 5) { 
            attaque += 20;
            Console.WriteLine("Veine sur la tempe activée : +20 de force");
        }
        else {
            Console.WriteLine("Un grand cri... pour absolument rien");
        }
        return attaque;
    }
}