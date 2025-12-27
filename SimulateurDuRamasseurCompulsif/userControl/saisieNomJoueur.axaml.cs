using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class saisieNomJoueur : UserControl
{
    public saisieNomJoueur()
    {
        InitializeComponent();
    }

    private void onConfirmerNomClick(object? sender, RoutedEventArgs e)
    {
        string nomJoueurChoisi = inputNomJoueur.Text;

        if (VisualRoot is MainWindow mainWindow){
            mainWindow.ecranTitre.Content = new choixRace(nomJoueurChoisi);
        }
    }
}