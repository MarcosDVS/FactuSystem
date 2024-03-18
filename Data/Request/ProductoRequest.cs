using FactuSystem.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using FactuSystem.Data.Response;


namespace FactuSystem.Data.Request;

public class ProductoRequest
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public int ProveedorID { get; set; }
    public string Nombre { get; set; } = null!;
    public int Stock { get; set; }
    public int CategoriaID { get; set; }
    public decimal PrecioCompra { get; set; }
    public decimal Precio { get; set; }
    
}
