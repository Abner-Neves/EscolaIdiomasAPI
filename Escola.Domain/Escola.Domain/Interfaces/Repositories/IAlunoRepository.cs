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
        public Task<Aluno> GetAlunoById(int id);
        public Task<Aluno> GetAlunoByCpf(string cpf);
        public Task<Aluno> GetAlunoByCpfForUpdate(string cpf, int id);   
        public Task<Aluno> InsertAluno(Aluno aluno);   
        public Task<Aluno> UpdateAluno (Aluno aluno);   
        public Task DeleteAluno (int id);
    }
}
