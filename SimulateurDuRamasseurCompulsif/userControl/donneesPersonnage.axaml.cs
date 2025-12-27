using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class donneesPersonnage : UserControl {
    
    public string nomJoueur;
    public string choixRaceDefinitif;
    public string choixClasseDefinitif;
    
    public donneesPersonnage() {
        InitializeComponent();
    }

    public donneesPersonnage(string _nomJoueur, string _choixRaceDefinitif, string _choixClasseDefinitif) {
        InitializeComponent();
        nomJoueur = _nomJoueur;
        choixRaceDefinitif = _choixRaceDefinitif;
        choixClasseDefinitif = _choixClasseDefinitif;
    }


    private void onRetourClick(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixClasse(nomJoueur, choixRaceDefinitif);
        }
    }

    private void onValiderClick(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixClasse(nomJoueur, choixRaceDefinitif);
        }
    }
}