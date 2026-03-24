using EventPlus_.WebAPI.DTO;
using EventPlus_.WebAPI.Interfaces;
using EventPlus_.WebAPI.Models;
using EventPlus_.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private ITipoUsuarioRepository _tipoUsuarioRepository;

    public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
    {
        _tipoUsuarioRepository = tipoUsuarioRepository;
    }

    [HttpGet]
    public IActionResult Listar(Guid id)
    {
        try
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamad para um metódo de buscar um tipo de Usuário específico
    /// </summary>
    /// <param name="id">Id do tipo de usuário buscado</param>
    /// <returns>Status code 200 e tipo de usuário buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// Endpoint da API que faz a chamada para o metódo de cadastrar um tipo de Usuário
    /// </summary>
    /// <param name="tipoUsuario">Id do tipo Usuário a ser cadastrado</param>
    /// <returns>Status code 201 e o tipo de usuário cadastrado</returns>
    [HttpPost]

    public IActionResult Cadastrar(TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var novoTipoUsuario = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);


            return StatusCode(201, novoTipoUsuario);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para o metódo de atualizar um tipo de Usuário
    /// </summary>
    /// <param name="id">Id do tipo Usuário com dados atualizados</param>
    /// <param name="tipoUsuario"></param>
    /// <returns>Status code 204 e o tipo de evendo atualizado</returns>

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var tipoUsuarioAtualizado = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };
            _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
            return StatusCode(204, tipoUsuario);

        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }

    }


    /// <summary>
    ///  Endpoint da API que faz a chamada para o metódo de deletar um tipo de evento
    /// </summary>
    /// <param name="id">Is do tipo Usuario a ser excluído</param>
    /// <returns>Status Code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _tipoUsuarioRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


};

