using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Humain:Race {

    public Humain() : base("Humain", "Polyvalent et ambitieux, l'humain s'adapte à toutes les situations.",
        "Volonté de fer", "Garde 1 PV au lieu de mourir, par pure obstination.") {}
    
    public override bool classeFavorite(HerosClasse classe) {
        if (classe is Guerrier) {
            return true;
        } else {
            return false;
        }
    }
    
}