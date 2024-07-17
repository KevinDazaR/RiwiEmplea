using System.Net;
using System.Text;
using CouponsV2.Application.Services.Emails;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Applications.Interfaces.Repositories;
using RiwiEmplea.Applications.Interfaces.Repositories.Token;
using RiwiEmplea.Applications.Services.Repositories;
using RiwiEmplea.Applications.Services.Repositories.PersonalData;
using RiwiEmplea.Applications.Services.Repositories.PersonalData.Methods;
using RiwiEmplea.Applications.Services.Token;
using RiwiEmplea.Applications.Utils.Profiles;
using RiwiEmplea.Infrastructure.Data;
using RiwiEmplea.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

//----- BEGIN PERSONAL SERVICES -----//

// Inyeccion de depenencias 
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

//----- MySQL connection
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

/* Configuracion del token */
builder.Services.AddAuthentication(opt => {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(configure => {
            configure.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
/* Control de errores del token */
            configure.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    if (context.Exception is SecurityTokenExpiredException)
                    {
                        Console.WriteLine("Token expirado, Porfavor genere uno nuevo.");
                    }
                    else
                    {
                        Console.WriteLine("Usuario no autorizado.");
                    }
                    return Task.CompletedTask;
                }
            };
        });
// Configuration of the interfaces that will be used
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
