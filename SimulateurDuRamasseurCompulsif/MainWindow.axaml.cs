using Avalonia.Controls;
using SimulateurDuRamasseurCompulsif.userControl;

namespace SimulateurDuRamasseurCompulsif;

public partial class MainWindow : Window {

    public static MainWindow Instance;
    public MainWindow() {
        InitializeComponent();
        ecranTitre.Content = new menuEcranTitre();
        Instance = this;
    }
    public void changerEcran(UserControl nouvelEcran) {
        ecranTitre.Content = nouvelEcran;
    }
}