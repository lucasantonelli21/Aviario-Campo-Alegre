using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public AdministradorController(OrganizadorContext context)
        {_context = context;}

        [HttpPost]
        //TODO: Geração de token JWT e HashCode da senha / criptografia
        public IActionResult Login(LoginDTO loginDTO)
        {
            var login = _context.Administradores.Where(x=> x.Email== loginDTO.Email && x.Password== loginDTO.Password).FirstOrDefault();                       
            if(login!=null){
                return Ok(loginDTO);
              }  
            return NotFound();	
        }
    }
}