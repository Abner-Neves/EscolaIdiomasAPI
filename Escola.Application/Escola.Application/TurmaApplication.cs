using AutoMapper;
using Escola.Domain.DTOs;
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
    public class TurmaApplication : ITurmaApplication
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IMapper _mapper;

        public TurmaApplication(ITurmaRepository repository, IAlunoTurmaRepository alunoTurmaRepository, IMapper mapper)
        {
            _turmaRepository = repository;
            _alunoTurmaRepository = alunoTurmaRepository;
            _mapper = mapper;
        }
        public async Task DeleteTurma(int id)
        {
            if (await _alunoTurmaRepository.VerificaSeAlunosNaTurma(id))
                throw new Exception("A turma contém alunos, portanto não pode ser deletada");

            await _turmaRepository.DeleteTurma(id);
        }

        public async Task<GetTurmaDto> GetTurmaById(int id)
        {
            var turma = await _turmaRepository.GetTurmaById(id);
            if (turma == null) 
                throw new Exception("Turma não encontrada"); 

            var turmaDto = _mapper.Map<GetTurmaDto>(turma);
            return turmaDto;
        }

        public async Task<IEnumerable<GetTurmaDto>> GetTurmas()
        {
            var turmas = await _turmaRepository.GetTurmas();
            var turmasDto = _mapper.Map<IEnumerable<GetTurmaDto>>(turmas);
            return turmasDto;
        }

        public async Task<GetTurmaDto> InsertTurma(InsertTurmaDto turmaDto)
        {
            var turma = _mapper.Map<Turma>(turmaDto);
            var result = await _turmaRepository.InsertTurma(turma);
            return _mapper.Map<GetTurmaDto>(result);
        }

        public async Task<GetTurmaDto> UpdateTurma(int id, UpdateTurmaDto turmaDto)
        {
            var buscaTurma = await _turmaRepository.GetTurmaById(id);
            if (buscaTurma == null)
                throw new Exception("Turma não encontrada");

            var turma = _mapper.Map<Turma>(turmaDto);
            turma.Id = id;
            var result = await _turmaRepository.UpdateTurma(turma);
            return _mapper.Map<GetTurmaDto>(result);
        }
    }
}
