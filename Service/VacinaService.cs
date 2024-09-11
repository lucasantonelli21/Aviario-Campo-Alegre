using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Models;

namespace Aviario_Campo_Alegre.Service
{
    public class VacinaService : IVacinaService
    {
        private readonly OrganizadorContext _context;
        public VacinaService(OrganizadorContext context)
        {
            this._context = context;
        }

        public void CadastrarVacina(VacinaModel vacina)
        {
            _context.Vacinas.Add(vacina);
            _context.SaveChanges();
        }

        public List<VacinaModel> ListarPorLote(int IdLote)
        {
           var vacinas = _context.Vacinas.Where(x => x.NumeroLote == IdLote).ToList();
            return vacinas;
        }

        public List<VacinaModel> ListarVacinas()
        {
            return _context.Vacinas.ToList();
        }

        public VacinaModel TransformaDTO(VacinaDTO vacinaDTO)
        {
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
            return vacina;
        }
    }
}