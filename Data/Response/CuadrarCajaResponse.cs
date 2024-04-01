using FactuSystem.Data.Request;

namespace FactuSystem.Data.Response;

public class CuadrarCajaResponse
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } 
    public string Cajero { get; set; }
    public decimal Monto { get; set; }
    public decimal MontoCuadrado { get; set; }

    public CuadrarCajaRequest ToRequest()
    {

        return new CuadrarCajaRequest()
        {
            Id = Id,
            Fecha = Fecha,
            Cajero = Cajero,
            Monto = Monto,
            MontoCuadrado = MontoCuadrado
        };
    }
}