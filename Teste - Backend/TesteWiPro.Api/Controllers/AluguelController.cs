using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteWiPro.Api.ViewModels.Cliente;
using TesteWiPro.Business.Dto;
using TesteWiPro.Business.Interfaces;
using TesteWiPro.Business.Models;
using TesteWiPro.Data.Repositories;

namespace TesteWiPro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AluguelController : ControllerBase
{
    private readonly IAluguelRepository _repository;
    private readonly IAluguelService _service;
    private readonly IMapper _mapper;
    public AluguelController(IAluguelRepository aluguelRepository,IMapper mapper,IAluguelService aluguelService)
    {
        _service = aluguelService;
        _repository = aluguelRepository;    
        _mapper = mapper;
    }

    /// <summary>
    /// Método utilizado para consultar todos os Alugueis (Ativos e Desativos)
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "BuscarAlugueis")]
    public Task<IEnumerable<Aluguel>> GetAll()
    {
        return _repository.GetAll();
    }
    
    /// <summary>
    /// Método utilizado para fazer o aluguel de um Filme
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "AlugarFilme")]
    public IActionResult AddAluguel(RequestAluguelVM aluguelVM)
    {
        if (_service.FilmeExistente(aluguelVM.FilmeId) && _service.ClienteExistente(aluguelVM.ClienteId))
        {
            if (_service.FilmeDisponivel(aluguelVM.FilmeId))
            {
                var item = _mapper.Map<Aluguel>(aluguelVM);
                _service.AlugarFilme(item);
                return Ok(item);
            }
            else
            {
                return BadRequest("Filme Não disponível para aluguel");
            }

        }
        else
        {
            return BadRequest("Filme Ou Usuário não existente");
        }
    }
    
    /// <summary>
    /// Método utilizado para devolver um filme
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}",Name = "DevolverFilme")]
    public IActionResult DevolverFilme(long id)
    {
        var value = _repository.GetById(id);
        if (value != null)
        {
            var result = _service.DevolverLivro(id);
            if(result == 0)
            {
                return Ok("Devolvido no prazo correto");
            }
            if (result == 1)
            {
                return Ok("Esse aluguel já foi finalizado");
            }
            else {
                return Ok("Aluguel devolvido com atraso");
                    }
        }
        else
        {
            return NotFound("Aluguel não encontrado");
        }
    }

}
