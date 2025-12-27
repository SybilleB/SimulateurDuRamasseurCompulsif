namespace SimulateurDuRamasseurCompulsif.Classes.Races;

public class Humain:Race {

    public Humain(string _nom, string _genre, int _poids) : base(_nom, _genre, _poids, new Stats())
    {
        talent = "Volonté de fer";
    }
    
}