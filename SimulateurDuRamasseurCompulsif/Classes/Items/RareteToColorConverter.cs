

using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using SimulateurDuRamasseurCompulsif.Classes.Items;

namespace SimulateurDuRamasseurCompulsif.Classes.Items {
    
    public class RareteToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Rarete rarete)
            {
                switch (rarete)
                {
                    case Rarete.Commune:
                        return SolidColorBrush.Parse("#A0A0A0"); // Gris
                    case Rarete.Rare:
                        return SolidColorBrush.Parse("#4169E1"); // Bleu Roi
                    case Rarete.Epique:
                        return SolidColorBrush.Parse("#9370DB"); // Violet
                    case Rarete.Legendaire:
                        return SolidColorBrush.Parse("#FFA500"); // Orange Or
                    default:
                        return Brushes.White;
                }
            }
            return Brushes.White;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}