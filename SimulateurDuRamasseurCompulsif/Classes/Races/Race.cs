using System;
using SimulateurDuRamasseurCompulsif.Classes;
using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

public class Race
{
    public string nomRace;
    public int or;
    public int pv;
    public Stats statsRace;
    public string description;
    public string talent;
    public string descriptionTalent;

    public Race(string _nomRace, string _description, string _talent, string _descriptionTalent) {
        nomRace = _nomRace;
        or = 100;
        pv = 100;
        description = _description;
        talent = _talent;
        descriptionTalent = _descriptionTalent;
        statsRace = new Stats();
    }

    public virtual bool classeAutorisee(HerosClasse classe) {
        return true;
    }
    
}