using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Gobelin : Race {
    
    public Gobelin(string _genre) : base("Gobelin", _genre, new Stats()) {
        
        
        stats.force -= 1;
        stats.charisme -= 2;
        stats.intelligence += 2;
        stats.agilite += 1;
        talent = "Pillard";
    }
    
    public override bool classeAutorisee(HerosClasse classe) {
        if (classe is Guerrier || classe is Voleur || classe is Troubadour) {
            return true;
        }
        else {
            return false;
        }
    }
}