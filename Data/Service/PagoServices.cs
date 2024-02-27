using FactuSystem.Data.Context;
using FactuSystem.Data.Model;
using FactuSystem.Data.Response;
using FactuSystem.Data.Request;
using Microsoft.EntityFrameworkCore;
using static FactuSystem.Data.Services.PagoServices;

namespace FactuSystem.Data.Services;

public class PagoServices : IPagoServices
{
    private readonly IMyDbContext dbContext;

    public PagoServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<List<PagoResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.Pagos
                .Where(c =>
                    (c.Observacion)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return new Result<List<PagoResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = contactos
            };
        }
        catch (Exception E)
        {
            return new Result<List<PagoResponse>>
            {
                Message = E.Message,
                Success = false
            };
        }
    }

    public async Task<Result> Crear(PagoRequest request)
    {
        try
        {
            var contacto = Pago.Crear(request);
            dbContext.Pagos.Add(contacto);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(PagoRequest request)
    {
        try
        {
            var contacto = await dbContext.Pagos
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Message = "No se encontro el pago", Success = false };

            if (contacto.Mofidicar(request))
                await dbContext.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }

    public async Task<Result> Eliminar(PagoRequest request)
    {
        try
        {
            var contacto = await dbContext.Pagos
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Message = "No se encontro el pago", Success = false };

            dbContext.Pagos.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };

        }
    }

}

public interface IPagoServices
{
    Task<Result<List<PagoResponse>>> Consultar(string filtro);
    Task<Result> Crear(PagoRequest request);
    Task<Result> Modificar(PagoRequest request);
    Task<Result> Eliminar(PagoRequest request);
}