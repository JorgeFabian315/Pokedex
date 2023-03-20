using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Pokedex.Helpers
{
    public class ConvertidorTipos : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tipo = (string)value;


            switch (tipo)
            {
                case "Acero":
                    return "#3FA3B9";
                case "Agua":
                    return "#0094C5";//k
                case "Bicho":
                    return "#8EA123";
                case "Dragón":
                    return "#4462E0";
                case "Eléctrico":
                    return "#FFBE00";
                case "Fantasma":
                    return "#793F6E";
                case "Fuego":
                    return "#FF7500";
                case "Hada":
                    return "#FF68ED";
                case "Hielo":
                    return "#00DBFF";
                case "Lucha":
                    return "#FF7800";
                case "Normal":
                    return "#9EA19F";
                case "Planta":
                    return "#00A336";
                case "Psíquico":
                    return "#FF2A70";
                case "Roca":
                    return "#B1A981";
                case "Siniestro":
                    return "#54403E";
                case "Tierra":
                    return "#9D4D18";
                case "Veneno":
                    return "#9D3CC9";
                case "Volador":
                    return "#69BBEF";
                default:
                    return "#51A292";
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
