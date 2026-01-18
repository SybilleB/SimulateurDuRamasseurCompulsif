using System;

namespace SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public abstract class HerosClasse
{

    public string nomClasse;
    public string description;
    public string talent;
    public string descriptionTalent;
    public Stats statsClasse;

    public HerosClasse(string _nomClasse, string _description, string _talent, string _descriptionTalent) {
        nomClasse = _nomClasse;
        description = _description;
        talent = _talent;
        descriptionTalent = _descriptionTalent;
        statsClasse = new Stats();
    }

    private Random lancerDe = new Random();

    public virtual int calculDegats(Stats stats) {
        int resultatDe = lancerDe.Next(1, 7);
        int degatsInfliges =  stats.force * resultatDe;
        return degatsInfliges;
    }

    public abstract int attaqueSpeciale(Personnage personnage);
}