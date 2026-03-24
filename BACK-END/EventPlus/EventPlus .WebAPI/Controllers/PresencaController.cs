using EventPlus_.WebAPI.DTO;
using EventPlus_.WebAPI.Interfaces;
using EventPlus_.WebAPI.Models;
using EventPlus_.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventPlus_.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private IPresencaRepository _presencaRepository;

    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }


    /// <summary>
    /// Endpoint da API que retorna a presença por id
    /// </summary>
    /// <param name="id">Id da presença a ser buscada</param>
    /// <returns>Status Code @00 e presença buscada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_presencaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que retorna a lista de presenças de um usuário específico, filtrando por id do usuário
    /// </summary>
    /// <param name="idUsuario">Id do usuário para filtragem</param>
    /// <returns>uma lista de presenças filtradas pelo usuário</returns>
    [HttpGet("ListarMinhas/{idUsuario}")]
    public IActionResult BuscarPorUsuario(Guid idUsuario)
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(idUsuario));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o metódo de listar a presença
    /// </summary>
    /// <returns>Status code 200 e a lista de presença /returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_presencaRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz chamada para o metódo de inscrever, permitindo a inscrição de um usuário em um evento, criando uma nova presença no banco de dados.
    /// </summary>
    /// <param name="presenca"></param>
    /// <returns>Status Code 201 e a presenca cadastrada</returns>
    [HttpPost]
    public IActionResult Inscrever(PresencaDTO presenca)
    {
        
        try
        {
            var novaPresenca = new Presenca
            {
                Situacao = presenca.Situcao,
                IdUsuario = presenca.IdUsuario,
                IdEvento = presenca.IdEvento
            };

            _presencaRepository.Inscrever(novaPresenca);
            return StatusCode(201, novaPresenca);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// Endpoint da API que atualiza uma presença existente
    /// </summary>
    /// <param name="id">Id das presenças atualizadas</param>
    /// <param name="presenca"></param>
    /// <returns>Status code 204 e a presença atualizada</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, Presenca presenca)
    {
        try
        {

            var presencaAtualizado = new Presenca
            {

                Situacao = presenca.Situacao,
                IdUsuario = presenca.IdUsuario,
                IdEvento = presenca.IdEvento
            };
            _presencaRepository.Atualizar(id, presencaAtualizado);
            return StatusCode(204, presenca);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// ENdpoint da API que deleta um tipo de presença, removendo uma presença específica do banco de dados com base no ID fornecido.
    /// </summary>
    /// <param name="id">Id da presença deletada</param>
    /// <returns>Status Code 204 </returns>
    [HttpDelete("{id}")]

     public IActionResult Delete(Guid id)
     {
         try
         {
             _presencaRepository.Deletar(id);
            return NoContent();
        }
         catch (Exception erro)
         {
             return BadRequest(erro.Message);
         }
    }
}
