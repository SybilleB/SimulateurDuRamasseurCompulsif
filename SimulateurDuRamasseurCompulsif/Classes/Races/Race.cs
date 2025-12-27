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

    public void afficherStats() {
        Console.Write("\nForce : " + force + "\nCharisme : " + charisme + "\nIntelligence : " + intelligence + 
                      "\nAgilité : " + agilite + "\nVitalité : " + vitalite + "\nChance : " + chance + "\n");
    }
}

public class Race {
    public string nom;
    public string genre;
    public int poids;
    public int or;
    public int pv;
    public Stats stats;
    public string talent;

    public Race(string _nom, string _genre, int _poids, Stats _stats) {
        nom = _nom;
        genre = _genre;
        poids = _poids;
        or = 100;
        pv = 100;
        stats = _stats;
        talent = "";
    }

    public void afficherInfos() {
        
        Console.Write("Nom du personnage : " + nom + "\nGenre : " + genre + "\nPoids : " + poids + 
                      " kg" + "\nPoints de vie : " + pv + "\n");
        stats.afficherStats();
    }

    public virtual bool classeAutorisee(HerosClasse classe) {
        return true;
    }
    
}