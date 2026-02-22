using HotelCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Domain.Entities;

public class Tarifa : BaseEntity
{
    public int CategoriaId { get; private set; }
    public decimal PrecioBase { get; private set; }
    public DateTime VigenciaDesde { get; private set; }
    public DateTime VigenciaHasta { get; private set; }

    public Tarifa(int categoriaId, decimal precioBase, DateTime desde, DateTime hasta)
    {
        CategoriaId = categoriaId;
        PrecioBase = precioBase;
        VigenciaDesde = desde;
        VigenciaHasta = hasta;
    }
}