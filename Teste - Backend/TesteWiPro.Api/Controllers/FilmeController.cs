using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteWiPro.Api.ViewModels.Filme;
using TesteWiPro.Business.Dto;
using TesteWiPro.Business.Interfaces;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly IFilmeRepository _repository;
    private readonly IFilmeService _service;
    private readonly IMapper _mapper;
    public FilmeController(IFilmeRepository filmeRepository,IMapper mapper, IFilmeService filmeService)
    {
        _repository = filmeRepository;    
        _mapper = mapper;
        _service = filmeService;
    }

    /// <summary>
    /// Método utilizado para consultar todos os Filmes (Ativos e Desativos)
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "BuscarFilmes")]
    public Task<IEnumerable<Filme>> GetAll()
    {
        return _repository.GetAll();
    }

    /// <summary>
    /// Método utilizado para consultar os Filmes Ativos
    /// </summary>
    /// <returns></returns>
    [HttpGet("FilmesAtivos", Name = "Buscar Filmes Ativos")]
    public Task<IEnumerable<Filme>> GetFilmesAtivos()
    {
        return _repository.GetFilmesAtivos();
    }

    /// <summary>
    /// Método utilizado para consultar os Filmes Desativos
    /// </summary>
    /// <returns></returns>
    [HttpGet("FilmesDesativos", Name = "Buscar Filmes Desativos")]
    public Task<IEnumerable<Filme>> GetFilmesDesativos()
    {
        return _repository.GetFilmesDesativos();
    }

    /// <summary>
    /// Método utilizado para Adicionar um Filme
    /// </summary>
    /// <returns></returns>
    [HttpPost("AdicionarFilmes")]
    public IActionResult AddFilmes(RequestFilmeVM filmeVM)
    {
        var filme = _mapper.Map<Filme>(filmeVM);
        if (_service.NomeExistente(filme))
        {
            var result = _service.AddFilme(filme);
            return Ok(result);
        }
        else
        {
            return BadRequest("Filme Existente");
        }
    }
    
    /// <summary>
    /// Método utilizado para Desativar ou Ativar um Filme
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}",Name = "Mudar Situação Filmes")]
    public IActionResult ModifiedStatusFilme(long id)
    {
        if(_repository.GetById(id) == null)
        {
            return BadRequest("Filme não existente");
        }
        else
        {
            _repository.AtivarOuDesativarFilme(id);
            var item = _repository.GetById(id);
            var txt = "";
            if (item.Ativo == false)
            {
                txt = "Desativado";
            }
            else
            {
                txt = "Ativado";
            }
            return Ok("Status atualizado para : "+txt);
        }
    }

}
