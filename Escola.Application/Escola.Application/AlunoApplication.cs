using AutoMapper;
using Escola.Domain.DTOs.Aluno;
using Escola.Domain.Interfaces.Applications;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;

namespace Escola.Application
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepository _repository;
        private readonly IMapper _mapper;

        public AlunoApplication(IAlunoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAlunoDto>> GetAlunos()
        {
            var alunos = await _repository.GetAlunos();
            var alunosDto = _mapper.Map<IEnumerable<GetAlunoDto>>(alunos);
            return (alunosDto);
        }

        public async Task<GetAlunoDto> GetAlunoByCpf(string cpf)
        {
            if(!VerificaCpf(cpf))
                throw new Exception("CPF Inválido");

            cpf = FormatarCpf(cpf);
            var aluno = await _repository.GetAlunoByCpf(cpf);
            if(aluno == null)
                throw new Exception("Aluno não encontrado");

            var alunoDto = _mapper.Map<GetAlunoDto>(aluno);
            return (alunoDto);

        }

        public async Task<InsertAlunoDto> InsertAluno(InsertAlunoDto alunoDto)
        {
            if(!VerificaCpf(alunoDto.Cpf))
                throw new Exception("CPF Inválido");

            if(!VerificaEmail(alunoDto.Email))
                throw new Exception("Email Inválido");

            if (await _repository.QuantidadeNaTurma(alunoDto.TurmaId) >= 5)
                throw new Exception("Turma cheia");

            if (await CpfExistente(alunoDto.Cpf))
                throw new Exception("CPF informado já existe");

            if (await _repository.VerificaAlunoNaTurma(alunoDto.Cpf, alunoDto.TurmaId))
                throw new Exception("Aluno já cadastrado na turma");

            alunoDto.Cpf = FormatarCpf(alunoDto.Cpf);
            var aluno = _mapper.Map<Aluno>(alunoDto);
            var result = await _repository.InsertAluno(aluno);
            return _mapper.Map<InsertAlunoDto>(result);
        }

        public Task<Aluno> UpdateAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> DeleteAluno(int id)
        {
            throw new NotImplementedException();
        }
        public string FormatarCpf(string cpf)
        {
            var cpfFiltrado = cpf.Replace(".", "").Replace("-", "").Replace(",", "").Replace(";", "").Replace(" ", "");
            return (cpfFiltrado.Insert(3, ".").Insert(7, ".").Insert(11, "-"));
        }

        public async Task<bool> CpfExistente(string cpf)
        {
            cpf = FormatarCpf(cpf);
            var aluno = await _repository.GetAlunoByCpf(cpf);
            if (aluno is null)
                return false;

            return true;
        }

        public bool VerificaCpf(string cpf)
        {
            var cpfFiltrado = cpf.Replace(".", "").Replace("-", "").Replace(",", "").Replace(";", "").Replace(" ", "");
            
            if(cpfFiltrado.Length == 11)
            {
                try
                {
                    var numero = Int64.Parse(cpfFiltrado);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }

        public bool VerificaEmail(string email)
        {
            if(email.Contains("@") && email.Contains(".com"))
                return true;

            return false;
        }
    }
}