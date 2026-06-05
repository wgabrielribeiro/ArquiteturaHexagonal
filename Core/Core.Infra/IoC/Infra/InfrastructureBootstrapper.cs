using Adapters.SqlServer;
using Core.Application.Repositorio.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infra.IoC.Infra;

public class InfrastructureBootstrapper
{
    internal void ChildServiceRegister(IServiceCollection services)
    {
        services.AddScoped<IOrderCommandsRepository, OrderCommandsRepository>();
    }
}