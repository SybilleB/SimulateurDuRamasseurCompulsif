using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Guerrier : HerosClasse { 
    
    public Guerrier() : base("Guerrier", "Frappe fort et sans peur, pour être sûr de pouvoir raconter ses exploits à la taverne.","Cri de guerre", "Inflige +20 dégats si le résultat du jet de dé est supérieur à 4.") {
        statsClasse.force = 2;
        statsClasse.charisme = 1;
        statsClasse.intelligence = -1;
        statsClasse.agilite = -2;
    }

    private Random lancerDe = new Random();
    
    public override int attaqueSpeciale(Personnage personnage) {
        //Cri de guerre, jet de dés avant chaque tour, si 5 ou + alors +20 dégats

        int resultatDe = lancerDe.Next(1, 7);
        int attaque = personnage.race.statsRace.force;
        
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