using System;
using System.Collections.Generic;

namespace Pokedex.Models;

public partial class Accionesentrenadores
{
    public int Id { get; set; }

    public string? Observacion { get; set; }

    public string? Usuario { get; set; }

    public DateTime? Fecha { get; set; }
}
