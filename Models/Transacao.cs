using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CInvestimentos.Models
{
    public class Transacao : IEntity
    {
        public int Id { get; set; }
        public int InvestidorId { get; set; }
        public double Valor { get; set; }
        public ETransacoes TipoTransacao { get; set; }
        
    }
}