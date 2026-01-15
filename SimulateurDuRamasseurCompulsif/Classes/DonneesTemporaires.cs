using System;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using SimulateurDuRamasseurCompulsif.Classes;

namespace SimulateurDuRamasseurCompulsif;

public static class DonneesTemporaires {

    public static string nomJoueur { get; set; }
    public static string titreHonorifique { get; set; }
    public static string genre { get; set; }
    public static string choixRaceDefinitif { get; set; }
    public static string choixClasseDefinitif { get; set; }
    
    public static Bitmap photoProfil { get; set; }
    
    public static int bonusForce { get; set; }
    public static int bonusAgilite { get; set; }
    public static int bonusVitalite { get; set; }
    public static int bonusIntelligence { get; set; }
    public static int bonusCharisme { get; set; }
    public static int bonusChance { get; set; }
    
    public static Personnage personnageFinal {get; set;}
}