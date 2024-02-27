using FactuSystem.Data.Request;

namespace FactuSystem.Data.Response;

public class PagoResponse
{
    public int Id { get; set; }
    public int FacturaID { get; set; }
    public FacturaResponse Factura { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public double MontoPagado { get; set; }
    public string? Observacion { get; set; }

    public PagoRequest ToRequest() 
    {
        return new PagoRequest
        {
            Id = Id,
            FacturaID = FacturaID,
            MontoPagado = MontoPagado,
            Observacion = Observacion,
            Fecha = Fecha
        };
    }
}