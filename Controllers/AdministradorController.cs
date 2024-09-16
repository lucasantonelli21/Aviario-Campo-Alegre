using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Service;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        private AdmService administradorService;
        public AdministradorController(OrganizadorContext context, IConfiguration configuration)
        {
            _context = context;
            administradorService = new AdmService(context,new TokenService(configuration));
        }

        [HttpPost]
        //TODO: Geração de token JWT e HashCode da senha / criptografia
        public IActionResult Login(LoginDTO loginDTO)
        {
            var login = administradorService.Logar(loginDTO);
            if(login!=null){
                return Ok(login);
              }  
            return Unauthorized();	
        }
    }
}