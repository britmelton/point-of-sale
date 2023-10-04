using System.Data.SqlClient;
using Dapper;

namespace Infrastructure.Read;

public class CartReadService : ICartReadService
{
    public CartDto Find(Guid id)
    {
        using var connection = new SqlConnection("Server=SUGA;Database=pointofsale;Integrated Security=true;TrustServerCertificate=true;");
        connection.Open();

        CartDto? cart = null;

        connection.Query<Cart, CartLineItem, CartDto>(
            @"SELECT * FROM [Cart] AS c LEFT JOIN CartLineItem AS li ON li.CartId = c.Id WHERE c.Id = @id ",
            (c, li) =>
            {
                cart ??= c;
                if (li is not null)
                    cart.Add(li);

                return null;
            },
            new { id },
            splitOn: "Id"
        );
        return cart;
    }
}