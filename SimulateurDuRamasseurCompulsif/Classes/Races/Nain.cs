using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Nain:Race {
    
    public Nain() : base("Nain", "Combattant robuste et obstiné, expert des profondeurs et de la forge.", "Forgeron", "Considère que porter une armure \"Commune\" est une insulte à ses ancêtres.") {
        statsRace.force = 1;
        statsRace.vitalite = 1;
        statsRace.intelligence = -1;
        statsRace.agilite = -1;
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