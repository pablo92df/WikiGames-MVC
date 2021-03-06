using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using System.Text.Json.Serialization;
using WikiGames.Services.Repositories;
using WikiGames.Services.RepositoriesInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options => 
                    options.JsonSerializerOptions.ReferenceHandler
                    = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
string connectionString = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddTransient<IMarcaRepository, MarcaRepository>();
builder.Services.AddTransient<IGeneroRepository, GeneroRepository>();
builder.Services.AddTransient<IDesarrolladorRepository, DesarrolladorRepository>();
builder.Services.AddTransient<IImgDesarrolladoresRepository, ImgDesarrolladoresRepository>();
builder.Services.AddTransient<IJuegoRepository, JuegoRepository>();
builder.Services.AddTransient<IPublicadoraRepository, PublicadoraRepository>();
builder.Services.AddTransient<IConsolaRepository, ConsolaRepository>();
builder.Services.AddTransient<IImgConsolasRepository, ImgConsolaRepository>();
builder.Services.AddTransient<IImgJuegoRepository, ImgJuegosRepository>();


builder.Services.AddTransient<ICRUD, CRUD>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(10);//Puede cambiar el tiempo   
});

builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
{
    opciones.UseSqlServer(connectionString, sqlServer => sqlServer.UseNetTopologySuite());
   //opciones.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);//comportamiento por defecto para consultas solo lectua
                                                                        // opciones.UseLazyLoadingProxies();
}
    );
//agrego el automapper
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
