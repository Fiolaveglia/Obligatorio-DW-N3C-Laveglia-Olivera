using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using Obligatorio.Infraestructura.EF.Repositorios;
using Obligatorio.Infraestructura.EF;
using Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios;
using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaAplicacion.CasosDeUso.Historias;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ObligatorioContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConexionObligatorio")
    )
);

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<AltaUsuario>();
builder.Services.AddScoped<LoginUsuario>();
builder.Services.AddScoped<IRepositorioHistoria, RepositorioHistoria>();
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
builder.Services.AddScoped<CrearHistoria>();
builder.Services.AddScoped<EditarHistoria>();
builder.Services.AddScoped<BajaHistoria>();

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
