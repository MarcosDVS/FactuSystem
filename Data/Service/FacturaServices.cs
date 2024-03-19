using FactuSystem.Data.Context;
using FactuSystem.Data.Model;
using FactuSystem.Data.Request;
using FactuSystem.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FactuSystem.Data.Services;

public class FacturaServices : IFacturaServices
{
    private readonly IMyDbContext dbContext;

    public FacturaServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<Result<List<FacturaResponse>>> Consultar(string filtro)
    {
        try
        {
            var facturas = await dbContext.Facturas
                .Where(c =>
                        (c.Cliente.Nombre + " " + c.Cliente.Apellidos)
                        .ToLower()
                        .Contains(filtro.ToLower())
                )
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .Include(f => f.Cliente)
                .Include(f => f.Pagos)
                .Include(f => f.Detalles)
                .ThenInclude(d => d.Producto)
                .Select(f => f.ToResponse())
                .ToListAsync();
            return new Result<List<FacturaResponse>>()
            {
                Data = facturas,
                Success = true,
                Message = "Ok"
            };
        }
        catch (Exception E)
        {
            return new Result<List<FacturaResponse>>()
            {
                Data = null,
                Success = false,
                Message = E.Message
            };
        }
    }

    public async Task<Result<FacturaResponse>> Crear(FacturaRequest request)
    {
        try
        {
            var factura = Factura.Crear(request);
            dbContext.Facturas.Add(factura);
            await dbContext.SaveChangesAsync();
            return new Result<FacturaResponse>()
            {
                Data = factura.ToResponse(),
                Success = true,
                Message = "Ok ✔"
            };
        }
        catch (Exception E)
        {
            return new Result<FacturaResponse>()
            {
                Data = null,
                Success = false,
                Message = E.Message
            };
        }
    }
    public async Task<Result> Eliminar(FacturaRequest request)
    {
        try
        {
            var contacto = await dbContext.Facturas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Message = "No se encontro el usuario", Success = false };

            dbContext.Facturas.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result<List<FacturaResponse>>> BuscarFacturas(DateTime? fecha)
    {
        try
        {
            var facturasQuery = dbContext.Facturas
                .Include(f => f.Detalles)
                .ThenInclude(d => d.Producto)
                .AsQueryable();

            if (fecha.HasValue)
            {
                // Filtrar por fecha
                facturasQuery = facturasQuery.Where(f => f.Fecha.Date == fecha.Value.Date);
            }

            var facturas = await facturasQuery
                .Select(f => f.ToResponse())
                .ToListAsync();

            return new Result<List<FacturaResponse>>()
            {
                Data = facturas,
                Success = true,
                Message = "Búsqueda exitosa"
            };
        }
        catch (Exception ex)
        {
            return new Result<List<FacturaResponse>>()
            {
                Data = null,
                Success = false,
                Message = ex.Message
            };
        }
    }

    public async Task<Result<FacturaResponse>> Modificar(FacturaRequest request)
    {
        try
        {
            var factura = await dbContext.Facturas
                .Include(f => f.Detalles)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(c => c.Id == request.Id);

            if (factura == null)
                return new Result<FacturaResponse>() { Message = "No se encontró la factura", Success = false };

            // Actualizar las propiedades de la factura según el request
            factura.ClienteId = request.ClienteId;
            factura.TypePayment = request.TypePayment;
            factura.SaldoPagado = request.SaldoPagado;
            factura.SaldoPendiente = request.SaldoPendiente;
            factura.Detalles = request.Detalles
                .Select(detalle => FacturaDetalle.Crear(detalle))
                .ToList();

            // Guardar los cambios en la base de datos
            await dbContext.SaveChangesAsync();

            return new Result<FacturaResponse>()
            {
                Data = factura.ToResponse(),
                Success = true,
                Message = "Factura modificada correctamente"
            };
        }
        catch (Exception ex)
        {
            return new Result<FacturaResponse>()
            {
                Data = null,
                Success = false,
                Message = ex.Message
            };
        }
    }

    public async Task<bool> UpdateInvoice(int invoiveId)
    {
        try
        {
            var invoive = await dbContext.Facturas
                .FirstOrDefaultAsync(a => a.Id == invoiveId);

            if (invoive != null)
            {
                if(invoive.TypePayment == "2" && invoive.SaldoPendiente == 0)
                {
                    invoive.TypePayment = "1"; // Alternar el estado (credito/a contado)
                    await dbContext.SaveChangesAsync();
                }
                
                return true;
            }
            else
            {
                return false; // La factura con el ID especificado no se encontró
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
}

public interface IFacturaServices
{
    Task<Result<List<FacturaResponse>>> Consultar(string filtro);
    Task<Result<FacturaResponse>> Crear(FacturaRequest request);
    Task<Result> Eliminar(FacturaRequest request);
    Task<Result<List<FacturaResponse>>> BuscarFacturas(DateTime? fecha);
    Task<Result<FacturaResponse>> Modificar(FacturaRequest request);
    Task<bool> UpdateInvoice(int invoiveId);
}