using System.Dynamic;
using DBCRUD;
using Program;
using System;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

public class Gerenciamento
{
    
//atributos
private string? codigo;
public string? Codigo{get;set;}
private string? nome;
public string? Nome{get; set;}
private double valor{get;set;}
public double Valor{get; set;}


public virtual void cadastrarProdutos(string codigo,string nome,double valor)
{
}

public virtual void listarProdutos()
{
}

public virtual void editarProdutos(string codigo,string nome,double valor)
{
}

public virtual void excluirProdutos(string codigo)
{
}
public void Lobby()
{
 
        int op;
                DataRepository gerenc = new DataRepository();
                Console.WriteLine("1)Cadastrar Produtos\n2)Lista Produto\n3)Editar Produto\n4)Remover Produto\n0)Finalizar");
                op = int.Parse(Console.ReadLine());
            
            
            switch (op)
            {
                case 1: 
                        Console.WriteLine("Digite o codigo do produto: ");
                        gerenc.Codigo = Console.ReadLine();
                        Console.WriteLine("Digite o nome do produto: ");
                        gerenc.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o valor do produto: ");
                        gerenc.Valor = double.Parse(Console.ReadLine());
                        gerenc.cadastrarProdutos(gerenc.Codigo, gerenc.Nome, gerenc.Valor);
                        break;

                case 2: gerenc.listarProdutos(); break;
                case 3: 
                        Console.WriteLine("Digite o codigo do produto que será editado: ");
                        gerenc.Codigo = Console.ReadLine();
                        Console.WriteLine("Digite o novo nome do produto: ");
                        gerenc.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o novo valor do produto: ");
                        gerenc.Valor = double.Parse(Console.ReadLine());
                        gerenc.editarProdutos(gerenc.Codigo, gerenc.Nome, gerenc.Valor);
                        break;
                case 4: 
                        Console.WriteLine("Digite o codigo do produto que será removido: ");
                        gerenc.Codigo = Console.ReadLine();
                        gerenc.excluirProdutos(gerenc.Codigo); break;
                case 0: finalizarExecucao(); break;
                default : Console.Clear(); Lobby(); break;
                

}
}

public void finalizarExecucao(){
Console.ReadKey();
Environment.Exit(0); // 0 indica que o programa terminou com sucesso  
Console.WriteLine("Finalizado");

}

}
 
