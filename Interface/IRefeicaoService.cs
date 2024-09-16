using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Interface
{
    public interface IRefeicaoService
    {
        public void Cadastrar(RefeicaoModel refeicaoModel);
        public RefeicaoModel TransformarDTO(RefeicaoDTO refeicaoDTO, int idRacao);
        public List<RefeicaoModel> ListarRefeicoes();
        public List<RefeicaoModel> ListarPorLote(int idLote);
        public List<RefeicaoModel> AcharRacoes(List<RefeicaoModel> lista);
        public RefeicaoModel GetRefeicao(int id);
    }
}