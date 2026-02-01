using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Fee : Race {
    
    public Fee() : base("Fée", "Minuscule et insaisissable, elle manie la magie ancienne et voltige avec grâce.",
        "Providence Ailée", "Améliore le butin trouvé parce qu'elle a des goûts de luxe et peu de patience.") {
        statsRace.agilite = 1;
        statsRace.chance = 1;
        statsRace.force = -1;
    }
    
    public override bool classeAutorisee(HerosClasse classe) {
        if (classe is Guerrier || classe is Mage || classe is Voleur || classe is Troubadour) {
            return true;
        } else {
            return false;
        }
    }
    
    public override bool classeFavorite(HerosClasse classe) {
        if (classe is Mage) {
            return true;
        } else {
            return false;
        }
    }
}