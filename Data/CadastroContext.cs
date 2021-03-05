using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastrador_COVID_19.Model;
using Microsoft.EntityFrameworkCore;

namespace Cadastrador_COVID_19.Data
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options)
           : base(options)
        {
        }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<LocalVacinacao> LocalVacinacao { get; set; }
    }
}
