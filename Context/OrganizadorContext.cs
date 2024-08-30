using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Models;
using Microsoft.EntityFrameworkCore;

namespace Aviario_Campo_Alegre.Context
{
    public class OrganizadorContext: DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {}

        public DbSet<AdministradorModel> Administradores { get; set; }
        public DbSet<LoteModel> Lotes { get; set; }
        public DbSet<RefeicaoModel> Refeicoes { get; set; }
        public DbSet<RacaoModel> Racoes { get; set; }
        public DbSet<VacinaModel> Vacinas { get; set; }
        public DbSet<VendaAnimal> Vendas {get; set;}
    }
}