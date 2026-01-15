namespace SimulateurDuRamasseurCompulsif.Classes;

public class Stats {
    public int force; 
    public int charisme;
    public int intelligence;
    public int agilite;
    public int vitalite;
    public int chance;
    public Stats() {
        force = 0; 
        charisme = 0;
        intelligence = 0;
        agilite = 0;
        vitalite = 0;
        chance = 0;
    }

    public void ajouterStats(Stats bonusStat) {
        force += bonusStat.force;
        charisme += bonusStat.charisme;
        intelligence += bonusStat.intelligence;
        agilite += bonusStat.agilite;
        vitalite += bonusStat.vitalite;
        chance += bonusStat.chance;
    }
}