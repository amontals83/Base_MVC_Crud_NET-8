using Microsoft.EntityFrameworkCore;
using MVC_Crud_NET_8.Datos;

var builder = WebApplication.CreateBuilder(args);

//Configuramos la conexion a sql srver local db MSSQLLOCAL
builder.Services.AddDbContext<ApplicationDBContext>(opciones =>
        opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
        app.UseExceptionHandler("/Inicio/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=Index}/{id?}");

app.Run();
