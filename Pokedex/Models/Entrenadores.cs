using System;
using System.Collections.Generic;

namespace Pokedex.Models;

public partial class Entrenadores
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public sbyte Edad { get; set; }

    public string Sexo { get; set; } = null!;

    public virtual ICollection<Pokemones> Pokemones { get; } = new List<Pokemones>();
}
