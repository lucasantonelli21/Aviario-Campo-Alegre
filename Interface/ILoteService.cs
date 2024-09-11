using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Interface
{
    public interface ILoteService
    {
        public LoteModel TransformarDTO(LoteDTO loteDTO);
        public void CadastrarLote(LoteModel lote);
        public List<LoteModel> ListarLotes();
        public LoteModel  GetLote(int idLote);
        public LoteModel VenderLote(LoteModel lote, decimal valorVenda);
        public LoteModel AdicionarMortalidade(LoteModel lote, int qntdMortos);
        public LoteModel AdicionarConsumo(LoteModel lote, int qntdCosumo);
        public LoteModel AdicionarVenda(LoteModel lote,int qntdVendas, decimal precoVendas);

    }
}