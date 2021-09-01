using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ApiCadastroJogos.Exceptions;
using ApiCadastroJogos.InputModel;
using ApiCadastroJogos.Services;
using ApiCadastroJogos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastroJogos.Controllers.V1
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter(
            [FromQuery, Range(1, int.MaxValue)] 
            int pagina = 1, [FromQuery, Range(1, 50)] 
            int quantidade = 5
        )
        {
            var result = await _jogoService.Obter(1, 5);
            return Ok(result);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<List<JogoViewModel>>> Obter(Guid idJogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastradoException ex)
            {
                return UnprocessableEntity("Já Existe um jogo com este nome para esta produtora");
            }
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModel);

                return Ok();

            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Já Existe um jogo com este nome para esta produtora");
            }
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);

                return Ok();

            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não Existe este Jogo");
            }
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);

                return Ok();

            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não Existe este Jogo");
            }
        }

    }  
}