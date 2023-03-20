using System;
using System.Collections.Generic;

namespace Pokedex.Models;

public partial class Tipos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Pokemones> Pokemones { get; } = new List<Pokemones>();
}
