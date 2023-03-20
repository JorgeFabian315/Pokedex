using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Catalogos
{
    public class PokemonCatalogo
    {
        PokedexContext contenedor = new();

        public IEnumerable<Pokemones> GetPokemons(int id)
        {
            return contenedor.Pokemones.Include(x => x.Tipo).Include(p => p.Entrenador).Where(x => x.EntrenadorId == id).OrderBy(c => c.Numero);
        }

        public IEnumerable<Tipos> GetTipos() 
        {
            return contenedor.Tipos.OrderBy(x => x.Nombre);
        
        }

        public void Delete(Pokemones poke)
        {
            contenedor.Pokemones.Remove(poke);
            contenedor.SaveChanges();

        }

        public void Create(Pokemones poke)
        {
            contenedor.Pokemones.Add(poke);
            contenedor.SaveChanges();
        }

        public bool Validar(Pokemones poke, out List<string> errores)
        {
            errores = new();

            if (string.IsNullOrWhiteSpace(poke.Nombre))
                errores.Add("El apartado nombre no puede estar vacío");
            else if(poke.Nombre.Length > 100)
                errores.Add("El apartado nombre ha superado el tamaño establecido");
           
            if (poke.Peso < 1)
                errores.Add("El peso esta incorrecto");

            if (poke.Numero == 0)
                errores.Add("El número esta incorrecto");
            else if (contenedor.Pokemones.Any(x => x.Numero == poke.Numero && x.Id != poke.Id))
                errores.Add("El número ya existe");

            if (string.IsNullOrWhiteSpace(poke.Habilidad))
                errores.Add("El apartado habilidad no puede estar vacío");
            else if (poke.Habilidad.Length > 100)
                errores.Add("El apartado habilidad ha superado el tamaño establecido");

            //if (poke.TipoId == 0)
            //    errores.Add("El tipo esta incorrecto");

            //if (poke.EntrenadorId == 0)
            //    errores.Add("El entrenador esta incorrecto");




            return errores.Count == 0;
        }


    }
}
