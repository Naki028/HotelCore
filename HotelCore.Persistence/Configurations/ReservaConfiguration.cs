using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelCore.Domain.Entities;

namespace HotelCore.Persistence.Configurations;

public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.ToTable("Reserva");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
               .HasColumnName("ID_Reserva")
               .ValueGeneratedOnAdd();

        builder.Property(r => r.ClienteId)
               .HasColumnName("ID_Cliente")
               .IsRequired();

        builder.Property(r => r.HabitacionId)
               .HasColumnName("ID_Habitacion")
               .IsRequired();

        // El enum EstadoReserva se guarda como string (Estado VARCHAR(20))
        builder.Property(r => r.Estado)
               .HasColumnName("Estado")
               .HasMaxLength(20)
               .IsRequired()
               .HasConversion<string>();

        builder.Property(r => r.FechaInicio)
               .HasColumnName("Fecha_Inicio")
               .HasColumnType("date")
               .IsRequired();

        builder.Property(r => r.FechaFin)
               .HasColumnName("Fecha_Fin")
               .HasColumnType("date")
               .IsRequired();

        builder.Property(r => r.Total)
               .HasColumnName("Total")
               .HasColumnType("decimal(10,2)");

        builder.HasOne<Cliente>()
               .WithMany()
               .HasForeignKey(r => r.ClienteId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Habitacion>()
               .WithMany()
               .HasForeignKey(r => r.HabitacionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
