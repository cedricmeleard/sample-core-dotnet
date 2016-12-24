using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using UserApi.Models;

public class Startup {

    public void ConfigureServices(IServiceCollection services) {
        services.AddMvc();

        services.AddSingleton<IUserRepository, UserRepository>();
    }

    public void Configure(IApplicationBuilder app) {
        app.UseMvcWithDefaultRoute();

        app.UseStaticFiles();
    }

}