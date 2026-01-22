using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class choixClasse : UserControl {
    
    public choixClasse() {
        InitializeComponent();
        restrictionsClasse();
        afficherInfosClasses();
        affinite();
    }

    public void afficherInfosClasses() {
        Guerrier guerrier = new Guerrier();
        titreClasseGuerrier.Text = guerrier.nomClasse;
        descriptionGuerrier.Text = guerrier.description;
        titreTalentGuerrier.Text = guerrier.talent;
        descriptionTalentGuerrier.Text = guerrier.descriptionTalent;
        
        Mage mage = new Mage();
        titreClasseMage.Text = mage.nomClasse;
        descriptionMage.Text = mage.description;
        titreTalentMage.Text = mage.talent;
        descriptionTalentMage.Text =  mage.descriptionTalent;
        
        Voleur voleur = new Voleur();
        titreClasseVoleur.Text = voleur.nomClasse;
        descriptionVoleur.Text = voleur.description;
        titreTalentVoleur.Text = voleur.talent;
        descriptionTalentVoleur.Text = voleur.descriptionTalent;
        
        Alchimiste alchimiste = new Alchimiste();
        titreClasseAlchimiste.Text = alchimiste.nomClasse;
        descriptionAlchimiste.Text = alchimiste.description;
        titreTalentAlchimiste.Text = alchimiste.talent;
        descriptionTalentAlchimiste.Text = alchimiste.descriptionTalent;
        
        Troubadour troubadour = new Troubadour();
        titreClasseTroubadour.Text = troubadour.nomClasse;
        descriptionTroubadour.Text = troubadour.description;
        titreTalentTroubadour.Text = troubadour.talent;
        descriptionTalentTroubadour.Text = troubadour.descriptionTalent;
    }

    public void restrictionsClasse() {
        
        if (DonneesTemporaires.choixRaceDefinitif == "Elfe") {
           interdireCarte(carteTroubadour); 
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Nain") {
            interdireCarte(carteMage);
            interdireCarte(carteVoleur);
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Gobelin") {
            interdireCarte(carteMage);
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Fée") {
            interdireCarte(carteAlchimiste);
        }
    }

    public void interdireCarte(Border carte) {
        carte.Opacity = 0.3;
        carte.IsEnabled = false;
    }

    public void affinite() {

        if (DonneesTemporaires.choixRaceDefinitif == "Humain")
        {
            affiniteGuerrier.IsVisible = true;
            combinaisonForteGuerrier.IsVisible = true;
            attributBonusGuerrier.IsVisible = true;
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Elfe") {
            affiniteVoleur.IsVisible = true;
            combinaisonForteVoleur.IsVisible = true;
            combinaisonImpossibleTroubadour.IsVisible = true;
            attributBonusVoleur.IsVisible = true;
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Nain")
        {
            affiniteAlchimiste.IsVisible = true;
            combinaisonForteAlchimiste.IsVisible = true;
            combinaisonImpossibleMage.IsVisible = true;
            combinaisonImpossibleVoleur.IsVisible = true;
            attributBonusAlchimiste.IsVisible = true;
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Gobelin")
        {
            affiniteTroubadour.IsVisible = true;
            combinaisonForteTroubadour.IsVisible = true;
            combinaisonImpossibleMage.IsVisible = true;
            attributBonusTroubadour.IsVisible = true;
        }
        if (DonneesTemporaires.choixRaceDefinitif == "Fée")
        {
            affiniteMage.IsVisible = true;
            combinaisonForteMage.IsVisible = true;
            combinaisonImpossibleAlchimiste.IsVisible = true;
            attributBonusMage.IsVisible = true;
        }
    }
    
    private void onClasseClick(object? sender, RoutedEventArgs e) {
        var button = (Button)sender;
        DonneesTemporaires.hp = 100;
        DonneesTemporaires.or = 100;
        
        if (button.Name == "choixGuerrier") {
            DonneesTemporaires.choixClasseDefinitif = "Guerrier";
        } else if (button.Name == "choixMage") {
            DonneesTemporaires.choixClasseDefinitif = "Mage";
        } else if (button.Name == "choixVoleur") {
            DonneesTemporaires.choixClasseDefinitif = "Voleur";
        } else if (button.Name == "choixAlchimiste") {
            DonneesTemporaires.choixClasseDefinitif = "Alchimiste";
        } else if (button.Name == "choixTroubadour") {
            DonneesTemporaires.choixClasseDefinitif = "Troubadour";
        }
        
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new donneesPersonnage();
        }
    }

    private void onRetourClick(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixRace();
        }
    }
}