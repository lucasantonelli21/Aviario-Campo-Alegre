using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Enums;
namespace Aviario_Campo_Alegre.Models
{   
    public class RacaoModel
    {
        public int Id { get; set;}
        public String TipoDaRacao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeDiasAplicacao { get; set; }	
    }
}