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
        [StringLength(14)]
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

        //public void PrintDados()
        //{
        //    Console.WriteLine("Nome: {0}", Nome);
        //    Console.WriteLine("CPF: {0}", Cpf);
        //    Console.WriteLine("Data Nascimento: {0}", DataNascimento.ToString("dd/MM/yyyy"));
        //    Console.WriteLine("Idade: {0}", Idade);
        //    Console.WriteLine("Email: {0}", Email);
        //}

        //public void PrintDividasAbertas()
        //{
        //    Console.WriteLine("Nome: {0}", Nome);
        //    Console.WriteLine("Idade: {0}", Idade);
        //    foreach (Divida divida in Dividas.Where(d => !d.Pago))
        //    {
        //        divida.PrintDados();
        //    }
        //}

        //public void PrintDividas()
        //{
        //    Console.WriteLine("Nome: {0}", Nome);
        //    Console.WriteLine("CPF: {0}", Cpf);
        //    Console.WriteLine("Data Nascimento: {0}", DataNascimento.ToString("dd/MM/yyyy"));
        //    Console.WriteLine("Idade: {0}", Idade);
        //    Console.WriteLine("Email: {0}", Email);
        //    foreach (Divida divida in Dividas)
        //    {
        //        divida.PrintDados();
        //    }
        //}
        

    }
}
