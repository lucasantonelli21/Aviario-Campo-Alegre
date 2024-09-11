using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Models;

namespace Aviario_Campo_Alegre.Interface
{
    public interface IRacaoService
    {
        public RacaoModel TransformarDTO(RacaoDTO racaoDTO);
        public List<RacaoModel> ListarRacoes();
        public RacaoModel AtualizarPreco(RacaoModel racao, decimal novoPrecos);
        public RacaoModel GetRacao(int idRacao);
        public RacaoModel AtualizarDataAplicacao(RacaoModel racao, int novaQuantidadeDias);
    }
}