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
CRUD.ListaProdutosDB();
}

public void editarProduto(string codigo,string nome,double valor)
{
CRUD.editarProdutosDB(codigo,nome,valor);
}

public void excluirProduto(string codigo)
{
excluirProduto(codigo);
}

}