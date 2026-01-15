using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Nain:Race {
   
    public Nain() : base("Gobelin","Forgeron", "Considère que porter une armure \"Commune\" est une insulte à ses ancêtres.", new Stats()) {
        stats.force += 1;
        stats.vitalite += 1;
        stats.intelligence -= 1;
        stats.agilite -= 1;
    }
    
    public override bool classeAutorisee(HerosClasse classe) {
        if (classe is Guerrier || classe is Alchimiste || classe is Troubadour) {
            return true;
        }
        else {
            return false;
        }
    }
}