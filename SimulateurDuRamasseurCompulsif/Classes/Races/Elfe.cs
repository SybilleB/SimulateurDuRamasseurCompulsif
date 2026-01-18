using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Elfe : Race {
    
    public Elfe() : base("Elfe", "Etre gracieux et agile, maître de l'arc et de la magie naturelle.", "Vision Nocturne", "Repère les pièges assez tôt pour ne pas abimer ses cheveux.", new Stats()) {
        statsRace.intelligence = 1;
        statsRace.agilite = 1;
        statsRace.chance = 1;
        statsRace.vitalite = -3;
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