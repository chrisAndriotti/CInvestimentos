using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CInvestimentos.Models
{
    public class Investidor : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public double SaldoEmConta { get; set; }
        public List<Investimento> Investimentos { get; set; }
    }
}