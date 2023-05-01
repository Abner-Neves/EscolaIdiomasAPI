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
        public async Task<IEnumerable<Aluno>> GetAlunos()
            => await _context.Set<Aluno>().OrderBy(a => a.Id).ToListAsync();

        public async Task<Aluno> GetAlunoByCpf(string cpf)
            => await _context.Set<Aluno>().Where(a => a.Cpf == cpf).FirstOrDefaultAsync();

        public async Task<Aluno> GetAlunoByCpfForUpdate(string cpf, int id)
            => await _context.Set<Aluno>().Where(a => a.Cpf == cpf && a.Id != id).FirstOrDefaultAsync();
        public async Task<Aluno> InsertAluno(Aluno aluno)
        {
            await _context.Set<Aluno>().AddAsync(aluno);
            _context.SaveChanges();
            return aluno;
        }
        public async Task<Aluno> UpdateAluno(Aluno aluno)
        {
            var oldAluno = await _context.Set<Aluno>().Where(a => a.Id == aluno.Id).FirstOrDefaultAsync();

            oldAluno.Nome = aluno.Nome;
            oldAluno.Cpf = aluno.Cpf;
            oldAluno.Email = aluno.Email;

            await _context.SaveChangesAsync();
            return aluno;
        }
        public async Task DeleteAluno(int id)
            => await _context.Set<Aluno>().Where(a => a.Id == id).ExecuteDeleteAsync();
        
    }
}
