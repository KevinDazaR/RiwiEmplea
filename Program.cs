using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Applications.Services.Repositories;
using RiwiEmplea.Applications.Utils.Profiles;
using RiwiEmplea.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

// Configuration of the interfaces that will be used
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddLogging();  // Añade el servicio de logging



// Register AutoMapper profiles
builder.Services.AddAutoMapper(typeof(UsersProfile));

// Configuration of controllers
builder.Services.AddControllers();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
