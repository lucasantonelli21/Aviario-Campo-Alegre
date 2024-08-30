using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Models;
namespace Aviario_Campo_Alegre.DTOs
{
    public class RelatorioDTO
    {
        public int NumeroLote {get; set;}
        public decimal PrecoLote { get; set; }	
        public decimal PrecoVendaAnimal { get; set; }
        public List<RefeicaoModel> Refeicoes { get; set; }
        public long QuantidadeConsumo { get; set; }
        public long QuantidadeAnimais { get; set; }
        public long QuantidadeMortos { get; set; }
        public long QuantidadeVendas { get; set; }
        public decimal Lucro { get; set; }
    }
}