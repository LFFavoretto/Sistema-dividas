using System.ComponentModel.DataAnnotations;

namespace Sistema_dividas.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(14)]
        public string Cpf { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        public int Idade 
        {
            get
            {
                var atual = DateTime.Today;
                var anos = atual.Year - DataNascimento.Year;
                var diaAnoNascimento = atual.AddYears(-anos);

                if (DataNascimento > diaAnoNascimento)
                {
                    anos--;
                }

                return anos;
            }
        }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public List<Divida> Dividas { get; set; } = new();
    }
}
