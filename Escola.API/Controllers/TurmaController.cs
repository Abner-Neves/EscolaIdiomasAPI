using AutoMapper;
using Escola.Domain.DTOs.Turma;
using Escola.Domain.Interfaces.Applications;
using Escola.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaApplication _turmaApplication;
        public TurmaController(ITurmaApplication turmaApplication)
        {
            _turmaApplication = turmaApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetTurmas()
        {
            var turmas = await _turmaApplication.GetTurmas();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTurmaById(int id)
        {
            try
            {
                var turma = await _turmaApplication.GetTurmaById(id);
                return Ok(turma);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertTurma([FromBody]InsertTurmaDto turma)
        {
            try
            {
                var result = await _turmaApplication.InsertTurma(turma);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTurma(int id, [FromBody] UpdateTurmaDto turma)
        {
            try
            {
                var result = await _turmaApplication.UpdateTurma(id, turma);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            try
            {
                await _turmaApplication.DeleteTurma(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}