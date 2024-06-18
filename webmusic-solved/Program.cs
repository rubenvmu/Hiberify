using Microsoft.EntityFrameworkCore;
using webmusic_solved.Models;
using webmusic_solved.Services.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GrupoAContext>
    (options => options.UseSqlServer("'server=musicagrupos.databaase.windows.net;database=GrupoA;Integrated Security=True"));
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<ICancionesService, CancionesService>();
builder.Services.AddScoped<IAlbumesRepositorio, fakeAlbumesRepositorio>();
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();