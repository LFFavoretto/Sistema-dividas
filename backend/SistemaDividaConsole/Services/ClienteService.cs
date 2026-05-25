using MySqlX.XDevAPI;
using SistemaDividasConsole.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SistemaDividasConsole.Services
{
    public class ClienteService
    {
        //private readonly EmporioDbContext context;

        //public ClienteService(EmporioDbContext context)
        //{
        //    this.context = context;
        //}

        private readonly List<Cliente> clientes = new();

        public bool Validar(Cliente cliente, out List<ValidationResult> erros)
        {

            var validation = new ValidationContext(cliente);
            erros = new List<ValidationResult>();
            Validator.TryValidateObject(cliente, validation, erros, true);
            return erros.Count == 0;
        }

        public bool Criar(Cliente cliente, out List<ValidationResult> erros)
        {
            if (!Validar(cliente, out erros))
            {
                return false;
            }

            if (cliente.DataNascimento > DateTime.Today)
            {
                erros.Add(new ValidationResult("Data de nascimento inválida."));
                return false;
            }

            if (cliente.Idade < 16)
            {
                erros.Add(new ValidationResult("Idade insuficiente. Cliente deve ter mais de 16 anos."));
                return false;
            }

            foreach (Cliente clienteLista in clientes)
            {
                if (clienteLista.Cpf == cliente.Cpf)
                {
                    erros.Add(new ValidationResult("Cliente já cadastrado"));
                    return false;
                }
            }

            clientes.Add(cliente);
            return true;
        }

        public List<Cliente> Listar()
        {
            return clientes;
        }

        public List<Cliente> ListarDividas()
        {
            return clientes.Where(c => c.Dividas.Any(d => !d.Pago)).ToList();
        }

        public List<Cliente> Buscar (string nome)
        {
            var busca = clientes.Where(n => n.Nome.ToLower().Contains(nome.ToLower())).ToList();
            return busca;
        }   

        public Cliente BuscaCpf(string cpf)
        {
            return clientes.FirstOrDefault(c => c.Cpf == cpf);
        }
        
        public bool Atualizar (string cpf, Cliente clienteAtualizado, out List<ValidationResult> errosAtualizar)
        {
            errosAtualizar = new List<ValidationResult>();

            if (!Validar(clienteAtualizado, out errosAtualizar))
            {
                return false;
            }

            if (clienteAtualizado.DataNascimento > DateTime.Today)
            {
                errosAtualizar.Add(new ValidationResult("Data de nascimento inválida."));
                return false;
            }

            if (clienteAtualizado.Idade < 16)
            {
                errosAtualizar.Add(new ValidationResult("Idade insuficiente. Cliente deve ter mais de 16 anos."));
                return false;
            }

            foreach (Cliente cliente in clientes)
            {
                if (cliente.Cpf == cpf)
                {
                    cliente.Nome = clienteAtualizado.Nome;
                    cliente.Email = clienteAtualizado.Email;
                    cliente.DataNascimento = clienteAtualizado.DataNascimento;

                    return true;
                }                
            }            
            errosAtualizar.Add(new ValidationResult("Cliente não encontrado"));
            return false;
        }

        public bool Excluir (string cpf, out List<ValidationResult> errosExcluir)
        {
            errosExcluir = new List<ValidationResult>();
            var clienteEncontrado = clientes.FirstOrDefault(c => c.Cpf == cpf);
            if (clienteEncontrado != null)
            {
                clientes.Remove(clienteEncontrado);
                return true;
            }
            errosExcluir.Add(new ValidationResult("Cliente não encontrado"));
            return false;
        }

        public List<Cliente> Ordenar(int pagina)
        {
            int limite = 10;
            if (pagina < 1)
            {
                pagina = 1;
            }
            var ordenados = clientes.OrderByDescending(c => DividaAberta(c))
                .Skip((pagina - 1) * limite)
                .Take(limite)
                .ToList();
            return ordenados;
        }

        private decimal DividaAberta(Cliente cliente)
        {
            var dividaAberta = cliente.Dividas.FirstOrDefault(d => !d.Pago);
            if (dividaAberta != null)
            {
                return dividaAberta.Valor;
            }
            return 0;
        }
    }
}

