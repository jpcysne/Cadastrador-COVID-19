using Cadastrador_COVID_19.Data;
using Cadastrador_COVID_19.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastrador_COVID_19.Service
{
    public class LocalVacinacaoService
    {
        private readonly CadastroContext _context;

        public LocalVacinacaoService(CadastroContext context)
        {
            _context = context;
        }

        public async Task<List<LocalVacinacao>> FindAllAsync()
        {
            return await _context.LocalVacinacao.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
