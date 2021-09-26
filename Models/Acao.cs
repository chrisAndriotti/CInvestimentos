using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CInvestimentos.Models
{
    public class Acao : IEntity
    {
        public int Id { get; set; } 
        public string CodigoAcao { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}