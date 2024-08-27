using System.Dynamic;
using DBCRUD;

public class Gerenciamento
{
    
//atributos
private string codigo;
public string Codigo{get;set;}
private string nome;
public string Nome{get; set;}
private double valor{get;set;}
public double Valor{get; set;}





DataRepository CRUD = new DataRepository();

public void cadastrarProduto(string codigo,string nome,double valor)
{
    CRUD.CadastroProdutoDB(codigo,nome,valor);
}

public void listarProdutos()
{
List<DataRepository> DB = CRUD.ListaProdutosDB();

 foreach (var item in DB)
            {
                Console.WriteLine($"Nome Produto:{item.DB} | Data Plantio: {item.Data} |  | Estoque: {item2.Estoque} | Valor da Unidade: {item2.Valor_Produto} | Cidade: {item2.Cidade_Venda}");

            }
}

public void editarProduto(string codigo)
{
    
}
public void excluirProduto()
{

}

}