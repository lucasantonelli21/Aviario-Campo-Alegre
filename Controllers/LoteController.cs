using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoteController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        public LoteController(OrganizadorContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(LoteDTO loteDTO){
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
            _context.Lotes.Add(lote);
            _context.SaveChanges();
            return Ok(lote);
        }

        [HttpGet]
        public IActionResult Listar() {
            var listaLote = _context.Lotes.ToList();
            foreach(var lote in listaLote){
                lote.QuantidadeVendas = _context.Vendas.Where(x => x.IdLote == lote.Id).ToList();
            }
            return Ok(listaLote);
        }

        [HttpPut("Vender{idLote},{valorVenda}")]
        public IActionResult Vender(int idLote, decimal valorVenda){
            var lote = _context.Lotes.Find(idLote);
            if(lote == null){return NotFound();}
            if(lote.Vendido){return BadRequest();}
            lote.Vendido = true;
            lote.DataVenda = DateOnly.FromDateTime(DateTime.Now);
            var novaVenda = new VendaAnimal{ Quantidade = lote.QuantidadeAnimais,
            PrecoVenda = valorVenda,
            DataVenda = DateOnly.FromDateTime(DateTime.Now),
            IdLote = lote.Id
            };
            _context.Vendas.Add(novaVenda);
            _context.Lotes.Update(lote);
            _context.SaveChanges();
            return Ok(lote);
        }

        [HttpPut("AdicionarMortalidade{idLote},{qntdMortos}")]
        public IActionResult AdicionarMortalidade(int idLote,int qntdMortos){
            var lote = _context.Lotes.Find(idLote);
            if(lote == null){return NotFound();}
            lote.QuantidadeMortos = lote.QuantidadeMortos+qntdMortos;
            _context.Lotes.Update(lote);
            _context.SaveChanges();
            return Ok(lote);
        }
        
        [HttpPut("AdicionarConsumo{idLote},{qntdConsumo}")]
        public IActionResult AdicionarConsumo(int idLote,int qntdConsumo){
            var lote = _context.Lotes.Find(idLote);
            if(lote == null){return NotFound();}
            lote.QuantidadeConsumo = lote.QuantidadeConsumo+qntdConsumo;
            _context.Lotes.Update(lote);
            _context.SaveChanges();
            return Ok(lote);
        }

        
        [HttpPut("AdicionarVenda{idLote},{qntdVendas},{precoVendas}")]
        public IActionResult Vender(int idLote,int qntdVendas,decimal precoVendas){
            var lote = _context.Lotes.Find(idLote);
            if(lote == null){return NotFound();}
            var novaVenda = new VendaAnimal{Quantidade= qntdVendas,PrecoVenda=precoVendas, DataVenda = DateOnly.FromDateTime(DateTime.Now), IdLote = lote.Id };
            _context.Lotes.Update(lote);
            _context.Vendas.Add(novaVenda);
            _context.SaveChanges();
            return Ok(lote);
        }

    /*    [HttpGet("GerarRelatorio{idLote}")]
        public IActionResult GerarRelatorio(int idLote){
            var lote = _context.Lotes.Find(idLote);
            if(lote == null){return NotFound();}
            var refeicoes = _context.Refeicoes.Where(x=> x.NumeroLote == idLote);
            decimal valorTotalRefeicoes= 0;
            foreach(var refeicao in refeicoes){
                valorTotalRefeicoes = valorTotalRefeicoes + refeicao.PrecoAplicao;
            }
            var relatorio = new RelatorioDTO{
                NumeroLote = idLote,
                PrecoLote = lote.PrecoLote,
                PrecoVendaAnimal = lote.PrecoVendaAnimal,
                Refeicoes = new List<RefeicaoModel>(),
                QuantidadeConsumo = lote.QuantidadeConsumo,
                QuantidadeAnimais = lote.QuantidadeAnimais,
                QuantidadeMortos = lote.QuantidadeMortos,
                QuantidadeVendas = lote.QuantidadeVendas,
                Lucro = (lote.PrecoVendaAnimal*lote.QuantidadeVendas)-valorTotalRefeicoes
            };
            foreach(var refeicao in refeicoes){
                relatorio.Refeicoes.Add(refeicao);
            }
            
            return Ok(relatorio);
        }*/
    }
}