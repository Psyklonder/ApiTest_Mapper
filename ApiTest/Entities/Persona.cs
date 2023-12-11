using System;
using System.Collections.Generic;

namespace ApiTest.Entities;

public partial class Persona
{
    public long Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string NumeroIdentificacion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int TipoIdentificacionId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public bool Estado { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string? Identificacion { get; set; }

    public virtual TipoIdentificacion TipoIdentificacion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
