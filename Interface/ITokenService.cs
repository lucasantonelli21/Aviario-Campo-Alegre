using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Models;

namespace Aviario_Campo_Alegre.Interface
{
    public interface ITokenService
    {
        string GenerateToken(AdministradorModel administradorModel);
    }
}