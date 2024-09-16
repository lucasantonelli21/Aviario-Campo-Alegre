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
    public class RefeicaoService : IRefeicaoService
    {
        private readonly OrganizadorContext _context;
        public RefeicaoService(OrganizadorContext context)
        {
            this._context = context;
        }

        public RefeicaoModel TransformarDTO(RefeicaoDTO refeicaoDTO, int idRacao){
             var racao = _context.Racoes.Find(idRacao);
             if (racao == null) return null;
             var refeicao = new RefeicaoModel {
                NumeroLote = refeicaoDTO.NumeroLote,
                Racao = racao,
                QuantidadeRacao = refeicaoDTO.QuantidadeRacao,
                DataAdministracao = refeicaoDTO.DataAdministracao,
                PrecoAplicao = (racao.Preco * (decimal)refeicaoDTO.QuantidadeRacao)
            };
            return refeicao;
        }

        public void Cadastrar(RefeicaoModel refeicao)
        {   
            _context.Refeicoes.Add(refeicao);
            _context.SaveChanges();
        }

        public List<RefeicaoModel> ListarRefeicoes()
        {
            return _context.Refeicoes.ToList();
        }
        public List<RefeicaoModel> AcharRacoes(List<RefeicaoModel> refeicaoModels)
        {
            foreach(var refeicao in refeicaoModels){
                refeicao.Racao = _context.Racoes.Find(refeicao.IdRacao);
            }
            return refeicaoModels;
        }

        public RefeicaoModel GetRefeicao(int id){
            var refeicao = _context.Refeicoes.Find(id);
            if(refeicao == null){return null;}
            refeicao.Racao = _context.Racoes.Find(refeicao.IdRacao);
            return refeicao;
        }

        public List<RefeicaoModel> ListarPorLote(int idLote)
        {
            var refeicoes = _context.Refeicoes.Where(x=> x.NumeroLote == idLote).ToList();
            return refeicoes;
        }
    }
}