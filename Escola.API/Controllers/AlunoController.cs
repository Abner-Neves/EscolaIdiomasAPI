using Escola.Domain.Interfaces.Applications;
using Escola.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplication _alunoApplication;
        public AlunoController(IAlunoApplication alunoApplication)
        {
            _alunoApplication = alunoApplication;
        }

        [HttpGet("GetAlunos")]
        public async Task<IActionResult> GetAlunos()
        {
            var alunos = await _alunoApplication.GetAlunos();
            return Ok(alunos);
        }
    }
}
