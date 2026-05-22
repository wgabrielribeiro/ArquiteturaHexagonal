namespace Core.Application.InputPorts.Orders;

public class PlaceOrderInput
{
    public Guid CustomerId { get; set; }
    public required PlaceOrderProductInput ProductItem { get; set; }
}