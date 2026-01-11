using Avalonia.Controls;
using Avalonia.Interactivity;
using SimulateurDuRamasseurCompulsif.userControl;

namespace SimulateurDuRamasseurCompulsif;

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();
        ecranTitre.Content = new menuEcranTitre();
    }
    
}