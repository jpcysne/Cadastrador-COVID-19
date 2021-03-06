using Cadastrador_COVID_19.Data;
using Cadastrador_COVID_19.Model;
using Cadastrador_COVID_19.Service.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastrador_COVID_19.Service
{
    public class AgendamentoService
    {

        private readonly CadastroContext _context;

        public AgendamentoService(CadastroContext context)
        {
            _context = context;
        }

        public async Task<List<Agendamento>> FindAllAsync()
        {
            return await _context.Agendamento.ToListAsync();
        }

        public async Task InsertAsync(Agendamento obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Agendamento> FindByIdAsync(int id)
        {
            return await _context.Agendamento.Include(obj => obj.Paciente).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Agendamento.FindAsync(id);
                _context.Agendamento.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Paciente obj)
        {
            bool hasAny = await _context.Agendamento.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}

