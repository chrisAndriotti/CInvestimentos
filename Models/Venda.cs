using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CInvestimentos.Models
{
    public class Venda : IEntity
    {
        public int Id { get; set; }
        public int InvestimentoId { get; set; }
        public int Quantidade { get; set; }
        public double Total { get; set; }
    }
}