namespace FactuSystem.Data.Request;

public class PagoRequest
{
    public int Id { get; set; }
    public int FacturaID { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;
    public double MontoPagado { get; set; }
    public string? Observacion { get; set; }
}