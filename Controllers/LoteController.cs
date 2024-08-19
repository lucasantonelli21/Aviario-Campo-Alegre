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

    }
}