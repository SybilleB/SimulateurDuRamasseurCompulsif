using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public abstract class HerosClasse {
    
    public string nomClasse { get; set; }
    public Stats bonusClasseStats;

    public HerosClasse(string _nomClasse) {
        nomClasse = _nomClasse;
        bonusClasseStats = new Stats();
    }

    private Random lancerDe = new Random();

    public virtual int calculDegats(Stats stats) {
        int resultatDe = lancerDe.Next(1, 7);
        int degatsInfliges =  stats.force * resultatDe;
        return degatsInfliges;
    }

    public abstract int attaqueSpeciale(Personnage personnage);
}