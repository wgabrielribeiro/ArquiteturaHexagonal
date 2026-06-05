using Core.Application.UseCases.PlaceOrder;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infra.IoC.App;

public class ApplicationBootstrapper
{
    internal void ChildServiceRegister(IServiceCollection services)
    {
        services.AddScoped<IPlaceOrderUseCase, PlaceOrderUseCase>();
    }
}