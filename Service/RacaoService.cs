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
    public class RacaoService : IRacaoService
    {
        private readonly OrganizadorContext _context;

        public RacaoService(OrganizadorContext context)
        {
            this._context = context;
        }

        public RacaoModel AtualizarDataAplicacao(RacaoModel racao, int novaQuantidadeDias)
        {
            racao.QuantidadeDiasAplicacao = novaQuantidadeDias;
            _context.Racoes.Update(racao);
            _context.SaveChanges();
            return racao;
        }

        public RacaoModel AtualizarPreco(RacaoModel racao, decimal novoPreco)
        {
            racao.Preco = novoPreco;
            _context.Racoes.Update(racao);
            _context.SaveChanges();
            return racao;
        }

        public RacaoModel GetRacao(int idRacao)
        {
            return _context.Racoes.Find(idRacao);
        }

        public List<RacaoModel> ListarRacoes()
        {
            return _context.Racoes.ToList();
        }

        public RacaoModel TransformarDTO(RacaoDTO racaoDTO)
        {
            var racao = new RacaoModel{
                TipoDaRacao = racaoDTO.TipoDaRacao.ToString(),
                Preco = racaoDTO.Preco,
                QuantidadeDiasAplicacao = racaoDTO.QuantidadeDiasAplicacao
            };
            return racao;
        }
    }
}