using FactuSystem.Data;
using FactuSystem.Data.Context;
using FactuSystem.Data.Services;
using FactuSystem.Data.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using FactuSystem.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using static FactuSystem.Data.Services.CategoriaServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
#region Configuracion de la base de datos SQLserver
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddScoped<IMyDbContext,MyDbContext>();
#endregion
#region Servicios
builder.Services.AddScoped<IFacturaServices,FacturaServices>();
builder.Services.AddScoped<IProductoServices,ProductoServices>();
builder.Services.AddScoped<IProveedorServices,ProveedorServices>();
builder.Services.AddScoped<ICategoriaServices,CategoriaServices>();
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IPagoServices, PagoServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
#endregion
#region Authentication
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
//builder.Services.AddSingleton<UserAccountService>();
builder.Services.AddScoped<IUserAccountService,UserAccountService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
