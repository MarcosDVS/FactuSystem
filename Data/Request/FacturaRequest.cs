namespace FactuSystem.Data.Request;

public class FacturaRequest
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public virtual ICollection<FacturaDetalleRequest> Detalles { get; set; }
        = new List<FacturaDetalleRequest>();
    public decimal SubTotal =>
        Detalles != null ?
        Detalles.Sum(d => d.SubTotal)
        :
        0;

    public decimal TotalDesc =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.TotalDesc) //Verdadero
        :
        0;//Falso

    public decimal ITBIS => SubTotal * 0.18m;

    public string TypePayment  { get; set; } = null!;
    public decimal SaldoPagado { get; set; }
    public decimal SaldoPendiente { get; set; }
}

public class FacturaDetalleRequest
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string? Descripcion { get; set; }
    public int Cantidad { get; set; } = 1;
    public decimal Precio { get; set; }
    public decimal Descuento { get; set; }
    public decimal SubTotal => Cantidad * Precio;
    public decimal TotalDesc => SubTotal * (Descuento / 100 );
    public decimal ITBIS => SubTotal * 0.18m;
    public decimal PrecioITBIS => Precio * 0.18m;
}
