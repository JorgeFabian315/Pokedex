using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public partial class Entrenadores
    {
        public string EdadCompleta { get { return $"Edad: {Edad}"; } }
        public string EntrenadoresEliminar { get { return $"¿Esta seguro que desea elimiar al entrenador {Nombre.ToUpper()} con la edad de {Edad}?"; } }
    }
}
