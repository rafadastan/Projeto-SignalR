using Microsoft.Extensions.DependencyInjection;
using Projeto02.Application.Interfaces;
using Projeto02.Application.Services;
using Projeto02.Data.SqlServer.Repositories;
using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Domain.Interfaces.Services;
using Projeto02.Domain.Services;
using System;

namespace Projeto02.IoC
{
    public class DependencyResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IContaApplicationService, ContaApplicationService>();
            services.AddTransient<IContaDomainService, ContaDomainService>();
            services.AddTransient<IContaRepository, ContaRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
