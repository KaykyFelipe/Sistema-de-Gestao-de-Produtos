using Npgsql;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;


    public class DBConnect: IDisposable
    {
        public NpgsqlConnection Conexao { get; set; }

        public DBConnect() { 
         Conexao = new NpgsqlConnection("Server=localhost;Port=5432;Database=GestaoProdutos;User Id=postgres;Password=1234");
         Conexao.Open();
        }

        public void Dispose()
        {
            Conexao.Dispose();
        }
    }
