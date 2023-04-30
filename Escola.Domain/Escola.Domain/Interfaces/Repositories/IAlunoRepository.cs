using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        public Task<IEnumerable<Aluno>> GetAlunos();
    }
}
