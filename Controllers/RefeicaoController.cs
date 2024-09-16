using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Models;
using Aviario_Campo_Alegre.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Adm")]
    public class RefeicaoController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        private RefeicaoService refeicaoService;
        public RefeicaoController(OrganizadorContext context)
        {
            this._context = context;
            this.refeicaoService = new RefeicaoService(context);
        }

        [HttpPost("IdRacao{int}")]
        public IActionResult Cadastrar(int IdRacao,RefeicaoDTO refeicaoDTO){
            var refeicao = refeicaoService.TransformarDTO(refeicaoDTO,IdRacao);
            if(refeicao.Racao == null)
                return NotFound();
            refeicaoService.Cadastrar(refeicao);
            return Ok(refeicao);
        }

        [HttpGet("Listar")]
        public IActionResult Listar(){
            var lista = refeicaoService.ListarRefeicoes();
            lista = refeicaoService.AcharRacoes(lista);
            
            return Ok(lista);
        }
        [HttpGet("BuscarRefeicao{idRefeicao}")]
        public IActionResult Retornar(int idRefeicao ){
            var refeicao = refeicaoService.GetRefeicao(idRefeicao);
            if(refeicao == null)
                return NotFound();
            return Ok(refeicao);
        }
        [HttpGet("ListarRefeicoesPorLote{idLote}")]
        public IActionResult ListarRefeicoesPorLote(int idLote){
            var refeicao = refeicaoService.ListarPorLote(idLote);
            if(refeicao == null)           
                return NotFound();
            return Ok(refeicao);
        }

    }
}