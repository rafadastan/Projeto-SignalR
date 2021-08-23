using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projeto02.Data.SqlServer.Contexts;
using Projeto02.IoC;
using Projeto02.Presentation.Mvc.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto02.Presentation.Mvc
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
            //Configurando a compilação automática do Razor para o MVC
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //Configurando o SignalR
            services.AddSignalR();

            //Configurando o EntityFramework
            services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("BDProjeto02")));

            //Configurando as dependencias do projeto DDD
            DependencyResolver.ConfigureServices(services);

            //Configurando o AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //habilita a pasta /wwwwroot
            app.UseStaticFiles();

            //habilita os controllers
            app.UseRouting();

            //habilita autorização de usuario (Claims)
            //necessita precisa definir um tipo de autenticação
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //mapear o padrão de rotas do projeto MVC
                endpoints.MapControllerRoute(
                    name: "default", //padrão de rotas do projeto
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                //mapear os Hubs do SignalR
                endpoints.MapHub<ContasHub>("/contashub");
            });
        }
    }
}
