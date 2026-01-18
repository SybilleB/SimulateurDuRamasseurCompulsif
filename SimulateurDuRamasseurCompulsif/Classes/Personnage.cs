using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;
using SimulateurDuRamasseurCompulsif.Classes.Races;
using SimulateurDuRamasseurCompulsif.Classes.Items;
using System.Collections.Generic;
using System;
using Avalonia.Media.Imaging;

namespace SimulateurDuRamasseurCompulsif.Classes;

public class Personnage
{
    public string nomJoueur;
    public string titreHonorifique;
    public Bitmap photoProfil;
    public string genre;
    public Race race;
    public HerosClasse classe;
    public Stats statsPerso;
    public List<InventaireStuff> Inventaire = new List<InventaireStuff>();
    public int capaciteMax = 10;
    
    public Personnage(string _nomJoueur, string _titreHonorifique, Bitmap _photoProfil, string _genre, Race _race, HerosClasse _classe, Stats _stats) {
        
        nomJoueur = _nomJoueur;
        titreHonorifique = _titreHonorifique;
        photoProfil = _photoProfil;
        genre = _genre;
        race = _race;
        classe = _classe;
        statsPerso = _stats;
    }

    public void afficherInventaire() {
        foreach (var item in Inventaire) {
            Console.WriteLine(item.nomItem + item.descriptionItem + item.rareteItem);
        }
    }

    public void ajouterItem(InventaireStuff inventaireStuff) {
        if (Inventaire.Count < capaciteMax) {
            Inventaire.Add(inventaireStuff);
            Console.WriteLine("Hop ! Emballé, c'est pesé. " + inventaireStuff.nomItem + " a bien été ajouté à l'inventaire");
        }
        else {
            Console.WriteLine("Même en tassant avec le pied, ça ne rentre plus");
        }
    }

    public void retirerItem(InventaireStuff inventaireStuff) {
        Inventaire.Remove(inventaireStuff);
        Console.WriteLine("C'était encombrant, et honnêtement, un peu moche. " + inventaireStuff.nomItem + " a bien été retiré de l'inventaire");
    }
    
}