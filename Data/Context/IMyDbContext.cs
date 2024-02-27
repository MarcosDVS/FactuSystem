using FactuSystem.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace FactuSystem.Data.Context
{
    public interface IMyDbContext
    {
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        DbSet<Factura> Facturas { get; set; }
        DbSet<Pago> Pagos { get; set; }
        DbSet<Producto> Productos { get; set; }
        DbSet<Proveedor> Proveedores { get; set; }
        DbSet<Usuario> Usuarios { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}