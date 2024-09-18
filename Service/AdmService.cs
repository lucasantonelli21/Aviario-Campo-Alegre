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
    public class AdmService : IAdmService
    {
        private readonly OrganizadorContext _context;
        private ITokenService tokenService;
        public AdmService(OrganizadorContext context, ITokenService tokenService)
        {   
            this._context = context;
            this.tokenService = tokenService;
        }
        public string Logar(LoginDTO loginDTO)
        {
            var login = _context.Administradores.Where(x=> x.Email== loginDTO.Email && x.Password== loginDTO.Password).FirstOrDefault();
            if(login == null)
                return null;
            string token = tokenService.GenerateToken(login);
            return token;
        }
    }
}