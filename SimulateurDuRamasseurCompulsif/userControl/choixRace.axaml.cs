using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class choixRace : UserControl {

    public choixRace() {
        InitializeComponent();
    }

    public void onRaceClick(object? sender, RoutedEventArgs routedEventArgs) {
        var button = (Button)sender;
        
        if (button.Name == "choixHumain") {
            DonneesTemporaires.choixRaceDefinitif = "Humain";
        } else if (button.Name == "choixElfe") {
            DonneesTemporaires.choixRaceDefinitif = "Elfe";
        } else if (button.Name == "choixNain") {
            DonneesTemporaires.choixRaceDefinitif = "Nain";
        } else if (button.Name == "choixGobelin") {
            DonneesTemporaires.choixRaceDefinitif = "Gobelin";
        } else if (button.Name == "choixFee") {
            DonneesTemporaires.choixRaceDefinitif = "Fée";
        }
        
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixClasse();
        }
    }
    
    private void onRetourClick(object? sender, RoutedEventArgs e) {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new saisieNomJoueur();
        }
    }
}