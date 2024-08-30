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
    public class VacinaController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        public VacinaController(OrganizadorContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(VacinaDTO vacinaDTO){
            var vacina = new VacinaModel{
                NumeroLote = vacinaDTO.NumeroLote,
                Nome = vacinaDTO.Nome,
                DataAplicacao = vacinaDTO.DataAplicacao,
                DataProxAplicacao = vacinaDTO.DataProxAplicacao,
                NumeroNota = vacinaDTO.NumeroNota,
                Validade = vacinaDTO.Validade,
                Laboratorio = vacinaDTO.Laboratorio,
                Preco = vacinaDTO.Preco
            };
            _context.Vacinas.Add(vacina);
            _context.SaveChanges();
            return(Ok(vacina));
        }

        [HttpGet("ListarTodasVacinas")]
        public IActionResult Listar(){
            return Ok(_context.Vacinas.ToList());
        }

        [HttpGet("ListarVacinasPorIdDeLote{numeroLote}")]
        public IActionResult ListarPorId(int numeroLote){
            var vacinas = _context.Vacinas.Where(x => x.NumeroLote == numeroLote).ToList();
            if(vacinas==null){return NotFound();}
            return Ok(vacinas);
        }




    }
}