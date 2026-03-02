using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelCore.Domain.Entities;

namespace HotelCore.Persistence.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
               .HasColumnName("ID_Usuario")
               .ValueGeneratedOnAdd();

        builder.Property(u => u.Username)
               .HasColumnName("Nombre_Usuario")
               .HasMaxLength(50)
               .IsRequired();

        builder.HasIndex(u => u.Username)
               .IsUnique();

        builder.Property(u => u.PasswordHash)
               .HasColumnName("Password")
               .HasMaxLength(255)
               .IsRequired();

        // El enum RolUsuario se guarda como string (Rol VARCHAR(20))
        builder.Property(u => u.Rol)
               .HasColumnName("Rol")
               .HasMaxLength(20)
               .IsRequired()
               .HasConversion<string>();
    }
}