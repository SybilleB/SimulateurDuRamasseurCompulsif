using System;
using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Stats { //Attributs, utiles pour les méthodes virtuelles à override
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

    public void ajouterStats(Stats nouvelleStat) {
        force += nouvelleStat.force;
        charisme += nouvelleStat.charisme;
        intelligence += nouvelleStat.intelligence;
        agilite += nouvelleStat.agilite;
        vitalite += nouvelleStat.vitalite;
        chance += nouvelleStat.chance;
    }
}

public class Race {
    public string nomRace { get; set; }
    public int or;
    public int pv;
    public Stats stats;
    public string talent;
    public string descriptionTalent;

    public Race(string _nomRace, string _talent, string _descriptionTalent, Stats _stats) {
        nomRace = _nomRace;
        or = 100;
        pv = 100;
        stats = _stats;
        talent = _talent;
        descriptionTalent = _descriptionTalent;
    }

    public virtual bool classeAutorisee(HerosClasse classe) {
        return true;
    }
    
}