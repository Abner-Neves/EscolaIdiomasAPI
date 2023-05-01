using Escola.Domain.DTOs.Turma;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Applications
{
    public interface ITurmaApplication
    {
        public Task<IEnumerable<GetTurmaDto>> GetTurmas();
        public Task<GetTurmaDto> GetTurmaById(int id);
        public Task<GetTurmaDto> InsertTurma(InsertTurmaDto turma);
        public Task<GetTurmaDto> UpdateTurma(int id, UpdateTurmaDto turma);
        public Task DeleteTurma(int id);
    }
}
