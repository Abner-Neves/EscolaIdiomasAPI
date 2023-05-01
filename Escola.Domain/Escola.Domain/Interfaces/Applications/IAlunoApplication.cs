using Escola.Domain.DTOs;
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
        public Task<IEnumerable<GetAlunoDto>> GetAlunos();
        public Task<GetAlunoDto> GetAlunoByCpf(string cpf);
        public Task<InsertAlunoDto> InsertAluno(InsertAlunoDto aluno);
        public Task<Aluno> UpdateAluno(Aluno aluno);
        public Task<Aluno> DeleteAluno(int id);
        public bool VerificaCpf(string cpf);
        public bool VerificaEmail(string email);
        public bool CpfExistente(string cpf);  

    }
}
