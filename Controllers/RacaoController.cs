using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RacaoController  : Controller	
    {
        private readonly OrganizadorContext _context;

        public RacaoController(OrganizadorContext context)
        {_context = context;}
        
        
        [HttpPost]
        public IActionResult Cadastrar(RacaoDTO racaoDTO)
        {
            var racao = new RacaoModel{
                TipoDaRacao = racaoDTO.TipoDaRacao.ToString(),
                Preco = racaoDTO.Preco,
                QuantidadeDiasAplicacao = racaoDTO.QuantidadeDiasAplicacao
            };
            _context.Racoes.Add(racao);
            _context.SaveChanges();

            return Ok(racao);
        }


        [HttpGet]
        public IActionResult Listar(){
            return Ok(_context.Racoes.ToList());
        }

        [HttpPut("AtualizarPreco{idRacao},{novoPreco}")]
        public IActionResult AtualizarPreco(int idRacao,decimal novoPreco){
            var racao = _context.Racoes.Find(idRacao);
            if(racao == null)
                return NotFound();
            racao.Preco = novoPreco;
            _context.Racoes.Update(racao);
            _context.SaveChanges();
            return Ok(racao);
        } 

        [HttpPut("AtualizarDiasDeAplicacao{idRacao},{novaQuantidadeDias}")]
        public IActionResult AtualizarDiasDeAplicacao(int idRacao,int novaQuantidadeDias){
            var racao = _context.Racoes.Find(idRacao);
            if(racao == null)
                return NotFound();
            racao.QuantidadeDiasAplicacao = novaQuantidadeDias;
            _context.Racoes.Update(racao);
            _context.SaveChanges();
            return Ok(racao);
        }

    }
}