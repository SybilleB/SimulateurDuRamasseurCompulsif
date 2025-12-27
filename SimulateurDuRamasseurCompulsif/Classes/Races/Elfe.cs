using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Elfe : Race {
    
    public Elfe(string _nom, string _genre, int _poids) : base(_nom, _genre, _poids, new Stats()) {
        stats.intelligence += 1;
        stats.agilite += 1;
        stats.chance += 1;
        stats.vitalite -= 3;
        talent = "Vision Nocturne";
    }

    public override bool classeAutorisee(HerosClasse classe) {
        if (classe is Guerrier || classe is Mage || classe is Voleur || classe is Alchimiste) {
            return true;
        }
        else {
            return false;
        }
    }
}