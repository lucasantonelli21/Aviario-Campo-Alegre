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
                QuantidadeVendas = loteDTO.QuantidadeVendas,
                QuantidadeConsumo = loteDTO.QuantidadeConsumo,
                QuantidadeMortos = loteDTO.QuantidadeMortos,
                PrecoLote = loteDTO.PrecoLote,
                PrecoVendaAnimal = 0,
                DataVenda = loteDTO.DataVenda,
                Vendido = false
            };
            _context.Lotes.Add(lote);
            _context.SaveChanges();
            return Ok(lote);
        }

        [HttpGet]
        public IActionResult Listar() {
            return Ok(_context.Lotes.ToList());
        }

        [HttpPut("Vender{idLote}")]
        public IActionResult Vender(int idLote){
            var lote = _context.Lotes.Find(idLote);
            if(lote == null){return NotFound();}
            lote.Vendido = true;
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
            lote.QuantidadeVendas = lote.QuantidadeVendas+qntdVendas;
            lote.PrecoVendaAnimal = precoVendas;
            _context.Lotes.Update(lote);
            _context.SaveChanges();
            return Ok(lote);
        }


    }
}