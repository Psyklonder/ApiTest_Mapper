namespace ApiTest.DTO
{
    public class PersonaDTO
    {
        public long Id { get; set; }       

        public string NumeroIdentificacion { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string TipoIdentificacion { get; set; }=null!;

        public DateTime FechaCreacion { get; set; }

        public bool Estado { get; set; }

        public string NombreCompleto { get; set; } = null!;

        public string? Identificacion { get; set; }
    }
}
