using System.ComponentModel.DataAnnotations.Schema;
using FactuSystem.Data.Request;

namespace FactuSystem.Data.Response;

public class FacturaResponse
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }
    public ClienteResponse Cliente { get; set; }
    public virtual ICollection<FacturaDetalleResponse> Detalles { get; set; }
    public virtual ICollection<PagoResponse> Pagos { get; set; }

    [NotMapped]
    public decimal SubTotal =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.SubTotal) //Verdadero
        :
        0;//Falso

    [NotMapped]
    public decimal TotalDesc =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.TotalDesc) //Verdadero
        :
        0;//Falso
    public string TypePayment  { get; set; } = null!;
    public decimal SaldoPagado { get; set; }
    public decimal SaldoPendiente => Pagos!=null&&Pagos.Any()? SubTotal - TotalDesc - (decimal)Pagos.Sum(p => p.MontoPagado):SubTotal;

    public FacturaRequest ToRequest()
    {
        // Cambiar TypePayment a "1" si SaldoPendiente es igual a 0
        if (SaldoPendiente == 0)
        {
            TypePayment = "1";
        }
        
        return new FacturaRequest
        {
            Id = Id,
            ClienteId = ClienteId,
            TypePayment = TypePayment,
            SaldoPagado = SaldoPagado,
            SaldoPendiente = SaldoPendiente,
            Fecha = Fecha,
            Detalles = Detalles.Select(d => new FacturaDetalleRequest
            {
                Id = d.Id,
                ProductoId = d.Producto.Id, // Asegúrate de que esto sea correcto
                Descripcion = d.Producto.Nombre, // Asegúrate de que esto sea correcto
                Cantidad = d.Cantidad,
                Precio = d.Precio
            }).ToList()
        };
    }
}
