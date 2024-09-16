using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Models;

namespace Aviario_Campo_Alegre.Interface
{
    public interface IAdmService
    {
        public string Logar(LoginDTO loginDTO);
        
    }
}