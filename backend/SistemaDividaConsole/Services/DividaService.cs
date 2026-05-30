using SistemaDividasConsole.Data;
using SistemaDividasConsole.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDividasConsole.Services
{
    public class DividaService
    {
        private readonly SistemaDbContext context;

        public DividaService(SistemaDbContext context)
        {
            this.context = context;
        }

        public bool Validar(Divida divida, out List<ValidationResult> erros)
        {
            var validation = new ValidationContext(divida);
            erros = new List<ValidationResult>();
            Validator.TryValidateObject(divida, validation, erros, true);
            return erros.Count == 0;
        }

        public bool Criar(Divida divida, Cliente cliente, out List<ValidationResult> erros)
        { 
            if (!Validar(divida, out erros))
            {
                return false;
            }
            var dividaAberta = context.Dividas.Any(d => d.ClienteId == cliente.Id && !d.Pago);
            if (dividaAberta)
            {
                erros.Add(new ValidationResult("Cliente ja tem uma divida em aberto."));
                return false;
                
            }
            divida.Cliente = cliente;
            divida.DataCriacao = DateTime.Today;
            divida.Pago = false;
            context.Dividas.Add(divida);
            context.SaveChanges();
            
            return true;
        }

        public bool Pagar(Cliente cliente)
        {
            var divida = context.Dividas.FirstOrDefault(d => d.ClienteId == cliente.Id && !d.Pago);
            
            if (divida == null)
            {
                return false;
            }
            divida.Pago = true;
            divida.DataPagamento = DateTime.Today;            
            context.Dividas.Update(divida);
            context.SaveChanges();
            return true;

            
        }

        public decimal TotalDividasAbertas()
        {
            return context.Dividas.Where(d => d!.Pago).Sum(d => d.Valor);
        }
    
    }
}
