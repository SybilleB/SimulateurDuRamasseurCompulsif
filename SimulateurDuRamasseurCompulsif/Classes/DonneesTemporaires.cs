using Avalonia.Media.Imaging;
using SimulateurDuRamasseurCompulsif.Classes;

namespace SimulateurDuRamasseurCompulsif;

public static class DonneesTemporaires {

    public static string nomJoueur;
    public static string titreHonorifique;
    public static Bitmap photoProfil;
    public static string genre;
    public static int hp;
    public static int or;
    public static string choixRaceDefinitif;
    public static string choixClasseDefinitif;

    
    public static Personnage personnageFinal;
    
    public static void reinitialiser() {
        nomJoueur = "";
        titreHonorifique = "";
        photoProfil = null;
        genre = "";
        hp = 0; 
        or = 0;
        choixRaceDefinitif = null;
        choixClasseDefinitif = null;
        personnageFinal = null;
    }
}