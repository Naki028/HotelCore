using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelCore.Domain.Entities;

namespace HotelCore.Persistence.Configurations;

public class HabitacionConfiguration : IEntityTypeConfiguration<Habitacion>
{
    public void Configure(EntityTypeBuilder<Habitacion> builder)
    {
        builder.ToTable("Habitacion");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
               .HasColumnName("ID_Habitacion")
               .ValueGeneratedOnAdd();

        builder.Property(h => h.Numero)
               .HasColumnName("Numero")
               .HasMaxLength(10)
               .IsRequired();

        builder.HasIndex(h => h.Numero)
               .IsUnique();

        // El enum EstadoHabitacion se guarda como string en la BD (Estado VARCHAR(20))
        builder.Property(h => h.Estado)
               .HasColumnName("Estado")
               .HasMaxLength(20)
               .IsRequired()
               .HasConversion<string>();

        builder.Property(h => h.CategoriaId)
               .HasColumnName("ID_Categoria")
               .IsRequired();

        builder.HasOne<CategoriaHabitacion>()
               .WithMany()
               .HasForeignKey(h => h.CategoriaId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}