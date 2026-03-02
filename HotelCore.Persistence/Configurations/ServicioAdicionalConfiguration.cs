using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelCore.Domain.Entities;

namespace HotelCore.Persistence.Configurations;

public class ServicioAdicionalConfiguration : IEntityTypeConfiguration<ServicioAdicional>
{
    public void Configure(EntityTypeBuilder<ServicioAdicional> builder)
    {
        builder.ToTable("Servicio_Adicional");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
               .HasColumnName("ID_Servicio")
               .ValueGeneratedOnAdd();

        builder.Property(s => s.Nombre)
               .HasColumnName("Nombre")
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(s => s.Precio)
               .HasColumnName("Precio_Unitario")
               .HasColumnType("decimal(10,2)")
               .IsRequired();
    }
}