using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Models;
using Aviario_Campo_Alegre.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aviario_Campo_Alegre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Adm")]
    public class RelatorioController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        private IRelatorioService relatorioService;
        public RelatorioController(OrganizadorContext context)
        {
            this._context = context;
            this.relatorioService = new RelatorioService(context);
        }
      
        [HttpGet("GerarRelatorio{idLote}")]
        public IActionResult GerarRelatorio(int idLote){
            
            var relatorio = relatorioService.GerarRelatorio(idLote);
            return Ok(relatorio);
        }
    }
}