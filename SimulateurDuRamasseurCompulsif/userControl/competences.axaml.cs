using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SimulateurDuRamasseurCompulsif.Classes;
using SimulateurDuRamasseurCompulsif.Classes.Races;
using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;


namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class competences : UserControl {
    public string nomJoueur;
    public string choixRaceDefinitif;
    public string choixClasseDefinitif;
    public string genre;

    public competences() {
        InitializeComponent();
    }
    public competences(string _nomJoueur, string _choixRaceDefinitif, string _choixClasseDefinitif, string _genre) {
        InitializeComponent();
        nomJoueur = _nomJoueur;
        choixRaceDefinitif = _choixRaceDefinitif;
        choixClasseDefinitif = _choixClasseDefinitif;
        genre = _genre;
    }

    public void creationPersonnage() {

        Race racePersonnage = null;
        HerosClasse classePersonnage = null;
        
        if (choixRaceDefinitif == "Humain") {
            racePersonnage = new Humain(nomJoueur, genre);
        }
        if (choixRaceDefinitif == "Elfe") {
            racePersonnage = new Elfe(nomJoueur, genre);
        }
        if (choixRaceDefinitif == "Nain") {
            racePersonnage = new Nain(nomJoueur, genre);
        }
        if (choixRaceDefinitif == "Gobelin") {
            racePersonnage = new Gobelin(nomJoueur, genre);
        }
        if (choixRaceDefinitif == "Fée") {
            racePersonnage = new Fee(nomJoueur, genre);
        }

        if (choixClasseDefinitif == "Guerrier") {
            classePersonnage = new Guerrier();
        }
        if (choixClasseDefinitif == "Mage") {
            classePersonnage = new Mage();
        }
        if (choixClasseDefinitif == "Voleur") {
            classePersonnage = new Voleur();
        }
        if (choixClasseDefinitif == "Alchimiste") {
            classePersonnage = new Alchimiste();
        }
        if (choixClasseDefinitif == "Troubadour") {
            classePersonnage = new Troubadour();
        }

        Personnage p = new Personnage(racePersonnage, classePersonnage);

    }
}