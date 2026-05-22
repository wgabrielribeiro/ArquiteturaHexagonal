using Core.Domain.Entities;

namespace Core.Application.Repositorio.Commands;

public interface IOrderCommandsRepository
{
    void PlaceOrder(Customer costumer, Order order);
    
}