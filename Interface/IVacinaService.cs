using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Models;

namespace Aviario_Campo_Alegre.Interface
{
    public interface IVacinaService
    {
        public VacinaModel TransformaDTO(VacinaDTO vacinaDTO);
        public void CadastrarVacina(VacinaModel vacina);
        public List<VacinaModel> ListarVacinas();
        public List<VacinaModel> ListarPorLote(int IdLote);
    }
}