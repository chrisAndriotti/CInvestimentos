using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CInvestimentos.Models
{
    public class Venda : IEntity
    {
        public int Id { get; set; }
        public int InvestidorId { get; set; }
        public int AcaoId { get; set; }
        public int Quantidade { get; set; }
        public double Total { get; set; }
    }
}