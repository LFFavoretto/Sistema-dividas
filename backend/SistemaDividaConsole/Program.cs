using ConsoleTables;
using SistemaDividasConsole.Data;
using SistemaDividasConsole.Models;
using SistemaDividasConsole.Services;

//var service = new ClienteService();
//var dividaService = new DividaService();

//while (true)
//{
//    Console.WriteLine("""
//        -------- MENU --------
//        1 - Cadastrar Cliente
//        2 - Alterar Dados
//        3 - Excluir Cliente
//        4 - Listar Clientes
//        5 - Listar Clientes com dívidas em aberto
//        6 - Buscar Cliente
//        7 - Registrar Divida
//        8 - Registrar Pagamento
//        0 - Sair do Programa

//        Escolha uma opção: 
//        """);
//    var entrada = Console.ReadLine();

//    if (entrada == null || !int.TryParse(entrada, out int opcao))
//    {
//        Console.WriteLine("ERRO! Digite apenas números válidos.\n");
//        continue;
        
//    }

//    if (opcao < 0 || opcao > 8) 
//    {
//        Console.WriteLine("Digite uma opção válida");
//        continue;
//    }

//    if (opcao == 1)
//    {
//        Console.WriteLine("Nome: ");
//        var nome = Console.ReadLine();

//        Console.WriteLine("CPF: ");
//        var cpf = Console.ReadLine();

//        Console.WriteLine("Data Nascimento: ");
//        var data_nascimento = DateTime.Parse(Console.ReadLine());

//        Console.WriteLine("Email: ");
//        var email = Console.ReadLine();


//        Cliente cliente = new Cliente();

//        cliente.Nome = nome;
//        cliente.Cpf = cpf;
//        cliente.DataNascimento = data_nascimento;
//        cliente.Email = email;

//        var sucesso = service.Criar(cliente, out var erros);
//        if (!sucesso)
//        {
//            foreach (var erro in erros)
//            {
//               Console.WriteLine(erro.ErrorMessage);
//            }
//        }
//        else
//        {
//            Console.WriteLine("Cliente cadastrado com sucesso");
//        }

//    }
//    else if (opcao == 2)
//    {
//        Console.WriteLine("Digite o cpf do cliente: ");
//        var cpf = Console.ReadLine();
//        var cliente = service.BuscaCpf(cpf);

//        if (cliente == null)
//        {
//            Console.WriteLine("Cliente não encontrado");
//            continue;
//        }
        
        
//        Console.WriteLine("Digite o nome: ");
//        var novoNome = Console.ReadLine();
//        Console.WriteLine("Digite o email: ");
//        var novoEmail = Console.ReadLine();
//        Console.WriteLine("Digite a data de nascimento");
//        var novoNascimento = DateTime.Parse(Console.ReadLine());
        

//        Cliente clienteAtualizado = new Cliente();

//        clienteAtualizado.Nome = novoNome;
//        clienteAtualizado.Email = novoEmail;
//        clienteAtualizado.DataNascimento = novoNascimento;
//        clienteAtualizado.Cpf = cpf;

//        var sucesso = service.Atualizar(cpf, clienteAtualizado, out var errosAtualizar);
        
//        if (!sucesso)
//        {
//            foreach (var erro in errosAtualizar)
//            {
//                Console.WriteLine(erro.ErrorMessage);
//            }
//        }
//        else
//        {
//            Console.WriteLine("Cliente atualizado com sucesso.");
//        }            
//    }

//    else if (opcao == 3)
//    {
//        Console.WriteLine("Digite um cpf: ");
//        var cpf = Console.ReadLine();
//        var sucesso = service.Excluir(cpf, out var errosExcluir);

//        if (!sucesso)
//        {
//            foreach (var erro in errosExcluir)
//            {
//                Console.WriteLine(erro.ErrorMessage);
//            }
//        }
//        else
//        {
//            Console.WriteLine("Cliente excluido com sucesso");
//        }
//    }

//    else if (opcao == 4)
//    {        
//        var clientes = service.Listar();
//        if (clientes.Count == 0)
//        {
//            Console.WriteLine("Nenhum cliente cadastrado.");
//        }
//        else
//        {
//            var table = new ConsoleTable("Nome", "CPF", "Data Nascimento", "Idade", "Email");
//            foreach (var cliente in clientes)
//            {
//                table.AddRow(
//                    cliente.Nome,
//                    cliente.Cpf,
//                    cliente.DataNascimento.ToString("dd/MM/yyyy"),
//                    cliente.Idade,
//                    cliente.Email
//                    );
//            }
//            table.Write();
//        }            
//    }

//    else if (opcao == 5)
//    {
//        var clientes = service.ListarDividas();
//        if (clientes.Count == 0)
//        {
//            Console.WriteLine("Nenhum cliente com dívida em aberto encontrado.");
//        }
//        else
//        {
//            var table = new ConsoleTable("Nome", "Idade", "Valor", "Data Registro", "Situação");
//            foreach (var cliente in clientes)
//            {
//                foreach (var divida in cliente.Dividas.Where(d => !d.Pago))
//                {
//                    table.AddRow(
//                        cliente.Nome,
//                        cliente.Idade,
//                        divida.Valor.ToString("C"),
//                        divida.DataCriacao.ToString("dd/MM/yyyy"),
//                        "Em aberto"
//                        );
//                }                
//            }
//            table.Write();
//        }
//    }

//    else if (opcao == 6)
//    {
//        Console.WriteLine("Digite o nome do cliente.");
//        var nome = Console.ReadLine();

//        var clientes = service.Buscar(nome);
//        if (clientes.Count == 0)
//        {
//            Console.WriteLine("Nenhum cliente encontrado");
//        }
//        else
//        {
//            var table = new ConsoleTable("Nome", "CPF", "Data Nascimento", "Idade", "Email", "Valor", "Data Registro", "Situação", "Data Pagamento");
//            foreach (var cliente in clientes)
//            {
//                foreach (var divida in cliente.Dividas)
//                {
//                    table.AddRow(
//                        cliente.Nome,
//                        cliente.Cpf,
//                        cliente.DataNascimento.ToString("dd/MM/yyyy"),
//                        cliente.Idade,
//                        cliente.Email,
//                        divida.Valor.ToString("C"),
//                        divida.DataCriacao.ToString("dd/MM/yyyy"),
//                        divida.Pago ? "Pago" : "Em aberto",
//                        divida.DataPagamento?.ToString("dd/MM/yyyy") ?? ""                        
//                    );
//                }
//            }
//            table.Write();
//        }
//    }

//    else if (opcao == 7)
//    {
//        Console.WriteLine("Informe o cpf do cliente: ");
//        var cpf = Console.ReadLine();

//        var cliente = service.BuscaCpf(cpf);

//        if (cliente == null)
//        {
//            Console.WriteLine("Cliente não encontrado");
//        }
//        else
//        {
//            Console.WriteLine("Digite o valor da dívida: ");
//            var valor = decimal.Parse(Console.ReadLine());

//            Divida divida = new Divida();
//            divida.Valor = valor;

//            var sucesso = dividaService.Criar(divida, cliente, out var erros);

//            if (!sucesso)
//            {
//                foreach (var erro in erros)
//                {
//                    Console.WriteLine(erro.ErrorMessage);
//                }
//            }
//            else
//            {
//                Console.WriteLine("Dívida registrada com sucesso.");
//            }
//        }
//    }

//    else if (opcao == 8)
//    {
//        Console.WriteLine("Informe o cpf do cliente: ");
//        var cpf = Console.ReadLine();

//        var cliente = service.BuscaCpf(cpf);

//        if (cliente == null)
//        {
//            Console.WriteLine("Cliente não encontrado.");
//            continue;
//        }
//        var pagamento = dividaService.Pagar(cliente);

//        if (pagamento)
//        {
//            Console.WriteLine("Pagamento realizado com sucesso.");
//        }
//        else
//        {
//            Console.WriteLine("Nenhuma dívida em aberto resgitrada.");
//        }
//    }

//    else if (opcao == 0)
//    {
//        break;
//    }
//}

SistemaDbContext context = new SistemaDbContext();

var clientes = context.Clientes.ToList();

Console.WriteLine(clientes.Count);