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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Adm")]
    public class RacaoController  : Controller	
    {
        private readonly OrganizadorContext _context;
        private IRacaoService racaoService;

        public RacaoController(OrganizadorContext context)
        {
            _context = context;
            racaoService = new RacaoService(context);
        }
        
        
        [HttpPost]
        public IActionResult Cadastrar(RacaoDTO racaoDTO)
        {
            var racao = racaoService.TransformarDTO(racaoDTO);
            _context.Racoes.Add(racao);
            _context.SaveChanges();

            return Ok(racao);
        }


        [HttpGet]
        public IActionResult Listar(){
            return Ok(racaoService.ListarRacoes());
        }

        [HttpPut("AtualizarPreco{idRacao},{novoPreco}")]
        public IActionResult AtualizarPreco(int idRacao,decimal novoPreco){
            var racao = racaoService.GetRacao(idRacao);
            if(racao == null)
                return NotFound();
            racao = racaoService.AtualizarPreco(racao,novoPreco);
            return Ok(racao);
        } 

        [HttpPut("AtualizarDiasDeAplicacao{idRacao},{novaQuantidadeDias}")]
        public IActionResult AtualizarDiasDeAplicacao(int idRacao,int novaQuantidadeDias){
            var racao = racaoService.GetRacao(idRacao);
            if(racao == null)
                return NotFound();
            racao = racaoService.AtualizarDataAplicacao(racao,novaQuantidadeDias);
            return Ok(racao);
        }

    }
}