using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Voleur : HerosClasse {
    
    public Voleur() : base() {
        bonusClasseStats.force = -3;
        bonusClasseStats.intelligence = 1;
        bonusClasseStats.agilite = 2;
    }
    
    private Random lancerDe = new Random();

    public override int attaqueSpeciale(Personnage personnage) {
        //Festin de l'ombre, lancer de dés au début du combat, si 5 ou + alors vole 20hp de l'ennemi 
        
        int resultatDe = lancerDe.Next(1, 7);
        if (resultatDe >= 5) {
            personnage.race.pv += 15;
            Console.WriteLine("La ceinture crie au secours mais le festin était succulent");
        }
        else {
            Console.WriteLine("Le ventre sonne tellement creux qu'on peut y entendre l'écho de la déception");
        }
        return personnage.race.pv;
    }
}