using CouponsV2.Application.Services.Emails;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Applications.Services.Repositories;
using RiwiEmplea.Applications.Services.Repositories.PersonalData;
using RiwiEmplea.Applications.Services.Repositories.PersonalData.Methods;
using RiwiEmplea.Applications.Utils.Profiles;
using RiwiEmplea.Infrastructure.Data;
using RiwiEmplea.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

//----- BEGIN PERSONAL SERVICES -----//

//----- MySQL connection
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

//----- Repository Dependency injection
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
builder.Services.AddScoped<IAcademicTrainingRepository, AcademicTrainingRepository>();
builder.Services.AddScoped<IWorkExpirenceRepository, WorkExpirenceRepository>();
builder.Services.AddScoped<ISkillsRepository, SkillsRepository>();

builder.Services.RegisterPersonalData();
builder.Services.AddScoped<IPersonalDataService, PersonalDataService>();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailRepository, EmailRepository>();

// Añade el servicio de logging
builder.Services.AddLogging();  

// Register AutoMapper profiles
builder.Services.AddAutoMapper(typeof(UsersProfile));

//----- END PERSONAL SERVICES -----//

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
    pattern: "{controller=Register}/{action=Index}");

app.MapControllers();

app.Run();
