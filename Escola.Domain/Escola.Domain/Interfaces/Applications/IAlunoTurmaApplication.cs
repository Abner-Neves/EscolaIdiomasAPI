using AutoMapper;
using Escola.Domain.DTOs.AlunoTurma;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Applications
{
    public interface IAlunoTurmaApplication
    {
        public Task<InsertAlunoTurmaDto> InsertAlunoTurma(InsertAlunoTurmaDto alunoTurmaDto);
        
    }
}
