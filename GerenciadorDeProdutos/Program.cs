using System;
using System.Dynamic;

namespace Progam
{

public class Progam
{
    

public static void Main(string[] args)
{
    int op;
        Gerenciamento gerenc = new Gerenciamento();
        Console.WriteLine("1)Cadastrar Produtos");
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
            gerenc.cadastrarProduto(gerenc.Codigo, gerenc.Nome, gerenc.Valor);
            break;

        case 2: gerenc.listarProdutos();  
        break;
        default : break;
    }


    

    
}

}

}
