using MySqlX.XDevAPI;
using SistemaDividasConsole.Data;
using SistemaDividasConsole.Dtos;
using SistemaDividasConsole.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SistemaDividasConsole.Services
{
    public class ClienteService
    {
        private readonly SistemaDbContext context;

        public ClienteService(SistemaDbContext context)
        {
            this.context = context;
        }

        public bool Validar(Cliente cliente, out List<ValidationResult> erros)
        {

            var validation = new ValidationContext(cliente);
            erros = new List<ValidationResult>();
            Validator.TryValidateObject(cliente, validation, erros, true);

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
            return erros.Count == 0;
        }

        public bool Criar(Cliente cliente, out List<ValidationResult> erros)
        {
            if (!Validar(cliente, out erros))
            {
                return false;
            }           
            
            if (context.Clientes.Any(c => c.Cpf == cliente.Cpf))
            {
                erros.Add(new ValidationResult("Cliente já cadastrado"));
                return false;
            }
            

            context.Clientes.Add(cliente);
            context.SaveChanges();
            return true;
        }

        public List<Cliente> Listar()
        {
            return context.Clientes.ToList();
        }

        public List<Cliente> ListarDividas(int pagina)
        {
            return Ordenar(pagina).Where(c => c.Dividas.Any(d => !d.Pago)).ToList();
        }

        public List<Cliente> Buscar (string nome)
        {
            var busca = context.Clientes.Include(c => c.Dividas).Where(n => n.Nome.ToLower().Contains(nome.ToLower())).ToList();
            return busca;
        }   

        public Cliente BuscaCpf(string cpf)
        {
            return context.Clientes.Include(c => c.Dividas).FirstOrDefault(c => c.Cpf == cpf);
        }
        
        public bool Atualizar (string cpf, UpdateClienteDto clienteDto, out List<ValidationResult> errosAtualizar)
        {
            errosAtualizar = new List<ValidationResult>();
            var cliente = BuscaCpf(cpf);
            if (cliente != null)
            {
                cliente.Nome = clienteDto.Nome;
                cliente.Email = clienteDto.Email;
                cliente.DataNascimento = clienteDto.DataNascimento;
            }
            else
            {
                errosAtualizar.Add(new ValidationResult("Cliente não encontrado"));
                return false;
            }
            if (!Validar(cliente, out errosAtualizar))
            {
                return false;
            }
            context.Clientes.Update(cliente);
            context.SaveChanges();
            return true;            
        }

        public bool Excluir (string cpf, out List<ValidationResult> errosExcluir)
        {
            errosExcluir = new List<ValidationResult>();
            var clienteEncontrado = context.Clientes.FirstOrDefault(c => c.Cpf == cpf);
            if (clienteEncontrado != null)
            {
                context.Clientes.Remove(clienteEncontrado);
                context.SaveChanges();
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
            var ordenados = context.Clientes.Include(c => c.Dividas).AsEnumerable().OrderByDescending(c => DividaAberta(c))
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

        public decimal TotalDividasAbertas(List<Cliente> clientes)
        {
            return clientes.Sum(c => c.Dividas.FirstOrDefault(d => !d.Pago).Valor);
        }
    }
}

