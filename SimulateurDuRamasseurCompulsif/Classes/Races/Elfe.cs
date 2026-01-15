using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Elfe : Race
{

    public string talent;
    public string _descriptionTalent;
    
    public Elfe() : base("Elfe", "Vision Nocturne", "Repère les pièges assez tôt pour ne pas abimer ses cheveux.", new Stats()) {
        stats.intelligence += 1;
        stats.agilite += 1;
        stats.chance += 1;
        stats.vitalite -= 3;
    }

    public override bool classeAutorisee(HerosClasse classe) {
        if (classe is Guerrier || classe is Mage || classe is Voleur || classe is Alchimiste) {
            return true;
        }
        else {
            return false;
        }
    }
}