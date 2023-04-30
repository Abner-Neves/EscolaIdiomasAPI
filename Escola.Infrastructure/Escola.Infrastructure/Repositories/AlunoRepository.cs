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
    }
}
