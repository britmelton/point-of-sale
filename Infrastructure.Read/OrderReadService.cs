using Dapper;
using System.Data.SqlClient;

namespace Infrastructure.Read
{
    public class OrderReadService : IOrderReadService
    {
        public Order Find(Guid id)
        {
            using var connection = new SqlConnection("Server=SUGA;Database=pointofsale;Integrated Security=true;TrustServerCertificate=true;");
            connection.Open();

            return connection.QuerySingle<Order>(@"SELECT * FROM Order WHERE id = @id", new { id });

        }
    }
}