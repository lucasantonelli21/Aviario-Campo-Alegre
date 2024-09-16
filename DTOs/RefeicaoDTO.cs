using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Models;

namespace Aviario_Campo_Alegre.DTOs
{
    public class RefeicaoDTO
    {
        public int NumeroLote { get; set; }
        public double QuantidadeRacao { get; set; }
        public DateOnly DataAdministracao { get; set; }
        
        
    
    }
}