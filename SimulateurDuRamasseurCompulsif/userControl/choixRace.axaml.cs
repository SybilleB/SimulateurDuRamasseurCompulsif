using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class choixRace : UserControl {
    public string nomJoueur;

    public choixRace()
    {
        InitializeComponent();
    }
    public choixRace(string nom) {
        InitializeComponent();
        nomJoueur = nom;
    }

    public void onRaceClick(object? sender, RoutedEventArgs routedEventArgs)
    {
        return;
    }
}