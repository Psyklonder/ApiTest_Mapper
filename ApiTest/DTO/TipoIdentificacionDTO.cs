﻿namespace ApiTest.DTO
{
    public class TipoIdentificacionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
