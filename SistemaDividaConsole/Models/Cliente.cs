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

        public void PrintDados()
        {
            Console.WriteLine("Nome: {0}", Nome);
            Console.WriteLine("CPF: {0}", Cpf);
            Console.WriteLine("Data Nascimento: {0}", DataNascimento.ToString("dd/MM/yyyy"));
            Console.WriteLine("Idade: {0}", Idade);
            Console.WriteLine("Email: {0}", Email);
        }
    }
}
