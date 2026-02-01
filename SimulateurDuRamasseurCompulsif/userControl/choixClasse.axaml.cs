using Avalonia.Controls;
using Avalonia.Interactivity;
using SimulateurDuRamasseurCompulsif.Classes.HerosClasses;
using SimulateurDuRamasseurCompulsif.Classes.Races;

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
    
    public void interdireCarte(Border carte) {
        carte.Opacity = 0.2;
        carte.IsEnabled = false;
    }
    
    public Race raceTemporaire() {
        if (DonneesTemporaires.choixRaceDefinitif == "Humain") {
            return new Humain();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Elfe") {
            return new Elfe();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Nain") {
            return new Nain();
        } else if (DonneesTemporaires.choixRaceDefinitif == "Gobelin") {
            return new Gobelin();
        } else  {
            return new Fee();
        }
    }
    
    public void restrictionsClasse() {
        Race race = raceTemporaire();
        
        if (!race.classeAutorisee(new Guerrier())) {
            interdireCarte(carteGuerrier);
        }
        if (!race.classeAutorisee(new Mage())) {
            interdireCarte(carteMage);
        }
        if (!race.classeAutorisee(new Voleur())) {
            interdireCarte(carteVoleur);
        }
        if (!race.classeAutorisee(new Alchimiste())) {
            interdireCarte(carteAlchimiste);
        }
        if (!race.classeAutorisee(new Troubadour())) {
            interdireCarte(carteTroubadour);
        }
    }
    
    public void affinite() {
        Race race = raceTemporaire();
        
        combinaisonImpossibleGuerrier.IsVisible = !race.classeAutorisee(new Guerrier());
        combinaisonImpossibleMage.IsVisible = !race.classeAutorisee(new Mage());
        combinaisonImpossibleVoleur.IsVisible = !race.classeAutorisee(new Voleur());
        combinaisonImpossibleAlchimiste.IsVisible = !race.classeAutorisee(new Alchimiste());
        combinaisonImpossibleTroubadour.IsVisible = !race.classeAutorisee(new Troubadour());
        
        if (race.classeFavorite(new Guerrier())) {
            affiniteGuerrier.IsVisible = true;
            combinaisonForteGuerrier.IsVisible = true;
            attributBonusGuerrier.IsVisible = true;
        } else if (race.classeFavorite(new Mage())) {
            affiniteMage.IsVisible = true;
            combinaisonForteMage.IsVisible = true;
            attributBonusMage.IsVisible = true;
        } else if (race.classeFavorite(new Voleur())) {
            affiniteVoleur.IsVisible = true;
            combinaisonForteVoleur.IsVisible = true;
            attributBonusVoleur.IsVisible = true;
        } else if (race.classeFavorite(new Alchimiste())) {
            affiniteAlchimiste.IsVisible = true;
            combinaisonForteAlchimiste.IsVisible = true;
            attributBonusAlchimiste.IsVisible = true;
        } else if (race.classeFavorite(new Troubadour())) {
            affiniteTroubadour.IsVisible = true;
            combinaisonForteTroubadour.IsVisible = true;
            attributBonusTroubadour.IsVisible = true;
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
        
        MainWindow.Instance.changerEcran(new donneesPersonnage());
    }

    private void onRetourClick(object? sender, RoutedEventArgs e) {
        MainWindow.Instance.changerEcran(new choixRace());
    }
}