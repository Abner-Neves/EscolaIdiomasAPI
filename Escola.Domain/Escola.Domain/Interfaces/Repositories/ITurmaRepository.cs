using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface ITurmaRepository
    {
        public Task<IEnumerable<Turma>> GetTurmas();
        public Task<Turma> GetTurmaById(int id);
        public Task<Turma> InsertTurma(Turma turma);
        public Task<Turma> UpdateTurma(Turma turma);
        public Task DeleteTurma(int id);
    }
}
