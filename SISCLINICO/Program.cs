using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SisClinico.Context;
using SisClinico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinico
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //var hostserver = CreateHostBuilder(args).Build();
            //using (var ambiente = hostserver.Services.CreateScope())
            //{
            //    var services = ambiente.ServiceProvider;
            //    try
            //    {
            //        var userManager = services.GetRequiredService<UserManager<Usuario>>();
            //        var context = services.GetRequiredService<SisClinicoDbContext>();
            //        //context.Database.Migrate();
            //        //DataPrueba.InsertarData(context, userManager).Wait();
            //    }
            //    catch (Exception e)
            //    {
            //        var logging = services.GetRequiredService<ILogger<Program>>();
            //        logging.LogError(e, "Ocurrio un error en la migracion");
            //    }
            //}
            //hostserver.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
