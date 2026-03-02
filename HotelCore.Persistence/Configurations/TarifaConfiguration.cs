using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelCore.Domain.Entities;

namespace HotelCore.Persistence.Configurations;

public class TarifaConfiguration : IEntityTypeConfiguration<Tarifa>
{
    public void Configure(EntityTypeBuilder<Tarifa> builder)
    {
        builder.ToTable("Tarifa");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .HasColumnName("ID_Tarifa")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.CategoriaId)
               .HasColumnName("ID_Categoria")
               .IsRequired();

        builder.Property(t => t.PrecioBase)
               .HasColumnName("Precio")
               .HasColumnType("decimal(10,2)")
               .IsRequired();

        builder.Property(t => t.VigenciaDesde)
               .HasColumnName("Fecha_Vigencia")
               .HasColumnType("date")
               .IsRequired();

        // VigenciaHasta no existe en la BD original; se omite o se agrega como nullable
        builder.Ignore(t => t.VigenciaHasta);

        builder.HasOne<CategoriaHabitacion>()
               .WithMany()
               .HasForeignKey(t => t.CategoriaId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
