using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;

namespace proyecto4programacion.Entities
{
    public class Solicitud : Registro
    {
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "Seleccione fecha")]
        public DateOnly FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Seleccione fecha")]
        [Display(Name = "Fecha de Cierre")]
        public DateOnly? FechaCierre { get; set; }
        public int? ColaboradorId { get; set; }
        public string? Colaborador { get; set; } // Relacion One One con Colaborador.
        public int? ActivoId { get; set; }
        public string? Activo { get; set; } // Relacion One One con Activo.

        public Solicitud() { }
    }
}
