using SistemaDividasConsole.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Validator.TryValidateObject(cliente, validation, erros);
            return erros.Count == 0;
        }

        public bool Criar(Cliente cliente, out List<ValidationResult> erros)
        {
            if (!Validar(cliente, out erros))
            {
                return false;
            }

            clientes.Add(cliente);
            return true;
        }

        public List<Cliente> Listar()
        {
            return clientes;
        }
    }
}
