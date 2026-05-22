using Core.Application.InputPorts.Orders;
using Core.Domain.Entities;
using Core.Domain.ValueObjects;
using Flunt.Notifications;

namespace Core.Application.UseCases.PlaceOrder;

public class PlaceOrderUseCase : Notifiable, IPlaceOrderUseCase
{
    private Customer _customer;
    private Order _order;
    
    //Execução de regra de negocio desse caso de uso
    public string Execute(PlaceOrderInput input)
    {
        var name = new NameVo("João", "Silva");
        var cpf = new CpfVo("23124234234");
        var email = new EmailVo("email@hotmail.com");
        _customer = new Customer(name, cpf, email, "11976675432");

        if (_customer.Invalid)
        {
            AddNotifications(_customer.Notifications);
            return _customer.Notifications.First().Message;
        }

        _order = new Order(_customer);
        var product = new Product(input.ProductItem.Title, input.ProductItem.Description, input.ProductItem.Image, input.ProductItem.Price, input.ProductItem.Quantity);

        if (_order.Invalid)
        {
            AddNotifications(_order.Notifications);
            return _order.Notifications.First().Message;
        }

        string orderId = "";

        try
        {
            //salvar no db

        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao executar acesso a dados. PlaceOrderUseCase - Execute. Detalhes: {e.Message}", e);
        }

        return "Numero do pedido: " + orderId;
    }
}