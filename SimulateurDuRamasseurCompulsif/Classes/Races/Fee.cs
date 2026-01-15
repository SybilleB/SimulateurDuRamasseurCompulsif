using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Fee : Race {
    
    public Fee() : base("Fee","Providence Ailée", "Améliore le butin trouvé parce qu'elle a des goûts de luxe et peu de patience." ,new Stats()) {
        stats.agilite += 1;
        stats.chance += 1;
        stats.force -= 1;
        
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