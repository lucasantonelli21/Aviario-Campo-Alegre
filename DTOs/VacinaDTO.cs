using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviario_Campo_Alegre.DTOs
{
    public class VacinaDTO
    {
        public int NumeroLote { get; set; }	
        public string Nome { get; set; }
        public DateOnly DataAplicacao { get; set; }
        public DateOnly DataProxAplicacao { get; set; }
        public string NumeroNota { get; set; }
        public DateOnly Validade { get; set; }
        public string Laboratorio { get; set; }
        public decimal Preco { get; set; }
    }
}