using ConnectPLus.DTO;
using ConnectPLus.Interface;
using ConnectPLus.Models;
using ConnectPLus.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPLus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContatoController : ControllerBase
    {
        private readonly ITipoContatoRepository _tipoContatoRepository;

        public TipoContatoController(ITipoContatoRepository contatoRepository)
        {
            _tipoContatoRepository = contatoRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoContatoRepository.Listar());
        }

        /// <summary>
        /// EndPoint da API que faz chamada para o metódo de buscar um contato por id, passando o id do contato como parâmetro na URL
        /// </summary>
        /// <param name="id">Id do tipo contato</param>
        /// <returns>Status code 200 e tipo de instituição buscada</returns>
        [HttpGet("{id}")]

        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_tipoContatoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoind da API que faz chamada para o metódo de cadastrar um contato, passando os dados do contato no corpo da requisição
        /// </summary>
        /// <param name="contato">Tipo de contato a ser cadastrado</param>
        /// <returns>Status code 201 eo tipo de contato cadstrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoContatoDTO tipoContato)
        {
            try
            {
                var novoTipoContato = new TipoContato
                {
                    Titulo = tipoContato.Titulo
                  
                };

                _tipoContatoRepository.Cadastrar(novoTipoContato);

                return StatusCode(201, novoTipoContato);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint da API que faz chamada para o metódo de atualizar um contato, passando o id do contato a ser atualizado como parâmetro na URL e os dados atualizados do contato no corpo da requisição
        /// </summary>
        /// <param name="id">Id do contato a ser ser atualizado</param>
        /// <param name="contatoDTO"></param>
        /// <returns>Status Code 204 e contato atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, TipoContatoDTO TipoContatoDTO)
        {
            try
            {
                var TipoContatoAtualizado = new TipoContato
                {
                    Titulo = TipoContatoDTO.Titulo
                   
                };
                _tipoContatoRepository.Atualizar(id, TipoContatoAtualizado);
                return StatusCode(204, TipoContatoDTO);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }


        }


        /// <summary>
        /// Endpoint da API que faz chamada para o metódo de deletar um contato, passando o id do contato a ser deletado como parâmetro na URL
        /// </summary>
        /// <param name="id">Id do contato deletado</param>
        /// <returns>Statis Code 204</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoContatoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
