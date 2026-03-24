using EventPlus_.WebAPI.DTO;
using EventPlus_.WebAPI.Interfaces;
using EventPlus_.WebAPI.Models;
using EventPlus_.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private IInstituicaoRepository _instituicaoRepository;

    public InstituicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }



    /// <summary>
    /// Endpoint da API que faz chamada para o metódo de listar as instituições
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos de instituições</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_instituicaoRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para um metódo de buscar um tipo de Instituição específico
    /// </summary>
    /// <param name="id">Id do tipo Instituição buscada</param>
    /// <returns>Status code 200 e tipo de Instituição buscada</returns>
    [HttpGet("{id}")]

    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);

        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para o metódo de cadastrar um tipo de Instituição
    /// </summary>
    /// <param name="instituicao">Tipo de Instituição a ser cadastrado</param>
    /// <returns>Status code 201 e o tipo de Instituição cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(InstituicaoDTO instituicao)
    {
        try
        {
            var novoInstituicao = new Instituicao
            {
                Endereco = instituicao.Endereco!,
                Cnpj = instituicao.Cnpj!,
                NomeFantasia = instituicao.NomeFantasia!
            };

            _instituicaoRepository.Cadastrar(novoInstituicao);


            return StatusCode(201, novoInstituicao);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o metódo de atualizar um tipo de Instituição
    /// </summary>
    /// <param name="id">Id que da instituição com Dados atualizados </param>
    /// <param name="instituicaoDTO"></param>
    /// <returns>Status Code 204 e  instituição atualizada</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, InstituicaoDTO instituicaoDTO)
    {
        try
        {
            var instituicaoAtualizado = new Instituicao
            {
                Endereco = instituicaoDTO.Endereco!,
                Cnpj = instituicaoDTO.Cnpj!,
                NomeFantasia = instituicaoDTO.NomeFantasia
            };
            _instituicaoRepository.Atualizar(id, instituicaoAtualizado);
            return StatusCode(204, instituicaoDTO);

        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }

    }




    /// <summary>
    /// Endpoint da API que faz a chamada para o metódo de deletar um tipo de Instituição
    /// </summary>
    /// <param name="id">Id do tipo Instituição deletada</param>
    /// <returns>Status Code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _instituicaoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


}
