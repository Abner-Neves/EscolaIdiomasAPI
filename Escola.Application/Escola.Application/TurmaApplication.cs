using Escola.Domain.Interfaces.Applications;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Application
{
    public class TurmaApplication : ITurmaApplication
    {
        public Task<Turma> DeleteTurma(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Turma> GetTurmaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Turma>> GetTurmas()
        {
            throw new NotImplementedException();
        }

        public Task<Turma> InsertTurma(Turma turma)
        {
            throw new NotImplementedException();
        }

        public Task<Turma> UpdateTurma(Turma turma)
        {
            throw new NotImplementedException();
        }
    }
}
