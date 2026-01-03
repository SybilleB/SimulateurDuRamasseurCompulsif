using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class choixRace : UserControl {
    public string nomJoueur;
    public string choixRaceDefinitif;

    public choixRace() {
        InitializeComponent();
    }
    public choixRace(string _nomJoueur) {
        InitializeComponent();
        nomJoueur = _nomJoueur;
    }

    public void onRaceClick(object? sender, RoutedEventArgs routedEventArgs) {
        var button = (Button)sender;
        
        if (button.Name == "choixHumain") {
            choixRaceDefinitif = "Humain";
        } else if (button.Name == "choixElfe") {
            choixRaceDefinitif = "Elfe";
        } else if (button.Name == "choixNain") {
            choixRaceDefinitif = "Nain";
        } else if (button.Name == "choixGobelin") {
            choixRaceDefinitif = "Gobelin";
        } else if (button.Name == "choixFee") {
            choixRaceDefinitif = "Fée";
        }
        
        
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixClasse(nomJoueur, choixRaceDefinitif);
        }
    }
}