using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using Escola.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infrastructure.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly AppDbContext _context;
        public TurmaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Turma> GetTurmaById(int id)
            => await _context.Set<Turma>().Where(t => t.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Turma>> GetTurmas()
            => await _context.Set<Turma>().OrderBy(t => t.Id).ToListAsync();

        public async Task<Turma> InsertTurma(Turma turma)
        {
            await _context.Set<Turma>().AddAsync(turma);
            await _context.SaveChangesAsync();
            return turma;
        }

        public async Task<Turma> UpdateTurma(Turma turma)
        {
            var oldTurma = await _context.Set<Turma>().Where(t => t.Id == turma.Id).FirstOrDefaultAsync();

            oldTurma.Numero = turma.Numero;
            oldTurma.AnoLetivo = turma.AnoLetivo;

            await _context.SaveChangesAsync();
            return turma;
        }
        public async Task DeleteTurma(int id)
            => await _context.Set<Turma>().Where(t => t.Id == id).ExecuteDeleteAsync();
    }
}
