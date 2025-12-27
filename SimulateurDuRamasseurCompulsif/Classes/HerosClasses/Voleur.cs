using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Voleur : HerosClasse {
    
    public Voleur() : base() {
        bonusClasseStats.force = -1;
        bonusClasseStats.charisme = -1;
        bonusClasseStats.intelligence = 1;
        bonusClasseStats.agilite = 2;
    }
    
    private Random lancerDe = new Random();

    public override int attaqueSpeciale(Personnage personnage) {
        //Festin de l'ombre, lancer de dés, si 4 ou + alors +15% de hp ennemis
        
        int resultatDe = lancerDe.Next(1, 7);
        if (resultatDe >= 4) {
            personnage.race.pv += 15;
            Console.WriteLine("La ceinture crie au secours mais le festin était succulent");
        }
        else {
            Console.WriteLine("Le ventre sonne tellement creux qu'on peut y entendre l'écho de la déception");
        }
        return personnage.race.pv;
    }
}