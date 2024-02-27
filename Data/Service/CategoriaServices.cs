using FactuSystem.Data.Context;
using FactuSystem.Data.Model;
using FactuSystem.Data.Response;
using FactuSystem.Data.Request;
using Microsoft.EntityFrameworkCore;
using static FactuSystem.Data.Services.CategoriaServices;

namespace FactuSystem.Data.Services;

public class CategoriaServices : ICategoriaServices
{
    private readonly IMyDbContext dbContext;

    public CategoriaServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<List<CategoriaResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.Categorias
                .Where(c =>
                    (c.Nombre)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return new Result<List<CategoriaResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = contactos
            };
        }
        catch (Exception E)
        {
            return new Result<List<CategoriaResponse>>
            {
                Message = E.Message,
                Success = false
            };
        }
    }

    public async Task<Result> Crear(CategoriaRequest request)
    {
        try
        {
            var contacto = Categoria.Crear(request);
            dbContext.Categorias.Add(contacto);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(CategoriaRequest request)
    {
        try
        {
            var contacto = await dbContext.Categorias
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Message = "No se encontro la categoría", Success = false };

            if (contacto.Mofidicar(request))
                await dbContext.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }

    public async Task<Result> Eliminar(CategoriaRequest request)
    {
        try
        {
            var contacto = await dbContext.Categorias
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Message = "No se encontro la categoría", Success = false };

            dbContext.Categorias.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };

        }
    }

}
public interface ICategoriaServices
{
    Task<Result<List<CategoriaResponse>>> Consultar(string filtro);
    Task<Result> Crear(CategoriaRequest request);
    Task<Result> Modificar(CategoriaRequest request);
    Task<Result> Eliminar(CategoriaRequest request);
}
