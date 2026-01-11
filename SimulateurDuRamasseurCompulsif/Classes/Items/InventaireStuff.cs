namespace SimulateurDuRamasseurCompulsif.Classes.Items;

public enum Rarete {
    Commune,
    Rare,
    Epique,
    Legendaire
}

public enum TypeItem {
    Arme,
    Armure,
    Livre, 
    Bijou,
    Potion
}

public class InventaireStuff {
    public string nomItem { get; set; }
    public string descriptionItem { get; set; }
    public TypeItem typeItem;
    public Rarete rareteItem { get; set; }
    public int valeurOr { get; set; }

    public InventaireStuff(string _nomItem, string _descriptionItem, TypeItem _typeItem, Rarete _rareteItem, int _valeurOr) {
        nomItem = _nomItem;
        descriptionItem = _descriptionItem;
        typeItem = _typeItem;
        rareteItem = _rareteItem;
        valeurOr = _valeurOr;
    }
    
}