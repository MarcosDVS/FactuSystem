namespace FactuSystem.Data.Request;

public class CuadrarCajaRequest
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Cajero { get; set; }
    public decimal Monto { get; set; }
    public decimal MontoCuadrado { get; set; }
}