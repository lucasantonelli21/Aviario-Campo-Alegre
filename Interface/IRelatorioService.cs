using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.DTOs;

namespace Aviario_Campo_Alegre.Interface
{
    public interface IRelatorioService
    {
        public RelatorioDTO GerarRelatorio(int idLote);
        public RelatorioDTO CalcularLucro(RelatorioDTO relatorio);
    }
}