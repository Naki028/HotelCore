using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelCore.Domain.Entities;

namespace HotelCore.Persistence.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
               .HasColumnName("ID_Cliente")
               .ValueGeneratedOnAdd();

        builder.Property(c => c.NombreCompleto)
               .HasColumnName("Nombre")
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(c => c.Documento)
               .HasColumnName("Documento_Identidad")
               .HasMaxLength(20)
               .IsRequired();

        builder.HasIndex(c => c.Documento)
               .IsUnique();

        builder.Property(c => c.Email)
               .HasColumnName("Correo")
               .HasMaxLength(100)
               .IsRequired();

        builder.HasIndex(c => c.Email)
               .IsUnique();

        builder.Property(c => c.Telefono)
               .HasColumnName("Telefono")
               .HasMaxLength(20);
    }
}
