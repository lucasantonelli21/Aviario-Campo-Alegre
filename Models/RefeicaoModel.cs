using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviario_Campo_Alegre.Models
{
    public class RefeicaoModel
    {
        public int Id { get; set; }
        public int IdRacao { get; set; }
        public virtual RacaoModel Racao { get; set; }
        public int NumeroLote { get; set; }
        public double QuantidadeRacao { get; set; }
        public DateOnly DataAdministracao { get; set; }
        
        public decimal PrecoAplicao { get; set; }	


        

    }
}