using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Models;

namespace Aviario_Campo_Alegre.Service
{
    public class VendaService : IVendasService
    {
        private readonly OrganizadorContext _context;
        
        public VendaService(OrganizadorContext context)
        {   
            this._context = context;
        }
        public void Cadastrar(VendaAnimal venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
        }

        public List<LoteModel> GetVendas(List<LoteModel> lotes)
        {
            foreach(var lote in lotes){
                lote.QuantidadeVendas = _context.Vendas.Where(x => x.NumeroLote == lote.Id).ToList();
            }
            return lotes;
        }
        public List<VendaAnimal> GetVendas(int IdLote){
            return _context.Vendas.Where(x => x.NumeroLote == IdLote).ToList();
        }
    }
}