using System;
using System.Collections.Generic;

namespace ApiTest.Entities;

public partial class TipoIdentificacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Persona> Persona { get; set; } = new List<Persona>();
}
