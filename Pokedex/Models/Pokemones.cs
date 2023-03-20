using System;
using System.Collections.Generic;

namespace Pokedex.Models;

public partial class Pokemones
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public float Peso { get; set; }

    public int Numero { get; set; }

    public string Habilidad { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int TipoId { get; set; }

    public int EntrenadorId { get; set; }

    public virtual Entrenadores Entrenador { get; set; } = null!;

    public virtual Tipos Tipo { get; set; } = null!;
}
