using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviario_Campo_Alegre.DTOs
{
    public class LoteDTO
    {
        public DateOnly DataEntrada { get; set; }
        public long QuantidadeAnimais { get; set; }
        public string Linhagem { get; set; }
        public string AviarioOrigem { get; set; }
        public decimal PrecoLote { get; set; }	
        public DateOnly? DataVenda { get; set; }
    }
}