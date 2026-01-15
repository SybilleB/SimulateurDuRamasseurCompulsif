using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Nain:Race
{

    public Nain() : base("Nain","Forgeron", "Considère que porter une armure \"Commune\" est une insulte à ses ancêtres.", new Stats()) {}

    public Nain(string _nomRace) : base(_nomRace,"Forgeron", "Considère que porter une armure \"Commune\" est une insulte à ses ancêtres.", new Stats())
    {
        _nomRace = "Nain";
        
        statsRace.force += 1;
        statsRace.vitalite += 1;
        statsRace.intelligence -= 1;
        statsRace.agilite -= 1;
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