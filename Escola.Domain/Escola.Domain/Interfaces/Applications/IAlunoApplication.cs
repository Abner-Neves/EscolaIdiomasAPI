using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Applications
{
    public interface IAlunoApplication
    {
        public Task<IEnumerable<Aluno>> GetAlunos();
    }
}
