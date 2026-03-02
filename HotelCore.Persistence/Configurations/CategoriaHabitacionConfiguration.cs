using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelCore.Domain.Entities;

namespace HotelCore.Persistence.Configurations;

public class CategoriaHabitacionConfiguration : IEntityTypeConfiguration<CategoriaHabitacion>
{
    public void Configure(EntityTypeBuilder<CategoriaHabitacion> builder)
    {
        builder.ToTable("Categoria_Habitacion");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
               .HasColumnName("ID_Categoria")
               .ValueGeneratedOnAdd();

        builder.Property(c => c.Nombre)
               .HasColumnName("Nombre")
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(c => c.Descripcion)
               .HasColumnName("Descripcion")
               .HasMaxLength(150);
    }
}