using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviario_Campo_Alegre.Models
{
    public class VendaAnimal
    {
        public int Id { get; set;}
        public int NumeroLote { get; set;}
        public long Quantidade { get; set; }
        public decimal PrecoVenda { get; set; }
        public DateOnly DataVenda { get; set; }
    }
}