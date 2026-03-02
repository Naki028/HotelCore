using HotelCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelCore.Domain.Entities;

public class Auditoria : BaseEntity
{
    public string Accion { get; private set; }
    public string Entidad { get; private set; }
    public string Usuario { get; private set; }
    public DateTime Fecha { get; private set; }
    public string? ValoresAnteriores { get; private set; }

    public Auditoria(string accion, string entidad, string usuario, string? valoresAnteriores = null)
    {
        Accion = accion;
        Entidad = entidad;
        Usuario = usuario;
        Fecha = DateTime.UtcNow;
        ValoresAnteriores = valoresAnteriores;
    }
}