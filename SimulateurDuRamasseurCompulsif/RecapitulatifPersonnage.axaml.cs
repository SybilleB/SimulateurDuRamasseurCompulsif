using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using SimulateurDuRamasseurCompulsif.Classes;
using SimulateurDuRamasseurCompulsif.userControl;


namespace SimulateurDuRamasseurCompulsif;

public partial class RecapitulatifPersonnage : Window {
    public RecapitulatifPersonnage() {
        InitializeComponent();
        chargerDonneesPersonnage();
    }

    public Personnage personnage = DonneesTemporaires.personnageFinal;
    private void chargerDonneesPersonnage() {
        
        txtNomJoueur.Text = personnage.nomJoueur;
        titreHonorifique.Text = personnage.titreHonorifique;
        txtRace.Text = personnage.race.nomRace;
        txtClasse.Text = personnage.classe.nomClasse;
        genre.Text = personnage.genre; 

        imgAvatarJoueur.Source = personnage.photoProfil;
        
        
        statForce.Text = personnage.statsPerso.force.ToString();
        statAgilite.Text = personnage.statsPerso.agilite.ToString();
        statVitalite.Text = personnage.statsPerso.vitalite.ToString();
        statIntelligence.Text = personnage.statsPerso.intelligence.ToString();
        statCharisme.Text = personnage.statsPerso.charisme.ToString();
        statChance.Text = personnage.statsPerso.chance.ToString();
        
        nbHP.Text = $"{DonneesTemporaires.hp}";
        nbOr.Text = $"{DonneesTemporaires.or}";
        
        afficherItem(imgItem1, borderItem1, "item1");
        afficherItem(imgItem2, borderItem2, "item2");
        afficherItem(imgItem3, borderItem3, "item3");
        afficherItem(imgItem4, borderItem4, "item4");
        afficherItem(imgItem5, borderItem5, "item5");
        afficherItem(imgItem6, borderItem6, "item6");
        afficherItem(imgItem7, borderItem7, "item7");
        afficherItem(imgItem8, borderItem8, "item8");
    }
    
    private void afficherItem(Image numeroImage, Border numeroBorder, string cleItem) {
        if (personnage.Inventaire.ContainsKey(cleItem)) {
            var item = personnage.Inventaire[cleItem];
            numeroImage.Source = item.fichierImage;

            numeroBorder.BorderBrush = item.couleurBorder;
            
        } else {
            numeroImage.Source = null;
            numeroBorder.BorderBrush = SolidColorBrush.Parse("#444");
            numeroBorder.Opacity = 0.3;
        }
    }

    private void OnMenuClick(object? sender, RoutedEventArgs e) {
        DonneesTemporaires.reinitialiser();
        var mainWindow = new MainWindow();
        mainWindow.ecranTitre.Content = new menuEcranTitre();
        mainWindow.Show();
        this.Close();
    }
}