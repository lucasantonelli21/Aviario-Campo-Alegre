using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Models;

namespace Aviario_Campo_Alegre.Service
{
    public class LoteService : ILoteService
    {
        private readonly OrganizadorContext _context;
        public LoteService(OrganizadorContext context)
        {   
            this._context = context;
        }

        public LoteModel TransformarDTO(LoteDTO loteDTO)
        {
              var lote = new LoteModel {
                 DataEntrada = loteDTO.DataEntrada,
                 QuantidadeAnimais = loteDTO.QuantidadeAnimais,
                 Linhagem = loteDTO.Linhagem,
                 AviarioOrigem = loteDTO.AviarioOrigem,
                 QuantidadeConsumo = 0,
                 QuantidadeMortos = 0,
                 PrecoLote = loteDTO.PrecoLote,
                 DataVenda = loteDTO.DataVenda,
                 Vendido = false
             };   
             return lote;
        }
        public void CadastrarLote(LoteModel loteDTO)
        {
            _context.Lotes.Add(loteDTO);
            _context.SaveChanges();
        }
        public List<LoteModel> ListarLotes(){
            return _context.Lotes.ToList();
        }
        public LoteModel GetLote(int idLote){
            return _context.Lotes.Find(idLote);
        }
        public LoteModel VenderLote(LoteModel lote, decimal valorVenda){
            lote.Vendido = true;
            lote.DataVenda = DateOnly.FromDateTime(DateTime.Now);
            var novaVenda = new VendaAnimal{ Quantidade = lote.QuantidadeAnimais,
            PrecoVenda = valorVenda,
            DataVenda = DateOnly.FromDateTime(DateTime.Now),
            NumeroLote = lote.Id
            };
            lote.QuantidadeVendas.Add(novaVenda);
            _context.Vendas.Add(novaVenda);
            _context.Lotes.Update(lote);
            _context.SaveChanges();
            return lote;
        }

        public LoteModel AdicionarMortalidade(LoteModel lote, int qntdMortos)
        {
            lote.QuantidadeMortos = lote.QuantidadeMortos+qntdMortos;
            _context.Lotes.Update(lote);
            _context.SaveChanges();
            return lote;
        }


        public LoteModel AdicionarConsumo(LoteModel lote, int qntdConsumo){
            lote.QuantidadeConsumo = lote.QuantidadeConsumo+qntdConsumo;
            _context.Lotes.Update(lote);
            _context.SaveChanges();
            return lote;
        }

        public LoteModel AdicionarVenda(LoteModel lote, int qntdVendas, decimal precoVendas){
            var listaVendas = _context.Vendas.Where(x => x.NumeroLote == lote.Id).ToList();
            long limiteVenda = 0;
            foreach(var venda in listaVendas){
                limiteVenda = limiteVenda + venda.Quantidade;
            }
            if(limiteVenda + qntdVendas > lote.QuantidadeAnimais){return null;}
            if(limiteVenda + qntdVendas == lote.QuantidadeAnimais){lote.Vendido = true;}
            var novaVenda = new VendaAnimal{Quantidade= qntdVendas,PrecoVenda=precoVendas, DataVenda = DateOnly.FromDateTime(DateTime.Now), NumeroLote = lote.Id };
            listaVendas.Add(novaVenda);
            lote.QuantidadeVendas = listaVendas;
            _context.Lotes.Update(lote);
            _context.Vendas.Add(novaVenda);
            _context.SaveChanges();
            return lote;
        }

        
    }

}