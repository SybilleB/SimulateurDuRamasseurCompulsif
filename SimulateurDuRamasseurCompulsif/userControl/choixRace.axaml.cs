using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SimulateurDuRamasseurCompulsif.Classes.Races;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class choixRace : UserControl {

    public choixRace() {
        InitializeComponent();
        afficherInfosRaces();
    }

    public void afficherInfosRaces() {
        Humain humain = new Humain();
        titreRaceHumain.Text = humain.nomRace;
        descriptionHumain.Text = humain.description;
        titreTalentHumain.Text = humain.talent;
        descriptionTalentHumain.Text = humain.descriptionTalent;
        
        Elfe elfe = new Elfe();
        titreRaceElfe.Text = elfe.nomRace;
        descriptionElfe.Text = elfe.description;
        titreTalentElfe.Text = elfe.talent;
        descriptionTalentElfe.Text =  elfe.descriptionTalent;
        
        Nain nain = new Nain();
        titreRaceNain.Text = nain.nomRace;
        descriptionNain.Text = nain.description;
        titreTalentNain.Text = nain.talent;
        descriptionTalentNain.Text = nain.descriptionTalent;
        
        Gobelin gobelin = new Gobelin();
        titreRaceGobelin.Text = gobelin.nomRace;
        descriptionGobelin.Text = gobelin.description;
        titreTalentGobelin.Text = gobelin.talent;
        descriptionTalentGobelin.Text = gobelin.descriptionTalent;
        
        Fee fee = new Fee();
        titreRaceFee.Text = fee.nomRace;
        descriptionFee.Text = fee.description;
        titreTalentFee.Text = fee.talent;
        descriptionTalentFee.Text = fee.descriptionTalent;
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