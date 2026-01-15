using System;
using SimulateurDuRamasseurCompulsif.Classes;
using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Race {
    public string nomRace { get; set; }
    public int or;
    public int pv;
    public Stats statsRace;
    public string talent;
    public string descriptionTalent;

    public Race(string _nomRace, string _talent, string _descriptionTalent, Stats _statsRace) {
        nomRace = _nomRace;
        or = 100;
        pv = 100;
        statsRace = _statsRace;
        talent = _talent;
        descriptionTalent = _descriptionTalent;
    }

    public virtual bool classeAutorisee(HerosClasse classe) {
        return true;
    }
    
}