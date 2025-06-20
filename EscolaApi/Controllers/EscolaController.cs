using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EscolaApi.Data;
using EscolaApi.Models;

namespace EscolaApi.Controllers
{
    [ApiController]
    [Route("[controller]")] // Corrigido: usando Route do namespace correto
    public class EscolaController : ControllerBase
    {
        private readonly DataContext _context;

        public EscolaController(DataContext context)
        {
            _context = context;
        }

        // Método para verificar se a escola já existe
        private async Task<bool> EscolaExistente(string codEscola)
        {
            return await _context.TB_ESCOLA.AnyAsync(x => x.CodEscola.ToLower() == codEscola.ToLower());
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarEscolaNova([FromBody] Escola escola)
        {
            try
            {
                if (await EscolaExistente(escola.CodEscola))
                    throw new Exception("Código da escola já existe.");

                await _context.TB_ESCOLA.AddAsync(escola);
                await _context.SaveChangesAsync();

                return Ok(escola.CodEscola);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Escola> lista = await _context.TB_ESCOLA.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{codEscola}")]
        public async Task<IActionResult> MostrarEscola(string codEscola)
        {
            try
            {
                var escola = await _context.TB_ESCOLA.FindAsync(codEscola);
                if (escola == null)
                    return NotFound("Escola não encontrada.");

                return Ok(escola);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> AtualizarEscola([FromBody] Escola escola)
        {
            try
            {
                var escolaExistente = await _context.TB_ESCOLA.FindAsync(escola.CodEscola);
                if (escolaExistente == null)
                    return NotFound("Escola não encontrada.");

                _context.Entry(escolaExistente).CurrentValues.SetValues(escola);
                await _context.SaveChangesAsync();

                return Ok("Escola atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{codEscola}")]
        public async Task<IActionResult> DeletarEscola(string codEscola)
        {
            try
            {
                var escola = await _context.TB_ESCOLA.FindAsync(codEscola);
                if (escola == null)
                    return NotFound("Escola não encontrada.");

                _context.TB_ESCOLA.Remove(escola);
                await _context.SaveChangesAsync();

                return Ok("Escola deletada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
