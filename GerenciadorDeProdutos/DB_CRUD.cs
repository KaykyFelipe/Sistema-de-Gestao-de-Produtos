using Npgsql;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Dapper;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DBCRUD
{
    public class DataRepository : Gerenciamento
    {
    public DBConnect conn = new DBConnect();

    public override void cadastrarProdutos(string codigo,string nome,double valor)
        {
        using var conn = new DBConnect(); //Conexao com Banco de Dados
        NpgsqlCommand query = new NpgsqlCommand(@"INSERT INTO produtos (codigo_prod,nome,valor) VALUES (@codigo,@nome,@valor);", conn.Conexao); //Criando Objeto para Inserir Dados da Tabela

            //Adicionando os valores dos atributos na Query
            query.Parameters.AddWithValue("@codigo", codigo);
            query.Parameters.AddWithValue("@nome", nome);
            query.Parameters.AddWithValue("@valor", valor);
            query.ExecuteNonQuery();//Execução da Query

            Console.ReadKey();
            Console.Clear();
            Lobby();
            
        }

    public override void listarProdutos()
        {
            
            using var conn = new DBConnect(); //Conexao com Banco de Dados
            NpgsqlCommand query = new NpgsqlCommand("select * from produtos", conn.Conexao); //Criando Objeto para Ler Dados da Tabela
       
            NpgsqlDataReader lerDados = query.ExecuteReader();//Execução da Query


            foreach (var item in lerDados)//Varredura e exibição dos registros da tabela 
            {
                Console.WriteLine("Codigo Produto: " + lerDados["codigo_prod"] + " | Nome: " + lerDados["nome"] + " | Valor: " + lerDados["valor"]);
            }
            Console.ReadKey();
            Console.Clear();
            Lobby();
        }

    public override void editarProdutos(string codigo,string nome,double valor)
        {
            
            using var conn = new DBConnect(); //Conexao com Banco de Dados
            NpgsqlCommand query = new NpgsqlCommand(@"UPDATE produtos SET nome = @nome, valor = @valor WHERE codigo_prod = @codigo", conn.Conexao); //Criando Objeto para Ler Dados da Tabela

            //Adicionando os valores dos atributos na Query
            query.Parameters.AddWithValue("@codigo", codigo);
            query.Parameters.AddWithValue("@nome", nome);
            query.Parameters.AddWithValue("@valor", valor);
            query.ExecuteReader();//Execução da Query

            Console.ReadKey();
            Console.Clear();
            Lobby();

        }    

    public override void excluirProdutos(string codigo)
    {
        using var conn = new DBConnect(); //Conexao com Banco de Dados
        NpgsqlCommand query = new NpgsqlCommand(@"DELETE FROM produtos WHERE codigo_prod = @codigo", conn.Conexao); //Criando Objeto para Remover Dados da Tabela

            //Adicionando os valores dos atributos na Query
            query.Parameters.AddWithValue("@codigo", codigo);
        
            query.ExecuteReader();//Execução da Query            

            Console.ReadKey();
            Console.Clear();
            Lobby();

    }
    }   
}

  