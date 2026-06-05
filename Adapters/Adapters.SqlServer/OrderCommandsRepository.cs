using Adapters.SqlServer.Utils;
using Core.Application.Repositorio.Commands;
using Core.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Adapters.SqlServer;

public class OrderCommandsRepository : IOrderCommandsRepository
{

    public void PlaceOrder(Customer customer, Order order)
    {
        try
        {
            using var dbConnection = new SqlConnection(SqlConnectionStringUtils.ConnectionString);
            dbConnection.Open();

            var newOrder = new
            {
                id = order.Id,
                customer_name = customer.Name.FirstName + " " + customer.Name.LastName,
                customer_cpf = customer.Cpf,
                customer_email = customer.Email,
                customer_phone = customer.Phone,
                customer_id = customer.Id,
                order_date = order.CreationDate,
                order_status = order.Status.ToString()
            };

            dbConnection.Execute(
                "INSERT INTO [dbo].[orders] ([id], [customer_name], [customer_cpf], [customer_email], [costumer_phone], [costumer_id], [order_date], [order_status])" +
                "\n VALUES(@id, @customer_name, @customer_cpf, @customer_email, @costumer_phone, @costumer_id, @order_date, @order_status)",
                newOrder);
            
            dbConnection.Close();

        }
        catch (Exception e)
        {
            throw new Exception("OrdersRepository --> PlaceOrder: Erro: Falha ao criar ordem. " + e.Message, e);
        }
    }
}