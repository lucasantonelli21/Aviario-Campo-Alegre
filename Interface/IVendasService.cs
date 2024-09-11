using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Models;

namespace Aviario_Campo_Alegre.Interface
{
    public interface IVendasService
    {
        public void Cadastrar(VendaAnimal venda);
        public List<LoteModel> GetVendas(List<LoteModel> lotes);
        public List<VendaAnimal> GetVendas(int IdLote);
    }
}