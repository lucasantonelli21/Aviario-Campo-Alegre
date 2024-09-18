using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Models;
using Aviario_Campo_Alegre.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Adm")]
    public class LoteController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        private ILoteService loteService;
        public LoteController(OrganizadorContext context)
        {
            this._context = context;
            this.loteService = new LoteService(context);
        }

        [HttpPost]
        public IActionResult Cadastrar(LoteDTO loteDTO){
            var lote = loteService.TransformarDTO(loteDTO);
            loteService.CadastrarLote(lote);
            return Ok(lote);
        }

        [HttpGet] 
        public IActionResult Listar() {
            var listaLote = loteService.ListarLotes();
            return Ok(listaLote);
        }

        [HttpPut("Vender{idLote},{valorVenda}")]
        public IActionResult Vender(int idLote, decimal valorVenda){
            var lote = loteService.GetLote(idLote);
            if(lote == null){return NotFound();}
            if(lote.Vendido){return BadRequest();}
            lote = loteService.VenderLote(lote,valorVenda);
            return Ok(lote);
        }

        [HttpPut("AdicionarMortalidade{idLote},{qntdMortos}")]
        public IActionResult AdicionarMortalidade(int idLote,int qntdMortos){
            var lote = loteService.GetLote(idLote);
            if(lote == null){return NotFound();}
            lote = loteService.AdicionarMortalidade(lote,qntdMortos);
            return Ok(lote);
        }
        
        [HttpPut("AdicionarConsumo{idLote},{qntdConsumo}")]
        public IActionResult AdicionarConsumo(int idLote,int qntdConsumo){
            var lote = loteService.GetLote(idLote);
            if(lote == null){return NotFound();}
            lote = loteService.AdicionarConsumo(lote,qntdConsumo);
            return Ok(lote);
        }

        
        [HttpPut("AdicionarVenda{idLote},{qntdVendas},{precoVendas}")]
        public IActionResult Vender(int idLote,int qntdVendas,decimal precoVendas){
            var lote = loteService.GetLote(idLote);
            if(lote == null){return NotFound();}
            lote = loteService.AdicionarVenda(lote,qntdVendas,precoVendas);
            if(lote == null){return BadRequest();}
            return Ok(lote);
        }
        
    }
}