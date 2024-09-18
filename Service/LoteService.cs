using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Service
{
    public class LoteService : ILoteService
    {
        private readonly OrganizadorContext _context;
        private IVendasService vendaService;
        public LoteService(OrganizadorContext context)
        {   
            this._context = context;
            this.vendaService = new VendaService(context);
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
        public void CadastrarLote(LoteModel lote)
        {
            _context.Lotes.Add(lote);
            _context.SaveChanges();
            
        }
        public List<LoteModel> ListarLotes(){
            var lotes = _context.Lotes.ToList();
            lotes = vendaService.GetVendas(lotes);
            return lotes;
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
            vendaService.Cadastrar(novaVenda);
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
            var listaVendas = vendaService.GetVendas(lote.Id);
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
            vendaService.Cadastrar(novaVenda);
            _context.SaveChanges();
            return lote;
        }

        
    }

}