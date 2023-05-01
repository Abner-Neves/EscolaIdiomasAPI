using AutoMapper;
using Escola.Application;
using Escola.Domain.DTOs.Aluno;
using Escola.Domain.DTOs.Turma;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, [FromBody] UpdateAlunoDto aluno)
        {
            try
            {
                var result = await _alunoApplication.UpdateAluno(id, aluno);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            try
            {
                await _alunoApplication.DeleteAluno(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
