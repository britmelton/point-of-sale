using System.Data.SqlClient;
using Dapper;

namespace Infrastructure.Read;

public class ProductReadService : IProductReadService
{
    public IEnumerable<Product> Fetch()
    {
        using var connection = new SqlConnection("Server=SUGA;Database=pointofsale;Integrated Security=true;TrustServerCertificate=true;");
        connection.Open();

        return connection.Query<Product>("SELECT name, price, sku FROM PRODUCT;");
    }

    public Product Find(string sku)
    {
        using var connection = new SqlConnection("Server=SUGA;Database=pointofsale;Integrated Security=true;TrustServerCertificate=true;");
        connection.Open();

        return connection.QueryFirst<Product>(@"SELECT name, price, sku FROM PRODUCT WHERE Sku = @sku",
            new { Sku = sku });
    }
}