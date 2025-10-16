using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyecto4programacion.Entities;

namespace proyecto4programacion.EntitiesConfiguracion
{
    public class SolicitudConfiguracion : IEntityTypeConfiguration<Solicitud>
    {
        public void Configure(EntityTypeBuilder<Solicitud> builder)
        {
            
            builder.HasKey(s => s.Id);

            builder.Property(s => s.EstadoId).IsRequired();
            builder.Property(s => s.FechaCreacion).IsRequired();
            builder.Property(s => s.FechaInicio).IsRequired();
            builder.Property(s => s.FechaCierre).IsRequired();
            builder.Property(s => s.ReferenteId).IsRequired();
            builder.Property(s => s.ColaboradorId).IsRequired();
            builder.Property(s => s.ActivoId).IsRequired();

            builder.Ignore(s => s.Referente);
            builder.Ignore(s => s.Estado);
            builder.Ignore(s => s.Colaborador);
            builder.Ignore(s => s.Activo);
        }
    }
}
