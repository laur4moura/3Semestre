using ConnectPLus.DTO;
using ConnectPLus.Interface;
using ConnectPLus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ConnectPLus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }


        /// <summary>
        /// EndPoint da API que faz chamada para o metódo de lista o contato
        /// </summary>
        /// <returns>Status Code 200 e a lista de contatos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_contatoRepository.Listar());
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
                return Ok(_contatoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint da API que cadastra um novo contato
        /// </summary>
        /// <param name="contato">Dados do novo contato cadastrado</param>
        /// <returns>Status code 200 e os dados do contato cadastrado</returns> 
        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromForm] ContatoDTO contato)
        {
            if (String.IsNullOrEmpty(contato.Nome) || String.IsNullOrEmpty(contato.FormaContato))
            {
                return BadRequest("O nome e a forma de contato são obrigatórios");
            }
            Contato novoContato = new Contato();
            if (contato.Imagem != null && contato.Imagem.Length > 0)
            {
                var extensao = Path.GetExtension(contato.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                if (!Directory.Exists(caminhoPasta))
                {
                    Directory.CreateDirectory(caminhoPasta);
                }

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);
                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await contato.Imagem.CopyToAsync(stream);
                }

                novoContato.Imagem = nomeArquivo;
            }
            novoContato.Nome = contato.Nome;
            novoContato.FormaContato = contato.FormaContato;
            novoContato.IdTipoContato = contato.IdTipoContato;
            try
            {
                _contatoRepository.Cadastrar(novoContato);
                return Ok(novoContato);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint da API para atualizar os dados de um contato com base no seu id
        /// </summary>
        /// <param name="id">Id do contato a ser atualizado</param> 
        /// <param name="contato">Dados do contato atualizado</param>
        /// <returns>Status Code 200 e os dados do contato atualizado</returns> 
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromForm] ContatoDTO contato)
        {
            var contatoBuscado = _contatoRepository.BuscarPorId(id);

            // Atualiza os campos
            if (!string.IsNullOrWhiteSpace(contato.Nome))
                contatoBuscado.Nome = contato.Nome;

            if (!string.IsNullOrWhiteSpace(contato.FormaContato))
                contatoBuscado.FormaContato = contato.FormaContato;

            if (contato.IdTipoContato != Guid.Empty)
                contatoBuscado.IdTipoContato = contato.IdTipoContato;
            
           
            if (contatoBuscado == null)
            {
                return NotFound("Contato não encontrado");
            }
            if (contato.Imagem != null && contato.Imagem.Length > 0)
            {
                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);
                if (!String.IsNullOrEmpty(contatoBuscado.Imagem))
                {
                    var caminhoAntigo = Path.Combine(caminhoPasta, contatoBuscado.Imagem);
                    if (System.IO.File.Exists(caminhoAntigo))
                    {
                        System.IO.File.Delete(caminhoAntigo);
                    }
                }

                var extensao = Path.GetExtension(contato.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                if (!Directory.Exists(caminhoPasta))
                {
                    Directory.CreateDirectory(caminhoPasta);
                }
                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);
                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await contato.Imagem.CopyToAsync(stream);
                }
                contatoBuscado.Imagem = nomeArquivo;
            }
            try
            {
                _contatoRepository.Atualizar(id, contatoBuscado);
                return Ok(contatoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint da API para deletar um contato do banco de dadoscom base no seu id
        /// </summary>
        /// <param name="id">Id do contato a ser deletado</param>
        /// <returns>Status code 204</returns> 
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            var contatoBuscado = _contatoRepository.BuscarPorId(id);
            if (contatoBuscado == null)
            {
                return NotFound("Contato não encontrado");
            }
            var PastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), PastaRelativa);

            if (!string.IsNullOrEmpty(contatoBuscado.Imagem))
            {
                var caminho = Path.Combine(caminhoPasta, contatoBuscado.Imagem);
                if (System.IO.File.Exists(caminho))
                {
                    System.IO.File.Delete(caminho);
                }
            }
            try
            {
                _contatoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}