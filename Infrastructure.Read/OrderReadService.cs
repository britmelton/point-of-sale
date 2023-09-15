using Dapper;
using System.Data.SqlClient;

namespace Infrastructure.Read
{
    public class OrderReadService : IOrderReadService
    {
        public OrderDto Find(Guid id)
        {
            using var connection = new SqlConnection("Server=SUGA;Database=pointofsale;Integrated Security=true;TrustServerCertificate=true;");
            connection.Open();

            OrderDto? order = null;

            connection.Query<Order, LineItem, OrderDto>(
                @"SELECT * FROM [Order] AS o JOIN LineItem AS li ON li.OrderId = o.Id WHERE o.Id = @id ",
                (o,li) =>
                {
                    order ??= o;
                    order.Add(li);

                    return null;
                },
                new{id},
                splitOn: "Id"
            );
             return order;
        }
    }
}