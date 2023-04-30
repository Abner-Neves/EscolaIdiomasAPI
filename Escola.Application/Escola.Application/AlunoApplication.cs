using Escola.Domain.Interfaces.Applications;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;

namespace Escola.Application
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepository _repository;

        public AlunoApplication(IAlunoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Aluno>> GetAlunos()
            => await _repository.GetAlunos();
    }
}