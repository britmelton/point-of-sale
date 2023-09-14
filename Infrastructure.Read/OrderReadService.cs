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

            var order = new OrderDto();

            connection.Query<Order, LineItem, OrderDto>(
                @"SELECT * FROM [Order] AS o JOIN LineItem AS li ON li.OrderId = o.Id WHERE o.Id = @id ",
                (o,li) =>
                {
                    order.Id = o.Id;
                    order.IsComplete = o.IsComplete;
                    order.OrderNumber = o.OrderNumber;
                    order.Subtotal = o.Subtotal;
                    order.Total = o.Total;

                    var lineItemDto = new LineItemDto();
                    lineItemDto.Id = li.Id;
                    lineItemDto.OrderId = li.OrderId;
                    lineItemDto.ProductId = li.ProductId;
                    lineItemDto.Price = li.Price;
                    lineItemDto.Quantity = li.Quantity;

                    order.LineItems.Add(lineItemDto);

                    return null;
                },
                new{id},
                splitOn: "Id"
            );
             return order;
        }
    }
}