using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pokedex.Catalogos
{
   public class EntrenadoresCatalogo
    {
        //scaffold-dbcontext "server=localhost; password=root; user=root; database=Pokedex" Pomelo.EntityFrameworkCore.MySql -o "Models" -nopluralize -f

        PokedexContext contenedor = new();

        public IEnumerable<Entrenadores> GetEntrenadores()
        {
            return contenedor.Entrenadores.OrderBy(x => x.Nombre);  
        }

        public void Create(Entrenadores en)
        {
            contenedor.Entrenadores.Add(en);
            contenedor.SaveChanges();
        }

        public void Delete(Entrenadores en) 
        {
        
            contenedor.Remove(en);
            contenedor.SaveChanges();   
        }

        public Entrenadores GetEntrenadorXId(int id)
        {
            return contenedor.Entrenadores.Find(id);
        }


        public bool ValidarEntrenador(Entrenadores en, out List<string> errores)
        {
            errores= new List<string>();
            Regex nombreregex = new(@"[A-Za-zÑñ]{2,}(\s[A-Za-zÑñ]+)?(\s[A-Za-zÑñ]+)?(\s[A-Za-zÑñ]+)?(\s[A-Za-zÑñ]+)?");

            if (string.IsNullOrWhiteSpace(en.Nombre))
                errores.Add("El apartado nombre no puede estar vacío");
            else if (en.Nombre.Length > 100)
                errores.Add("El nombre supero el tamaño establecido");
            else if(!nombreregex.IsMatch(en.Nombre))
                errores.Add("El nombre no tiene el formato correcto");
            if (en.Edad < 12)
                errores.Add("Aun no cuentas con la edad suficiente para ser entrenador, regresa cuando hayas cumplido 12 años de edad");
            //if (en.Sexo != "M" || en.Sexo != "F")
            //    errores.Add("Error en el apartado Sexo");
            //else if(en.Sexo.Length != 1)
            //    errores.Add("Error con el tamaño en el apartado Sexo");

            return errores.Count == 0;
        }


    }
}
