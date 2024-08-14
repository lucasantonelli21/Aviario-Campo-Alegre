using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviario_Campo_Alegre.Models
{
    public class LoteModel
    {
        public int Id { get; set; }
        public DateOnly DataEntrada { get; set; }
        public long QuantidadeAnimais { get; set; }
        public string Linhagem { get; set; }
        public string AviarioOrigem { get; set; }
        public long QuantidadeVendas { get; set; }
        public long QuantidadeConsumo { get; set; }
        public long QuantidadeMortos { get; set; }
        public decimal PrecoLote { get; set; }	
        public decimal PrecoVendaAnimal { get; set; }	
        public DateOnly DataVenda { get; set; }
    }
}