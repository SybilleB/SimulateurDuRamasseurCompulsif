using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;
using SimulateurDuRamasseurCompulsif.Classes.Items;
using System.Collections.Generic;
using System;
using Avalonia.Media.Imaging;

namespace SimulateurDuRamasseurCompulsif.Classes;

public class Personnage {
    public string nomJoueur;
    public string titreHonorifique;
    public Bitmap photoProfil;
    public string genre;
    public Race race;
    public HerosClasse classe;
    public Stats statsPerso;
    public Dictionary<string, InventaireStuff> Inventaire;
    public int capaciteMax = 10;
    
    public Personnage(string _nomJoueur, string _titreHonorifique, Bitmap _photoProfil, string _genre, Race _race, HerosClasse _classe, Stats _stats) {
        nomJoueur = _nomJoueur;
        titreHonorifique = _titreHonorifique;
        photoProfil = _photoProfil;
        genre = _genre;
        race = _race;
        classe = _classe;
        statsPerso = _stats;
        Inventaire = new Dictionary<string, InventaireStuff>();
    }
    

    public void ajouterItem(InventaireStuff inventaireStuff) {
        if (Inventaire.Count < capaciteMax) {
            int i = 1;
            while (Inventaire.ContainsKey("item" + i)) {
                i++;
            }
            string nouvelleCle = "item" + i;
            Inventaire.Add(nouvelleCle, inventaireStuff);
            Console.WriteLine("Hop ! Emballé, c'est pesé. " + inventaireStuff.nomItem + " a bien été ajouté à l'inventaire");
        } else {
            Console.WriteLine("Même en tassant avec le pied, ça ne rentre plus");
        }
    }

    public void retirerItem(string cleItem) {
        Inventaire.Remove(cleItem);
        Console.WriteLine("C'était encombrant, et honnêtement, un peu moche. ");
    }
    
}