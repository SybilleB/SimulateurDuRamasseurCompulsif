using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Gobelin : Race {
    
    public Gobelin() : base("Gobelin", "Pillard", "Gagne 10% d'or bonus grâce à son talent pour secouer les cadavres encore chauds.", new Stats()) {
        statsRace.force -= 1;
        statsRace.charisme -= 2;
        statsRace.intelligence += 2;
        statsRace.agilite += 1;
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