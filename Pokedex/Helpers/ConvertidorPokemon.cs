using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Pokedex.Helpers
{
    public class ConvertidorPokemon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            int id = (int)value;

            if(id > 0 && id < 10)
            {
                return $"https://assets.pokemon.com/assets/cms2/img/pokedex/full/00{id}.png";
            }
            else if (id >= 10 && id < 100)
            {
                return $"https://assets.pokemon.com/assets/cms2/img/pokedex/full/0{id}.png";
            }
            else
                return $"https://assets.pokemon.com/assets/cms2/img/pokedex/full/{id}.png";


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
