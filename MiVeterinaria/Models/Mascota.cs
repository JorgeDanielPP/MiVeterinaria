namespace MiVeterinaria.Models
{
    public class Mascota
    {
        public int IdMascota { get; set; }
        public string? Raza { get; set; }
        public int Edad { get; set; }
        public string? Sexo { get; set; }
        public string? NombreMascota { get; set; }
        public string? NombrePropietario { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateOnly FechaRegisto { get; set; }
        public bool Activo { get; set; }
    }
}
