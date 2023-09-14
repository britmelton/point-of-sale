using Infrastructure.Write;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Api.Spec.Setup
{
    public class StorageFixture : IDisposable
    {
        private static readonly object Lock = new();

        public StorageFixture()
        {
            CreateDatabase();
        }

        private Context Context { get; set; }

        public Context CreateContext(DbTransaction transaction = null)
        {
            var connection = new SqlConnection("Server=SUGA;Database=pointofsale;Integrated Security=true;TrustServerCertificate=true;");
            Context = new (new DbContextOptionsBuilder<Context>().UseSqlServer(connection).Options);
            if (transaction != null)
                Context.Database.UseTransaction(transaction);
            return Context;

        }
        private void CreateDatabase()
        {
            lock (Lock)
            {
                Context = CreateContext();

                Context.Database.EnsureDeleted();
                Context.Database.Migrate();

                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
