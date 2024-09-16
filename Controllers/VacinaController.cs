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
    public class VacinaController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        private VacinaService vacinaService;
        public VacinaController(OrganizadorContext context)
        {
            this._context = context;
            this.vacinaService = new VacinaService(context);
        }

        [HttpPost]
        public IActionResult Cadastrar(VacinaDTO vacinaDTO){
            var vacina = vacinaService.TransformaDTO(vacinaDTO);
            vacinaService.CadastrarVacina(vacina);
            return Ok(vacina);
        }

        [HttpGet("ListarTodasVacinas")]
        public IActionResult Listar(){
            return Ok(vacinaService.ListarVacinas());
        }

        [HttpGet("ListarVacinasPorIdDeLote{numeroLote}")]
        public IActionResult ListarPorId(int numeroLote){
            var vacinas = vacinaService.ListarPorLote(numeroLote);
            if(vacinas==null){return NotFound();}
            return Ok(vacinas);
        }




    }
}