using AutoMapper;
using Escola.Domain.DTOs;
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
        public AlunoController(IAlunoApplication alunoApplication, IMapper mapper)
        {
            _alunoApplication = alunoApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlunos()
        {
            var alunos = await _alunoApplication.GetAlunos();
            return Ok(alunos);
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetAlunoByCpf(string cpf)
        {
            try
            {
                var alunos = await _alunoApplication.GetAlunoByCpf(cpf);
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertAluno([FromBody] InsertAlunoDto aluno)
        {
            try
            {
                await _alunoApplication.InsertAluno(aluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
