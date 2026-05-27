using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDividasConsole.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo CPF é obrigatório.")]
        [StringLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage ="CPF Inválido. Use apenas números.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Data de Nascimento é obrigatório.")]
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

        [Required(ErrorMessage = "Campo Email é obrigatório.")]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; }

        public List<Divida> Dividas { get; set; } = new();

        

    }
}
