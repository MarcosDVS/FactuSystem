using FactuSystem.Data.Context;
using FactuSystem.Data.Model;
using FactuSystem.Data.Response;
using FactuSystem.Data.Request;
using Microsoft.EntityFrameworkCore;

namespace FactuSystem.Data.Services;

public class ProductoServices : IProductoServices
{
    private readonly IMyDbContext dbContext;

    public ProductoServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<List<ProductoResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.Productos
                .Where(c =>
                    (c.Nombre)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return new Result<List<ProductoResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = contactos
            };
        }
        catch (Exception E)
        {
            return new Result<List<ProductoResponse>>
            {
                Message = E.Message,
                Success = false
            };
        }
    }

    public async Task<Result> Crear(ProductoRequest request)
    {
        try
        {
            var contacto = Producto.Crear(request);
            dbContext.Productos.Add(contacto);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(ProductoRequest request)
    {
        try
        {
            var contacto = await dbContext.Productos
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Message = "No se encontro el producto", Success = false };

            if (contacto.Mofidicar(request))
                await dbContext.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }

    public async Task<Result> Eliminar(ProductoRequest request)
    {
        try
        {
            var contacto = await dbContext.Productos
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Message = "No se encontro el producto", Success = false };

            dbContext.Productos.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }

    public async Task<bool> ActualizarStock(List<int> itemIds, List<FacturaDetalleRequest> detalles)
    {
        try
        {
            var productos = await dbContext.Productos
                .Where(p => itemIds.Contains(p.Id))
                .ToListAsync();

            foreach (var producto in productos)
            {
                var detalle = detalles.FirstOrDefault(d => d.ProductoId == producto.Id);
                if (detalle != null)
                {
                    // Resta la cantidad del detalle al stock del producto
                    producto.Stock -= detalle.Cantidad;
                }
            }

            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}

public interface IProductoServices
{
    Task<Result<List<ProductoResponse>>> Consultar(string filtro);
    Task<Result> Crear(ProductoRequest request);
    Task<Result> Modificar(ProductoRequest request);
    Task<Result> Eliminar(ProductoRequest request);
    Task<bool> ActualizarStock(List<int> itemIds, List<FacturaDetalleRequest> detalles);
}