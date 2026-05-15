using System.ComponentModel.DataAnnotations;

namespace Sistema_dividas.Models
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
