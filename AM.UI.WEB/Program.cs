using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AM.ApplicationCore.Domain;

var builder = WebApplication.CreateBuilder();

// Add services to the container.

// Adds  Controllers With Views
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IService<Tache>, Service<Tache> >();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<DbContext, AMContext>();


//Adds basic MVC functionality
builder.Services.AddMvc();
builder.Services.AddDbContext<DbContext, AMContext>(options =>
       options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Injection de dépendance
//builder.Services.AddScoped<IServiceFlight, ServiceFlight>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//Working with Static Files
app.UseStaticFiles();

// Matches request to an endpoint.
app.UseRouting();

// Use the default authorization.
app.UseAuthorization();

// create default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
