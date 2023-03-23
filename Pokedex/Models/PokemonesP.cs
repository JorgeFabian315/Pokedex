using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public partial class Pokemones
    {
        public string NumeroCompleto { 
            get 
            {
                if(Numero > 0 && Numero < 10)
                    return $"N.º 000{Numero}";
                else if (Numero >= 10 && Numero < 100)
                    return $"N.º 00{Numero}";
                else if (Numero >= 100 && Numero < 1000)
                    return $"N.º 0{Numero}";
                else
                    return $"N.º {Numero}";
            }
            

        }

       public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {NumeroCompleto}";
            }
        }
      public string PokeonEliminar
        {
            get
            {
                return $"¿Está seguro que desea eliminar este pokémon: {Nombre.ToUpper()}?";
            }
        }
    }
}
