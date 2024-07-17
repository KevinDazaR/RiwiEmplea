using RiwiEmplea.Applications.Interfaces;

namespace RiwiEmplea.Applications.Services.Repositories.PersonalData.Methods
{
  public static class ServiceExtensions
  {
    public static IServiceCollection RegisterPersonalData(this IServiceCollection services)
    {
      services.AddTransient<IGetPersonalData, GetPersonalData>();
      services.AddTransient<IUpdatePersonalData, UpdatePersonalData>();
      return services;
    }
  }
}