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
        //private readonly EmporioDbContext context;

        //public DividaService(EmporioDbContext context)
        //{
        //    this.context = context;
        //}

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

            foreach (Divida dividasLista in cliente.Dividas)
            {
                if (!dividasLista.Pago)
                {
                    erros.Add(new ValidationResult("Cliente ja tem uma divida em aberto."));
                    return false;
                }
            }
            cliente.Dividas.Add(divida);
            divida.DataCriacao = DateTime.Today;
            return true;
        }

        public bool Pagar(Cliente cliente)
        {
            foreach (Divida dividas in cliente.Dividas)
            {
                if (dividas.Pago == false)
                {
                    dividas.DataPagamento = DateTime.Today;
                    dividas.Pago = true;
                    return true;
                }
            }
            return false;
        }
    }
}
