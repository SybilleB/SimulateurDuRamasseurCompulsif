using System;
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

public class InventaireStuff
{
    public string nomItem;
    public string descriptionItem;
    public TypeItem typeItem;
    public Rarete rareteItem;
    public Bitmap fichierImage;

    public InventaireStuff(string _nomItem, string _descriptionItem, TypeItem _typeItem, Rarete _rareteItem, string _fichierImage) {
        nomItem = _nomItem;
        descriptionItem = _descriptionItem;
        typeItem = _typeItem;
        rareteItem = _rareteItem;
        
        var uri = new Uri($"avares://SimulateurDuRamasseurCompulsif/assets/pictures/itemsClasses/{_fichierImage}");
        fichierImage = new Bitmap(AssetLoader.Open(uri));
    }
    
}