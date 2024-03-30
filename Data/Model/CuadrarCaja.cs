using FactuSystem.Data.Response;
using FactuSystem.Data.Request;
using System.ComponentModel.DataAnnotations;

namespace FactuSystem.Data.Model;

public class CuadrarCaja
{
    [Key]
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Cajero { get; set; }
    public decimal Monto { get; set; }
    public decimal MontoCuadrado { get; set; }

    public static CuadrarCaja Crear(CuadrarCajaRequest item)
    {
        return new CuadrarCaja()
        {
            Fecha = item.Fecha,
            Cajero = item.Cajero,
            Monto = item.Monto,
            MontoCuadrado = item.MontoCuadrado
        };
    }

    public bool Modificar(CuadrarCajaRequest item)
    {
        var cambio = false;

        if (Fecha != item.Fecha)
        {
            Fecha = item.Fecha;
            cambio = true;
        }
        if (Cajero != item.Cajero)
        {
            Cajero = item.Cajero;
            cambio = true;
        }
        if (Monto != item.Monto)
        {
            Monto = item.Monto;
            cambio = true;
        }
        if (MontoCuadrado != item.MontoCuadrado)
        {
            MontoCuadrado = item.MontoCuadrado;
            cambio = true;
        }

        return cambio;
    }



    public CuadrarCajaResponse? ToResponse()
    {
        return new CuadrarCajaResponse()
        {
            Id = Id,
            Fecha = Fecha,
            Cajero = Cajero,
            Monto = Monto,
            MontoCuadrado = MontoCuadrado
        };
    }
}