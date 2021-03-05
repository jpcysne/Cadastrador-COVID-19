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
    public class PacienteService
    {
        private readonly CadastroContext _context;

        public PacienteService(CadastroContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> FindAllAsync()
        {
            return await _context.Paciente.ToListAsync();
        }

        public async Task InsertAsync(Paciente obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Paciente> FindByIdAsync(int id)
        {
            return await _context.Paciente.Include(obj => obj.Local).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Paciente.FindAsync(id);
                _context.Paciente.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Paciente obj)
        {
            bool hasAny = await _context.Paciente.AnyAsync(x => x.Id == obj.Id);
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
