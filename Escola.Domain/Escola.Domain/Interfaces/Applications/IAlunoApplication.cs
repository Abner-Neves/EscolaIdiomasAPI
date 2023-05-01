using Escola.Domain.DTOs.Aluno;
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
        public Task<GetAlunoDto> UpdateAluno(int id, UpdateAlunoDto aluno);
        public Task DeleteAluno(int id);
        public bool VerificaCpf(string cpf);
        public bool VerificaEmail(string email);
        public Task<bool> CpfExistente(string cpf);
        public Task<bool> CpfExistente(string cpf, int id);
        public Task<bool> VerificaSeTurmaExiste(int turmaId);
        public Task<bool> VerificaSeTurmaCheia(int turmaId);

    }
}
