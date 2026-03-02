using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelCore.Domain.Entities;

namespace HotelCore.Persistence.Configurations;

public class ReservaServicioConfiguration : IEntityTypeConfiguration<ReservaServicio>
{
    public void Configure(EntityTypeBuilder<ReservaServicio> builder)
    {
        builder.ToTable("Reserva_Servicio");

        builder.HasKey(rs => rs.Id);

        builder.Property(rs => rs.Id)
               .HasColumnName("ID_Reserva_Servicio")
               .ValueGeneratedOnAdd();

        builder.Property(rs => rs.ReservaId)
               .HasColumnName("ID_Reserva")
               .IsRequired();

        builder.Property(rs => rs.ServicioId)
               .HasColumnName("ID_Servicio")
               .IsRequired();

        builder.HasOne<Reserva>()
               .WithMany()
               .HasForeignKey(rs => rs.ReservaId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<ServicioAdicional>()
               .WithMany()
               .HasForeignKey(rs => rs.ServicioId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
