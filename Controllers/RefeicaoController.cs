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
    public class RefeicaoController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        public RefeicaoController(OrganizadorContext context)
        {
            this._context = context;
        }

        [HttpPost("IdRacao{int}")]
        public IActionResult Cadastrar(int IdRacao,RefeicaoDTO refeicaoDTO){
            var refeicao = new RefeicaoModel {
                NumeroLote = refeicaoDTO.NumeroLote,
                Racao = _context.Racoes.Find(IdRacao),
                QuantidadeRacao = refeicaoDTO.QuantidadeRacao,
                DataAdministracao = refeicaoDTO.DataAdministracao,
                PrecoAplicao = refeicaoDTO.PrecoAplicao
            };
            if(refeicao.Racao == null)
                return NotFound();
            _context.Refeicoes.Add(refeicao);
            _context.SaveChanges();
            return Ok(refeicao);
        }

        [HttpGet("Listar")]
        public IActionResult Listar(){
            var lista = _context.Refeicoes.ToList();
            foreach(var item in lista){
                item.Racao = _context.Racoes.Find(item.IdRacao);
            }
            return Ok(lista);
        }
        [HttpGet("BuscarRefeicao{idRefeicao}")]
        public IActionResult Retornar(int idRefeicao ){
            var refeicao = _context.Refeicoes.Find(idRefeicao);
            refeicao.Racao = _context.Racoes.Find(refeicao.IdRacao);
            return Ok(refeicao);
        }

    }
}