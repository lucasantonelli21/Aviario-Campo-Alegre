using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviario_Campo_Alegre.Models
{
    public class VacinaModel
    {
        public int Id { get; set; }
        public int NumeroLote { get; set; }	
        public string Nome { get; set; }
        public DateOnly DataAplicacao { get; set; }
        public DateOnly DataProxAplicao { get; set; }
        public string NumeroNota { get; set; }
        public DateOnly Validade { get; set; }
        public string Laboratorio { get; set; }
        public decimal Preco { get; set; }
    }
}