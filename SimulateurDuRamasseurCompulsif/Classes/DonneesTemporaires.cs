using System;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
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
}