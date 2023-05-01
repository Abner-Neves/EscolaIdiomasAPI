using AutoMapper;
using Escola.Domain.DTOs.Aluno;
using Escola.Domain.DTOs.AlunoTurma;
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
        private readonly IMapper _mapper;

        public AlunoTurmaApplication(IAlunoTurmaRepository alunoTurmaRepository, IMapper mapper)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
            _mapper = mapper;
        }

        public async Task<InsertAlunoTurmaDto> InsertAlunoTurma(InsertAlunoTurmaDto alunoTurmaDto)
        {
            var alunoTurma = _mapper.Map<AlunoTurma>(alunoTurmaDto);
            await _alunoTurmaRepository.InsertAlunoTurma(alunoTurma);
            return alunoTurmaDto;
        }
    }
}
