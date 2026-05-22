using Core.Application.InputPorts.Orders;

namespace Core.Application.UseCases.PlaceOrder;

public interface IPlaceOrderUseCase
{
    string Execute(PlaceOrderInput input);
}
