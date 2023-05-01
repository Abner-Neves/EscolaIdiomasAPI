using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface IAlunoTurmaRepository
    {
        public Task InsertAlunoTurma(AlunoTurma alunoTurma);
        public Task<int> QuantidadeNaTurma(int turmaId);
        public Task<bool> VerificaSeAlunoNaTurma(int alunoId, int turmaId);
        public Task<bool> VerificaSeAlunosNaTurma(int turmaId);
        public Task<bool> VerificaSeAlunoEmAlgumaTurma(int alunoId);
    }
}
