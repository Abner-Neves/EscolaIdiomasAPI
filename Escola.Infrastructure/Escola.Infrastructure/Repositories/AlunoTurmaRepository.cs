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
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        private readonly AppDbContext _context;
        public AlunoTurmaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AlunoTurma>> GetAlunosTurmas()
            => await _context.Set<AlunoTurma>().OrderBy(t => t.Id).ToListAsync();
        public async Task InsertAlunoTurma(AlunoTurma alunoTurma)
        {
            await _context.Set<AlunoTurma>().AddAsync(alunoTurma);
            _context.SaveChanges();
        }
        public async Task<int> QuantidadeNaTurma(int turmaId)
           => await _context.Set<AlunoTurma>().Where(a => a.TurmaId == turmaId).CountAsync();
        public async Task<bool> VerificaSeAlunoNaTurma(int alunoId, int turmaId)
            => await _context.Set<AlunoTurma>().Where(a => a.TurmaId == turmaId && a.AlunoId == alunoId).CountAsync() >= 1;
        public async Task<bool> VerificaSeAlunosNaTurma(int turmaId)
            => await _context.Set<AlunoTurma>().Where(a => a.TurmaId == turmaId).CountAsync() >= 1;
        public async Task<bool> VerificaSeAlunoEmAlgumaTurma(int alunoId)
            => await _context.Set<AlunoTurma>().Where(a => a.AlunoId == alunoId).CountAsync() >= 1;
        public async Task DeleteAlunoTurma(int id)
            => await _context.Set<AlunoTurma>().Where(a => a.Id == id).ExecuteDeleteAsync();
    }
}
