using System;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace SimulateurDuRamasseurCompulsif.Classes.Items;

public enum Rarete {
    Commune,
    Rare,
    Epique,
    Legendaire,
    Autre
}

public enum TypeItem {
    Arme,
    Armure,
    Livre, 
    Bijou,
    Potion,
    Instrument,
    ObjetQuete,
    Consommable
}

public class InventaireStuff {
    public string nomItem;
    public string descriptionItem;
    public TypeItem typeItem;
    public Rarete rareteItem;
    public Bitmap fichierImage;

    public IBrush couleurBorder;
    public IBrush couleurBackground;

    public InventaireStuff(string _nomItem, string _descriptionItem, TypeItem _typeItem, Rarete _rareteItem, string _fichierImage) {
        nomItem = _nomItem;
        descriptionItem = _descriptionItem;
        typeItem = _typeItem;
        rareteItem = _rareteItem;
        
        var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/itemsClasses/{_fichierImage}");
        fichierImage = new Bitmap(AssetLoader.Open(uri));

        definirCouleur(_rareteItem);
    }

    public void definirCouleur(Rarete rarete) {
        string hexBorder;
        string hexBackground;

        if (rarete == Rarete.Commune) {
            hexBorder = "#965A38";
            hexBackground = "#2B1D16";
        } else if (rarete == Rarete.Rare) {
            hexBorder = "#D1D5DB";
            hexBackground = "#1F2937";
        } else if (rarete == Rarete.Epique) {
            hexBorder = "#F1C40F";
            hexBackground = "#2D220D";
        } else if (rarete == Rarete.Legendaire) {
            hexBorder = "#00F5FF";
            hexBackground = "#05161A";
        } else {
            hexBorder = "#444";
            hexBackground = "#252525";
        }
        couleurBackground = SolidColorBrush.Parse(hexBackground);
        couleurBorder = SolidColorBrush.Parse(hexBorder);
    }
}