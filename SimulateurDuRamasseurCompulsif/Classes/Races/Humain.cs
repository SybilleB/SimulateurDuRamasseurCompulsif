namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Humain:Race {

    public Humain(string _genre) : base("Humain", _genre, new Stats()) {
        talent = "Volonté de fer";
    }
    
}