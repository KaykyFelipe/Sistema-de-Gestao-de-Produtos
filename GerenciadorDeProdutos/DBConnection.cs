using Npgsql;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace DBConnection
{
    internal class DBConnection : IDisposable
    {
        public NpgsqlConnection Connection { get; set; }

        public DBConnection() { 
         Connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=produtos;User Id=postgres;Password=dbadmin");
         Connection.Open();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}