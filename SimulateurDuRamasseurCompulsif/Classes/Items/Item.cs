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

public class Item {
    public string nomItem;
    public string descriptionItem;
    public TypeItem typeItem;
    public Rarete rareteItem;
    public int valeurOr;

    public Item(string _nomItem, string _descriptionItem, TypeItem _typeItem, Rarete _rareteItem, int _valeurOr) {
        nomItem = _nomItem;
        descriptionItem = _descriptionItem;
        typeItem = _typeItem;
        rareteItem = _rareteItem;
        valeurOr = _valeurOr;
    }
    
}