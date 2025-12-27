using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class choixClasse : UserControl {
    public string nomJoueur;
    public string choixRaceDefinitif;
    public string choixClasseDefinitif;
    
    public choixClasse() {
        InitializeComponent();
    }
    public choixClasse(string _nomJoueur, string _choixRaceDefinitif) {
        InitializeComponent();
        nomJoueur = _nomJoueur;
        choixRaceDefinitif = _choixRaceDefinitif;
        restrictionsClasse();
        affinite();
    }

    public void restrictionsClasse() {
        var carteGuerrier = this.FindControl<Border>("carteGuerrier");
        var carteMage = this.FindControl<Border>("carteMage");
        var carteVoleur = this.FindControl<Border>("carteVoleur");
        var carteAlchimiste = this.FindControl<Border>("carteAlchimiste");
        var carteTroubadour = this.FindControl<Border>("carteTroubadour");

        
        if (choixRaceDefinitif == "Elfe") {
           interdireCarte(carteTroubadour); 
        }
        if (choixRaceDefinitif == "Nain") {
            interdireCarte(carteMage);
            interdireCarte(carteVoleur);
        }
        if (choixRaceDefinitif == "Gobelin") {
            interdireCarte(carteMage);
        }
        if (choixRaceDefinitif == "Fee") {
            interdireCarte(carteTroubadour);
        }
    }

    public void interdireCarte(Border carte) {
        carte.Opacity = 0.3;
        carte.IsEnabled = false;
    }

    public void affinite() {
        
        var affiniteGuerrier = this.FindControl<Border>("affiniteGuerrier");
        var combinaisonForteGuerrier = this.FindControl<TextBlock>("combinaisonForteGuerrier");
        var combinaisonImpossibleGuerrier = this.FindControl<TextBlock>("combinaisonImpossibleGuerrier");
        var attributBonusGuerrier = this.FindControl<TextBlock>("attributBonusGuerrier");
        
        var affiniteMage = this.FindControl<Border>("affiniteMage");
        var combinaisonForteMage = this.FindControl<TextBlock>("combinaisonForteMage");
        var combinaisonImpossibleMage = this.FindControl<TextBlock>("combinaisonImpossibleMage");
        var attributBonusMage = this.FindControl<TextBlock>("attributBonusMage");
        
        var affiniteVoleur = this.FindControl<Border>("affiniteVoleur");
        var combinaisonForteVoleur = this.FindControl<TextBlock>("combinaisonForteVoleur");
        var combinaisonImpossibleVoleur = this.FindControl<TextBlock>("combinaisonImpossibleVoleur");
        var attributBonusVoleur = this.FindControl<TextBlock>("attributBonusVoleur");
        
        var affiniteAlchimiste = this.FindControl<Border>("affiniteAlchimiste");
        var combinaisonForteAlchimiste = this.FindControl<TextBlock>("combinaisonForteAlchimiste");
        var combinaisonImpossibleAlchimiste = this.FindControl<TextBlock>("combinaisonImpossibleAlchimiste");
        var attributBonusAlchimiste = this.FindControl<TextBlock>("attributBonusAlchimiste");
        
        var affiniteTroubadour = this.FindControl<Border>("affiniteTroubadour");
        var combinaisonForteTroubadour = this.FindControl<TextBlock>("combinaisonForteTroubadour");
        var combinaisonImpossibleTroubadour = this.FindControl<TextBlock>("combinaisonImpossibleTroubadour");
        var attributBonusTroubadour = this.FindControl<TextBlock>("attributBonusTroubadour");


        if (choixRaceDefinitif == "Humain")
        {
            affiniteGuerrier.IsVisible = true;
            combinaisonForteGuerrier.IsVisible = true;
            attributBonusGuerrier.IsVisible = true;
        }
        if (choixRaceDefinitif == "Elfe") {
            affiniteVoleur.IsVisible = true;
            combinaisonForteVoleur.IsVisible = true;
            combinaisonImpossibleTroubadour.IsVisible = true;
            attributBonusVoleur.IsVisible = true;
        }
        if (choixRaceDefinitif == "Nain")
        {
            affiniteAlchimiste.IsVisible = true;
            combinaisonForteAlchimiste.IsVisible = true;
            combinaisonImpossibleMage.IsVisible = true;
            combinaisonImpossibleVoleur.IsVisible = true;
            attributBonusAlchimiste.IsVisible = true;
        }
        if (choixRaceDefinitif == "Gobelin")
        {
            affiniteTroubadour.IsVisible = true;
            combinaisonForteTroubadour.IsVisible = true;
            combinaisonImpossibleMage.IsVisible = true;
            attributBonusTroubadour.IsVisible = true;
        }
        if (choixRaceDefinitif == "Fee")
        {
            affiniteMage.IsVisible = true;
            combinaisonForteMage.IsVisible = true;
            combinaisonImpossibleAlchimiste.IsVisible = true;
            attributBonusMage.IsVisible = true;
        }
        
    }
    
    private void onClasseClick(object? sender, RoutedEventArgs e) {
        var button = (Button)sender;
        
        if (button.Name == "choixGuerrier") {
            choixClasseDefinitif = "Guerrier";
        } else if (button.Name == "choixMage") {
            choixClasseDefinitif = "Mage";
        } else if (button.Name == "choixVoleur") {
            choixClasseDefinitif = "Voleur";
        } else if (button.Name == "choixAlchimiste") {
            choixClasseDefinitif = "Alchimiste";
        } else if (button.Name == "choixTroubadour") {
            choixClasseDefinitif = "Troubadour";
        }
        
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new donneesPersonnage(nomJoueur, choixRaceDefinitif, choixClasseDefinitif);
        }
    }

    private void onRetourClick(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixRace(nomJoueur);
        }
    }
}