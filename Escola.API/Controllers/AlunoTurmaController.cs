using Escola.Application;
using Escola.Domain.DTOs.AlunoTurma;
using Escola.Domain.DTOs.Turma;
using Escola.Domain.Interfaces.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurmaApplication _alunoTurmaApplication;
        public AlunoTurmaController(IAlunoTurmaApplication alunoTurmaApplication)
        {
            _alunoTurmaApplication = alunoTurmaApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlunosTurmas()
        {
            var turmas = await _alunoTurmaApplication.GetAlunosTurmas();
            return Ok(turmas);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAlunoTurma([FromBody] InsertAlunoTurmaDto alunoTurma)
        {
            try
            {
                var result = await _alunoTurmaApplication.InsertAlunoTurma(alunoTurma);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlunoTurma(int id)
        {
            try
            {
                await _alunoTurmaApplication.DeleteAlunoTurma(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
