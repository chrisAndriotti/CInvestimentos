using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CInvestimentos.Models
{
    public class Transacao : IEntity
    {
        public int Id { get; set; }
        public int InvestidorId { get; set; }
        public double Valor { get; set; }
    }
}