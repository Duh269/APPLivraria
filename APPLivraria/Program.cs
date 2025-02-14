using Application.Service;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();

builder.Services.AddDbContext<AppDbContext>(options => {

        var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseMySQL(connetionString, b => b.MigrationsAssembly("APPLivraria"));
    

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
