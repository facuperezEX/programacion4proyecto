using System.ComponentModel.DataAnnotations;

namespace proyecto4programacion.Entities
{
    public abstract class Registro
    {
        public int Id { get; set; }
        public int? EstadoId { get; set; }
        public string? Estado { get; set; } // Relacion One One con Estado. 
        [Display(Name = "Fecha de creación")]
        public DateOnly? FechaCreacion { get; set; }
        public int? ReferenteId { get; set; }
        public string? Referente { get; set; } // Relacion One One con Referente. Creación del Registro.

        public Registro() { }
    }
}
