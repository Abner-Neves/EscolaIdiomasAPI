using AutoMapper;
using Escola.Domain.DTOs.Aluno;
using Escola.Domain.DTOs.AlunoTurma;
using Escola.Domain.DTOs.Turma;
using Escola.Domain.Interfaces.Applications;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;

namespace Escola.Application
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IMapper _mapper;

        public AlunoApplication(IAlunoRepository repository, IAlunoTurmaRepository alunoTurmaRepository, ITurmaRepository turmaRepository, IMapper mapper)
        {
            _alunoRepository = repository;
            _turmaRepository = turmaRepository;
            _alunoTurmaRepository = alunoTurmaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAlunoDto>> GetAlunos()
        {
            var alunos = await _alunoRepository.GetAlunos();
            var alunosDto = _mapper.Map<IEnumerable<GetAlunoDto>>(alunos);
            return (alunosDto);
        }

        public async Task<GetAlunoDto> GetAlunoByCpf(string cpf)
        {
            if(!VerificaCpf(cpf))
                throw new Exception("CPF Inválido");

            cpf = FormatarCpf(cpf);
            var aluno = await _alunoRepository.GetAlunoByCpf(cpf);
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

            if (await CpfExistente(alunoDto.Cpf))
                throw new Exception("CPF informado já existe");

            if (!await VerificaSeTurmaExiste(alunoDto.TurmaId))
                throw new Exception("Turma Inválida");

            if (await VerificaSeTurmaCheia(alunoDto.TurmaId))
                throw new Exception("Turma Cheia");

            alunoDto.Cpf = FormatarCpf(alunoDto.Cpf);
            var aluno = _mapper.Map<Aluno>(alunoDto);
            var result = await _alunoRepository.InsertAluno(aluno);
            await _alunoTurmaRepository.InsertAlunoTurma(new AlunoTurma {AlunoId = result.Id, TurmaId = alunoDto.TurmaId });
            return _mapper.Map<InsertAlunoDto>(result);
        }

        public async Task<GetAlunoDto> UpdateAluno(int id, UpdateAlunoDto alunoDto)
        {
            if (!VerificaCpf(alunoDto.Cpf))
                throw new Exception("CPF Inválido");

            if (!VerificaEmail(alunoDto.Email))
                throw new Exception("Email Inválido");

            if (await CpfExistente(alunoDto.Cpf, id))
                throw new Exception("CPF informado já existe");

            alunoDto.Cpf = FormatarCpf(alunoDto.Cpf);
            var aluno = _mapper.Map<Aluno>(alunoDto);
            aluno.Id = id;
            var result = await _alunoRepository.UpdateAluno(aluno);
            return _mapper.Map<GetAlunoDto>(result);
        }

        public async Task DeleteAluno(int id)
        {
            if(await _alunoTurmaRepository.VerificaSeAlunoEmAlgumaTurma(id))
                throw new Exception("Aluno está cadastrado em um turma, portanto não pode ser deletado");

            await _alunoRepository.DeleteAluno(id);
        }

        public async Task<bool> VerificaSeTurmaExiste(int turmaId)
        {
            var turma = await _turmaRepository.GetTurmaById(turmaId);
            if (turma == null)
                return false;
            return true;
        }

        public async Task<bool> VerificaSeTurmaCheia(int turmaId)
        {
            var quantidadeAlunosTurma = await _alunoTurmaRepository.QuantidadeNaTurma(turmaId);
            if(quantidadeAlunosTurma >= 5)
                return true;

            return false;
        }

        public async Task<bool> CpfExistente(string cpf)
        {
            cpf = FormatarCpf(cpf);
            var aluno = await _alunoRepository.GetAlunoByCpf(cpf);
            if (aluno is null)
                return false;

            return true;
        }

        public async Task<bool> CpfExistente(string cpf, int id)
        {
            cpf = FormatarCpf(cpf);
             var aluno = await _alunoRepository.GetAlunoByCpfForUpdate(cpf, id);
            if (aluno is null)
                return false;

            return true;
        }

        public string FormatarCpf(string cpf)
        {
            var cpfFiltrado = cpf.Replace(".", "").Replace("-", "").Replace(",", "").Replace(";", "").Replace(" ", "");
            return (cpfFiltrado.Insert(3, ".").Insert(7, ".").Insert(11, "-"));
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