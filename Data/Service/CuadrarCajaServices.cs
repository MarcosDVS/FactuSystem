using FactuSystem.Data.Context;
using FactuSystem.Data.Model;
using FactuSystem.Data.Response;
using FactuSystem.Data.Request;
using Microsoft.EntityFrameworkCore;

namespace FactuSystem.Data.Services;

public class CuadrarCajaServices : ICuadrarCajaServices
{
    private readonly IMyDbContext dbContext;

    public CuadrarCajaServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<List<CuadrarCajaResponse>>> Consultar(string filtro)
    {
        try
        {
            var item = await dbContext.CuadrarCajas
                .Where(c =>
                    (c.Cajero)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return new Result<List<CuadrarCajaResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = item
            };
        }
        catch (Exception E)
        {
            return new Result<List<CuadrarCajaResponse>>
            {
                Message = E.Message,
                Success = false
            };
        }
    }

    public async Task<Result> Crear(CuadrarCajaRequest request)
    {
        try
        {
            var item = CuadrarCaja.Crear(request);
            dbContext.CuadrarCajas.Add(item);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    
    public async Task<Result> Modificar(CuadrarCajaRequest request)
    {
        try
        {
            var item = await dbContext.CuadrarCajas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message= "No se encontro el CuadrarCaja", Success = false };

            if (item.Modificar(request))
                await dbContext.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }

    public async Task<Result> Eliminar(CuadrarCajaRequest request)
    {
        try
        {
            var item = await dbContext.CuadrarCajas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el CuadrarCaja", Success = false };

            dbContext.CuadrarCajas.Remove(item);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
}

public interface ICuadrarCajaServices
{
    Task<Result<List<CuadrarCajaResponse>>> Consultar(string filtro);
    Task<Result> Crear(CuadrarCajaRequest request);
    Task<Result> Modificar(CuadrarCajaRequest request);
    Task<Result> Eliminar(CuadrarCajaRequest request);
}