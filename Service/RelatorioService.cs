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
    public class RelatorioService : IRelatorioService
    {
        private readonly OrganizadorContext _context;
        private LoteService loteService;
        private VacinaService vacinaService;
        private VendaService vendaService;
        private RefeicaoService refeicaoService;
        public RelatorioService(OrganizadorContext context)
        {
            this._context = context;
            this.loteService = new LoteService(context);
            this.vendaService = new VendaService(context);
            this.vacinaService = new VacinaService(context);
            this.refeicaoService = new RefeicaoService(context);
        }
        
        public RelatorioDTO CalcularLucro(RelatorioDTO relatorio)
        {
            decimal valorVacinas = 0;
            decimal valorRefeicoes = 0;
            decimal valorVendas = 0;
            foreach(var vacina in relatorio.Vacinas){
                valorVacinas = valorVacinas + vacina.Preco;
            }
            foreach(var refeicao in relatorio.Refeicoes){
                valorRefeicoes = valorRefeicoes + refeicao.PrecoAplicao;
            }
            foreach (var venda in relatorio.VendaAnimal){
                valorVendas = valorVendas + (venda.PrecoVenda*venda.Quantidade);
            }
            relatorio.Lucro = valorVendas - (relatorio.PrecoLote + valorVacinas + valorRefeicoes);
            return relatorio;
        }

        
        public RelatorioDTO GerarRelatorio(int idLote)
        {
            var lote = loteService.GetLote(idLote);
            if(lote == null){return null;}
            var refeicoes = refeicaoService.ListarPorLote(lote.Id);
            var vendas = vendaService.GetVendas(lote.Id);
            var vacinas = vacinaService.ListarPorLote(lote.Id);
            var relatorio = new RelatorioDTO{
                NumeroLote = idLote,
                PrecoLote = lote.PrecoLote,
                Refeicoes = new List<RefeicaoModel>(),
                QuantidadeConsumo = lote.QuantidadeConsumo,
                QuantidadeAnimais = lote.QuantidadeAnimais,
                QuantidadeMortos = lote.QuantidadeMortos,
                VendaAnimal = new List<VendaAnimal>(),
                Vacinas = new List<VacinaModel>(),
                Lucro = 0
            };
            foreach(var refeicao in refeicoes){
                relatorio.Refeicoes.Add(refeicao);
            }
            foreach(var venda in vendas){
                relatorio.VendaAnimal.Add(venda);
            }
            foreach(var vacina in vacinas){
                relatorio.Vacinas.Add(vacina);
            }
            relatorio = CalcularLucro(relatorio);
            return relatorio;
        }
    }
}