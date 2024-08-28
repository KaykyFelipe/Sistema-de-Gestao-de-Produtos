using Npgsql;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Dapper;

namespace DBCRUD
{
    public class DataRepository 
    {
        public DBConnect conn = new DBConnect();
//CRUD CADASTROS__________________________________________________________________________________________________
        public void CadastroProdutoDB(string codigo,string nome,double valor)
        {

            using var conn = new DBConnect();

            string query = @"INSERT INTO produtos (codigo_prod,nome,valor) VALUES
                            (@codigo,@nome,@valor);";

            var result = conn.Conexao.Execute(sql: query, param: new {codigo = codigo, nome = nome, valor = valor}); 

        }

        
    
     public void ListaProdutosDB()
        {
            
            using var conn = new DBConnect(); //Conexao com Banco de Dados
            NpgsqlCommand query = new NpgsqlCommand("select * from produtos", conn.Conexao); //Criando Objeto para Ler Dados da Tabela
       
            NpgsqlDataReader lerDados = query.ExecuteReader();//Execução da Query

            foreach (var item in lerDados)
            {
                Console.WriteLine("Codigo Produto: " + lerDados["codigo_prod"] + " | Nome: " + lerDados["nome"] + " | Valor: " + lerDados["valor"]);
            }

            

        }
    
    }

    

}

   /*     //CRUD LOGIN__________________________________________________________________________________________________
        public bool Login_Cliente_DB(Usuario dados)
        {
            using var conn = new DBConnection();

            string query = @"SELECT email, senha FROM cliente WHERE email = @email AND senha = @senha;";

            var result_DB_Validation = conn.Connection.QueryFirstOrDefault<string>(sql: query, param: new { email = dados.email, senha = dados.senha });

            if (result_DB_Validation != null) return true;
            else return false;

        }

        public bool Login_Produtor_DB(Usuario dados)
        {
            using var conn = new DBConnection();

            string query = @"SELECT email, senha FROM produtor WHERE email = @email AND senha = @senha;";

            var result_DB_Validation = conn.Connection.QueryFirstOrDefault<string>(sql: query, param: new { email = dados.email, senha = dados.senha });

            if (result_DB_Validation != null) return true;
            else return false;

        }


        //CRUD CONTROLE DE ESTOQUE E RELATORIO (INTERFACE PRODUTOR)__________________________________________________________________________________________________


             public List<DataRepository> Select_Produtos_Agricolas()
        {
            using var conn = new DBConnection();

            string query = @"select id as ID_PRODUTO, nome as PRODUTO from prodagricola;";

            var result = conn.Connection.Query<DataRepository>(sql: query, param: new { }).ToList();

            return result;
        }

        public int Area_disponivel { get; set; }
        public List<DataRepository> Select_Area_Plantada(string email)
        {
            using var conn = new DBConnection();

            string query = @"select p.tamanho - p.area_plantada as Area_disponivel from propriedade p where email_proprietario = @email;";

            var result_DB_AreaPlant = conn.Connection.Query<DataRepository>(sql: query, param: new {email = email}).ToList();

            return result_DB_AreaPlant;
        }
        
        public void Cadastro_Plantio(string email, int alimento, int area_plantio)
        {
            try
            {
                using var conn = new DBConnection();

            string query = @"INSERT INTO plantio (data_plantio, id_propriedade, id_prodagricola, area) values 
                   (CURRENT_TIMESTAMP, (SELECT p.id FROM propriedade p WHERE @email = p.email_proprietario),
                   @alimento,
                   @area_plantio);"; 
            
                var result = conn.Connection.Execute(sql: query, param: new { email = email, alimento = alimento, area_plantio = area_plantio });

            }
            catch (Npgsql.PostgresException)
            {

                Console.WriteLine("Erro! Tente Novamente!!");
                
            }

        }
        public int ID_Plantio { get; set; }
        public string Nome_Produtos { get; set; }
        public int Area_Plantada { get; set; }
        public int IDPropriedade { get; set; }
        public string Status_Plantio { get; set; }




        public List<DataRepository> Select_Plantio_DB(string email)
        {
            using var conn = new DBConnection();

            string query2 = @"select pl.id as ID_Plantio, 
                            pl.data_plantio as Data_Plantio,
                            prd.nome as Nome_Produtos,
                            pl.area as Area_Plantada,
                            p.id as IDPropriedade,
                            pl.status as Status_Plantio
                    from propriedade p 
                    inner join plantio pl on pl.id_propriedade = p.id
                    inner join prodagricola prd on prd.id = pl.id_prodagricola
                    where p.id = (select p.id from propriedade p where email_proprietario = @email);";

            var result = conn.Connection.Query<DataRepository>(sql: query2, param: new { email = email }).ToList();

            return result;
        }

        public void Cadastro_Colheita(int quant_colhida, float valor_produto, int id_plantio)
        {
            try
            {
                using var conn = new DBConnection();

            string query = @"INSERT INTO colheita_estoque 
                            (data_colheita, quantidade, preco_unitario, id_plantio) VALUES
                            (CURRENT_TIMESTAMP ,@quant_colhida ,@valor_produto , @id_plantio);";

            
                var result = conn.Connection.Execute(sql: query, param: new { quant_colhida = quant_colhida, valor_produto = valor_produto, id_plantio = id_plantio });
            }
            catch (Npgsql.PostgresException) {

                Console.WriteLine("Erro! Tente Novamente!!");
                
            }
           

        }

        public string Nome_Cliente { get; set; }
        public string Data__Compra { get; set; }
        public string Celular_Cliente { get; set; }
        public string Name_Produto { get; set; }
        public int Quant_Produto { get; set; }
        public float Valor_Total { get; set; }
        public int Id_prop { get; set; }


        public List<DataRepository> Select_Relatorio_Prod(string email)
        {
            using var conn = new DBConnection();

            string query2 = @"SELECT hp.dia||'/'||hp.mes||'/'||hp.ano as Data__Compra,
                                hp.nome_cliente as Nome_Cliente,
                                cl.celular as Celular_Cliente,
                                p.produto as Name_Produto,
                                p.quantidade as Quant_Produto, 
                                p.valor as Valor_Total,
                                pr.id as Id_prop
                                FROM pedido p
                                INNER JOIN head_pedido hp ON hp.pedido = p.id_pedido
                                INNER JOIN cliente cl ON cl.nome = hp.nome_cliente
                                inner join propriedade pr on pr.email_proprietario = @email;";

            var result_DB_Prod = conn.Connection.Query<DataRepository>(sql: query2, param: new { email = email }).ToList();

            return result_DB_Prod;
        }


        //CRUD COMPRA E RELATORIO (INTERFACE CLIENTE)__________________________________________________________________________________________________

        public int ID_Colheita { get; set; }
        public DateTime Data { get; set; }
        public string Produto_Nome { get; set; }
        public int Estoque { get; set; }
        public float Valor_Produto { get; set; }
        public string Cidade_Venda { get; set; }


        public List<DataRepository> Select_Produtos()
        {
            using var conn = new DBConnection();

            string query2 = @"select ce.id_colheita as ID_Colheita,
                            ce.data_colheita as Data,
                            prd.nome Produto_Nome,
                            ce.quantidade as Estoque,
                            ce.preco_unitario as Valor_Produto,
                            p.cidade as Cidade_Venda
                            from plantio pl inner join prodagricola prd on prd.id = pl.id_prodagricola
                            inner join propriedade p on p.id = pl.id_propriedade
                            inner join colheita_estoque ce on ce.id_plantio = pl.id;";

            var result_DB_Produtos = conn.Connection.Query<DataRepository>(sql: query2, param: new { }).ToList();

            return result_DB_Produtos;
        }

        public void Abertura_Pedido(string email)
        {

            using var conn = new DBConnection();

            string query = @"INSERT INTO pedido_venda (data, email_cliente) values 
                            (CURRENT_TIMESTAMP, @email);";

            var result = conn.Connection.Execute(sql: query, param: new { email = email });
        }

        public void Pedido_Compra(int id_produto, int quant_prod, string email)
        {
            try
            {

                using var conn = new DBConnection();

            string query = @"INSERT INTO item_pedido (quantidade, id_estoque,id_pedido) values 
                            (@quant_prod, @id_produto, (select ID from pedido_venda pv where email_cliente = @email order by id desc limit 1));;";

            
                var result = conn.Connection.Execute(sql: query, param: new { id_produto = id_produto, quant_prod = quant_prod, email = email });
            }
            catch (Npgsql.PostgresException)
            {

                Console.WriteLine("Erro! Tente Novamente!!");
                Console.ReadKey();
            }
        }

        public int ID_Pedido { get; set; }
        public int Quant_Pedido { get; set; }
        public string Produto_Pedido { get; set; }
        public float Preco_Pedido { get; set; }
        public float ValorTotal { get; set; }

        public List<DataRepository> Select_Relatorio_Cliente(string email)
        {
            using var conn = new DBConnection();

            string query2 = @"select ip.id_pedido as ID_Pedido,
                                prod_agricola as Produto_Pedido,
                                ip.quantidade as Quant_Pedido,
                                ic.preco_unitario as Preco_Pedido,
                                ip.quantidade * ic.preco_unitario as ValorTotal
                                from item_pedido ip join info_colheita ic on ic.id_colheita = ip.id_estoque
                                where ip.id_pedido = (select ID from pedido_venda pv where email_cliente = @email order by id desc limit 1)
                                order by ip.id_pedido;";

            var result_DB_Cliente = conn.Connection.Query<DataRepository>(sql: query2, param: new { email = email}).ToList();

            return result_DB_Cliente;
        }

    }

}*/