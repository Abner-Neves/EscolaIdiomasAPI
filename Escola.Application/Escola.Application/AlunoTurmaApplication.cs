using AutoMapper;
using Escola.Domain.DTOs.Aluno;
using Escola.Domain.DTOs.AlunoTurma;
using Escola.Domain.DTOs.Turma;
using Escola.Domain.Interfaces.Applications;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Application
{
    public class AlunoTurmaApplication : IAlunoTurmaApplication
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public AlunoTurmaApplication(IAlunoTurmaRepository alunoTurmaRepository, IAlunoRepository alunoRepository, ITurmaRepository turmaRepository, IMapper mapper)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
            _alunoRepository = alunoRepository; 
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }

        public async Task <IEnumerable<GetAlunoTurmaDto>> GetAlunosTurmas()
        {
            var alunoTurmas = await _alunoTurmaRepository.GetAlunosTurmas();
            var alunoTurmasDto = _mapper.Map<IEnumerable<GetAlunoTurmaDto>>(alunoTurmas);
            return alunoTurmasDto;
        }

        public async Task<InsertAlunoTurmaDto> InsertAlunoTurma(InsertAlunoTurmaDto alunoTurmaDto)
        {
            var turmaId = alunoTurmaDto.TurmaId;
            var alunoID = alunoTurmaDto.AlunoID;

            if( await _turmaRepository.GetTurmaById(turmaId) == null)
                throw new Exception("Turma Inválida");

            if (await _alunoRepository.GetAlunoById(alunoID) == null)
                throw new Exception("Aluno Inválido");

            if (await _alunoTurmaRepository.QuantidadeNaTurma(turmaId) >= 5)
                throw new Exception("Turma Cheia");

            if (await _alunoTurmaRepository.VerificaSeAlunoNaTurma(alunoID, turmaId))
                throw new Exception("Aluno já cadastrado nessa turma");

            var alunoTurma = _mapper.Map<AlunoTurma>(alunoTurmaDto);
            await _alunoTurmaRepository.InsertAlunoTurma(alunoTurma);
            return alunoTurmaDto;
        }

        public async Task DeleteAlunoTurma(int id)
            => await _alunoTurmaRepository.DeleteAlunoTurma(id);
    }
}
