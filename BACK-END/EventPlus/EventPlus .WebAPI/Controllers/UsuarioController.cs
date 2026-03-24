using EventPlus_.WebAPI.DTO;
using EventPlus_.WebAPI.Interfaces;
using EventPlus_.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para método de Buscar um usuário por id 
    /// </summary>
    /// <param name="id">Id do usuário a ser buscado </param>
    /// <returns>Status Code (200) e o usuário buscado </returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        var usuario = _usuarioRepository.BuscarPorId(id);
        try
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para método de Cadastrar um nusuário
    /// </summary>
    /// <param name="usuario">usuario a ser cadastrado</param>
    /// <returns>Status Code 201 e o usuário cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(UsuarioDTO usuario)
    {
        try
        {
            var novoUsuario = new Usuario
            {
                Nome = usuario.Nome!,
                Email = usuario.Email!,
                Senha = usuario.Senha!,
                IdTipoUsuario = usuario.IdTipoUsuario
            };

            _usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201, novoUsuario);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }



}
