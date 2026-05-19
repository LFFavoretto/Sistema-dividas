using SistemaDividasConsole.Models;
using SistemaDividasConsole.Services;

var service = new ClienteService();

while (true)
{
    Console.WriteLine("Digite a opção: ");
    var entrada = Console.ReadLine();

    if (entrada == null || !int.TryParse(entrada, out int opcao))
    {
        Console.WriteLine("ERRO! Digite apenas números válidos.\n");
        continue;
        
    }

    //else if (opcao < 0 || opcao > 4) 
    //{
    //    Console.WriteLine("Digite uma opção válida");
    //}

    if (opcao == 1)
    {
        Console.WriteLine("Nome: ");
        var nome = Console.ReadLine();

        Console.WriteLine("CPF: ");
        var cpf = Console.ReadLine();

        Console.WriteLine("Data Nascimento: ");
        var data_nascimento = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Email: ");
        var email = Console.ReadLine();


        Cliente cliente = new Cliente();

        cliente.Nome = nome;
        cliente.Cpf = cpf;
        cliente.DataNascimento = data_nascimento;
        cliente.Email = email;

        cliente.PrintDados();
        var sucesso = service.Criar(cliente, out _);
        if (!sucesso)
        {
            Console.WriteLine("Erro no cadastro do cliente");
        }

    }

    else if (opcao == 2)
    {
        var clientes = service.Listar();

        foreach (var item in clientes)
        {
            Console.WriteLine("<--------------------->");
            item.PrintDados();
            Console.WriteLine("<--------------------->");
        }
    }

    else if (opcao == 3)
    {
        break;
    }
}