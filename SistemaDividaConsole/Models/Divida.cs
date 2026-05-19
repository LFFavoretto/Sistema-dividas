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

        [Required]
        public decimal Valor { get; set; }

        public bool Pago { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        public DateTime? DataPagamento { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
