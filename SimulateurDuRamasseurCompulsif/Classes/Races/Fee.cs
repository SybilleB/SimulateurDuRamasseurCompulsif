using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Fee : Race {
    
    public Fee(string _nom, string _genre, int _poids) : base(_nom, _genre, _poids, new Stats()) {
        stats.agilite += 1;
        stats.chance += 1;
        stats.force -= 1;
        talent = "Providence Ailée";
    }
    
    public override bool classeAutorisee(HerosClasse classe) {
        if (classe is Guerrier || classe is Mage || classe is Voleur || classe is Troubadour) {
            return true;
        }
        else {
            return false;
        }
    }
}