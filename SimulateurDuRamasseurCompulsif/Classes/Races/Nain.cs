using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Nain:Race {
   
    public Nain(string _nom, string _genre, int _poids) : base(_nom, _genre, _poids, new Stats()) {
        stats.force += 1;
        stats.vitalite += 1;
        stats.intelligence -= 1;
        stats.agilite -= 1;
        talent = "Forgeron";
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