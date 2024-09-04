using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aviario_Campo_Alegre.Controllers
{
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        public RelatorioController(OrganizadorContext context)
        {
            this._context = context;
        }
      //TODO: CALCULO LUCRO
        [HttpGet("GerarRelatorio{idLote}")]
        public IActionResult GerarRelatorio(int idLote){
            var lote = _context.Lotes.Find(idLote);
            if(lote == null){return NotFound();}
            var refeicoes = _context.Refeicoes.Where(x=> x.NumeroLote == idLote);
            var vendas = _context.Vendas.Where(x=> x.NumeroLote == idLote);
            var vacinas = _context.Vacinas.Where(x=> x.NumeroLote == idLote);
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
            
            return Ok(relatorio);
        }
    }
}