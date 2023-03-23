using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Catalogos
{
    public class AccionesEntrenadorCatalogo
    {
        PokedexContext contenedor = new();


        public IEnumerable<Accionesentrenadores> GetAccionesEntrenador()
        {
            return contenedor.Accionesentrenadores.OrderBy(x => x.Fecha);
        }




    }
}
