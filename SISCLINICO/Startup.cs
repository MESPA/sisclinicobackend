using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SisClinico.Context;
using SisClinico.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SISCLINICO.Contratos;
using SISCLINICO.Seguridad;
using MediatR;
using SISCLINICO.Aplicacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SISCLINICO.Middleware;

namespace SisClinico
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opt => {
                //valida ue el usuario este autenticado para consultar el app
                // var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                // opt.Filters.Add(new AuthorizeFilter(policy));
          

            });
            services.AddCors(o => o.AddPolicy("corsApp", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));


            //services.AddDbContext<SisClinicoDbcontext>(options => 
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            string mySqlConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SisClinicoDbContext>(options =>
                    options.UseMySql((mySqlConnection)));
            var builder = services.AddIdentityCore<
                Usuario>();
            //mediatR
            services.AddMediatR(typeof(UsuarioActual.Manejador).Assembly);
            //configuracion de los usuarios con esquema de seguridad microsotf
            var identitybuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identitybuilder.AddEntityFrameworkStores<SisClinicoDbContext>();
            identitybuilder.AddSignInManager<SignInManager<Usuario>>();
            //services.TryAddSingleton<ISystemClock, SystemClock>();

            //seguridad para los controller sin logueo
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreta"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });

            services.AddScoped<IJwtGenerador, JwtGenerador>();
            services.AddScoped<IUsuarioSesion, UsuarioSesion>();

            //obtener usuario actualde la sesion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("corsApp");
            app.UseMiddleware<ManejadorErrorMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
