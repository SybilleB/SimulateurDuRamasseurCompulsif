namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Humain:Race {

    public Humain(string _nom, string _genre) : base(_nom, _genre, new Stats()) {
        talent = "Volonté de fer";
    }
    
}