using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UserApi.Models;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddSingleton<IUserRepository, UserRepository>();
    }

    public void Configure(IApplicationBuilder app,
                         IHostingEnvironment env,
                         ILoggerFactory loggerFactory)
    {
        app.UseMvcWithDefaultRoute();

        app.UseStaticFiles();
        //does not work right now...don't know why AddConsole or AddDebug is not defined
        //loggerFactory.AddConsole().AddDebug();
    }
}