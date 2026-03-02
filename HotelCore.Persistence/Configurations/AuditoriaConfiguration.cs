using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelCore.Domain.Entities;

namespace HotelCore.Persistence.Configurations;

public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
{
    public void Configure(EntityTypeBuilder<Auditoria> builder)
    {
        builder.ToTable("Auditoria");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
               .HasColumnName("ID_Auditoria")
               .ValueGeneratedOnAdd();

        builder.Property(a => a.Accion)
               .HasColumnName("Accion_Realizada")
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(a => a.Fecha)
               .HasColumnName("Fecha_Hora")
               .IsRequired()
               .HasDefaultValueSql("GETDATE()");

        builder.Property(a => a.ValoresAnteriores)
               .HasColumnName("Detalle_Operacion")
               .HasMaxLength(255);

        // ID_Usuario como FK hacia Usuario
        builder.Property<int>("UsuarioId")
               .HasColumnName("ID_Usuario")
               .IsRequired();

        builder.HasOne<Usuario>()
               .WithMany()
               .HasForeignKey("UsuarioId")
               .OnDelete(DeleteBehavior.Restrict);
    }
}