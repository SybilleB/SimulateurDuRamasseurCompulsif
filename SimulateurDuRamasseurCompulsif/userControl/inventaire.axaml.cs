using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SimulateurDuRamasseurCompulsif.Classes;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class inventaire : UserControl {
    public inventaire() {
        InitializeComponent();
    }
    
    public inventaire(Personnage _perso)
    {
        InitializeComponent();
        this.DataContext = _perso;
    }
    
    private void InitializeComponent()
    {
        // On remplace le "throw new NotImplementedException()" par ceci :
        AvaloniaXamlLoader.Load(this);
    }
}