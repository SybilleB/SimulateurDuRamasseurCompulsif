using System;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace SimulateurDuRamasseurCompulsif;

public static class DonneesTemporaires {

    public static string nomJoueur { get; set; }
    public static string titreHonorifique { get; set; }
    public static string genre { get; set; }
    public static string choixRaceDefinitif { get; set; }
    public static string choixClasseDefinitif { get; set; }
    
    public static Bitmap photoProfil { get; set; }
    
    
}