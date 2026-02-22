using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using HotelCore.Domain.Entities;

namespace HotelCore.Persistence.Context;

public class HotelCoreDbContext : DbContext
{
    public HotelCoreDbContext(DbContextOptions<HotelCoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<CategoriaHabitacion> Categorias => Set<CategoriaHabitacion>();
    public DbSet<Habitacion> Habitaciones => Set<Habitacion>();
    public DbSet<Reserva> Reservas => Set<Reserva>();
    public DbSet<ReservaServicio> ReservaServicios => Set<ReservaServicio>();
    public DbSet<ServicioAdicional> Servicios => Set<ServicioAdicional>();
    public DbSet<Tarifa> Tarifas => Set<Tarifa>();
    public DbSet<Auditoria> Auditorias => Set<Auditoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelCoreDbContext).Assembly);
    }
}