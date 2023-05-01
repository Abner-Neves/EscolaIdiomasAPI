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
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;
        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Aluno> DeleteAluno(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Aluno> GetAlunoByCpf(string cpf)
         => await _context.Set<Aluno>().Where(a => a.Cpf == cpf).FirstOrDefaultAsync();

        public async Task<IEnumerable<Aluno>> GetAlunos()
            => await _context.Set<Aluno>().OrderBy(a => a.Id).ToListAsync();

        public async Task<Aluno> InsertAluno(Aluno aluno)
        {
            await _context.Set<Aluno>().AddAsync(aluno);
            _context.SaveChanges();
            return aluno;
        }

        public Task<Aluno> UpdateAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public async Task<int> QuantidadeNaTurma(int turmaId)
            => await _context.Set<Aluno>().Where(a => a.TurmaId == turmaId).CountAsync();

        public async Task<bool> VerificaAlunoNaTurma(string cpf, int turmaId)
            => await _context.Set<Aluno>().Where(a => a.TurmaId == turmaId && a.Cpf == cpf).CountAsync() >= 1;

    }
}
