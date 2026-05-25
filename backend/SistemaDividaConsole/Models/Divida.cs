using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDividasConsole.Models
{
    public class Divida
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Valor é obrigatório.")]
        public decimal Valor { get; set; }

        public bool Pago { get; set; }

        [Required(ErrorMessage = "Por favor informe a data de registro.")]
        public DateTime DataCriacao { get; set; }

        public DateTime? DataPagamento { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public void PrintDados()
        {
            Console.WriteLine("Valor: {0}", Valor.ToString("C"));
            Console.WriteLine("Data de Registro: {0}", DataCriacao.ToString("dd/MM/yyyy"));
            if (Pago)
            {
                Console.WriteLine("Situação: Pago");
            }
            else
            {
                Console.WriteLine("Situação: Em aberto");
            }
            
            if (DataPagamento != null)
            {
                Console.WriteLine("Data de Pagamento: {0}", DataPagamento.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                Console.WriteLine("Data de Pagamento: ");
            }
            
        }
    }
}
