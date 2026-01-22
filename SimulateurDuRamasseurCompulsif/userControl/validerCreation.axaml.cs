using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using SimulateurDuRamasseurCompulsif.Classes;

namespace SimulateurDuRamasseurCompulsif.userControl;

public partial class validerCreation : UserControl
{
    public validerCreation()
    {
        InitializeComponent();
        RemplirFiche();
    }

    private void RemplirFiche()
    {
        Personnage p = DonneesTemporaires.personnageFinal;

        if (p != null)
        {
            imgAvatarFinal.Source = p.photoProfil;
            txtNomFinal.Text = p.nomJoueur.ToUpper();
            txtTitreFinal.Text = p.titreHonorifique;
            
            txtRaceFinal.Text = DonneesTemporaires.choixRaceDefinitif;
            txtClasseFinal.Text = DonneesTemporaires.choixClasseDefinitif;

            valForce.Text = p.statsPerso.force.ToString() + " pts";
            valAgi.Text = p.statsPerso.agilite.ToString() + " pts";
            valVitalite.Text = p.statsPerso.vitalite.ToString() + " pts";
            valIntel.Text = p.statsPerso.intelligence.ToString() + " pts";
            valCharisme.Text = p.statsPerso.charisme.ToString() + " pts";
            valChance.Text = p.statsPerso.chance.ToString() + " pts";
        }
    }

    public async void OnExporterClick(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;

        // CORRECTION ICI : La syntaxe est nettoyée
        var fichier = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Sauvegarder ma fiche",
            DefaultExtension = "png",
            SuggestedFileName = $"Fiche_{txtNomFinal.Text}.png",
            FileTypeChoices = new[]
            {
                new FilePickerFileType("Image PNG")
                {
                    Patterns = new[] { "*.png" },
                    AppleUniformTypeIdentifiers = new[] { "public.png" },
                    MimeTypes = new[] { "image/png" }
                }
            }
        });

        if (fichier != null)
        {
            Control cible = this.FindControl<Control>("cartePersonnage");

            if (cible != null) // Petite sécurité supplémentaire
            {
                var taillePixel = new PixelSize((int)cible.Bounds.Width, (int)cible.Bounds.Height);
                var bitmap = new RenderTargetBitmap(taillePixel, new Vector(96, 96));
                bitmap.Render(cible);

                using (var stream = await fichier.OpenWriteAsync())
                {
                    bitmap.Save(stream);
                }
            }
        }
    }

    // J'ai supprimé la ligne "public FilePickerFileType[] FileTypeChoices;" qui était ici
    // car elle était inutile et causait des erreurs.

    public void onRetourClick(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow)
        {
            mainWindow.ecranTitre.Content = new inventaire();
        }
    }
    
    public void OnTerminerClick(object? sender, RoutedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Aventure commencée !");
    }
}