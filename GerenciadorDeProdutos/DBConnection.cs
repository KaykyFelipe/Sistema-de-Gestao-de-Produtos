using Npgsql;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;


    public class DBConnect: IDisposable
    {
        public NpgsqlConnection Connection { get; set; }

        public DBConnect() { 
         Connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=GestaoProdutos;User Id=postgres;Password=1234");
         Connection.Open();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
