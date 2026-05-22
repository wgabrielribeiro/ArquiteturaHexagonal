using Core.Application.Repositorio.Commands;
using Core.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Adapters.SqlServer;

public class OrderCommandRepository : IOrderCommandsRepository
{

    public void PlaceOrder(Customer costumer, Order order)
    {
        try
        {
            using var dbConnection = new SqlConnection("");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}