using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteWiPro.Api.ViewModels.Cliente;
using TesteWiPro.Business.Dto;
using TesteWiPro.Business.Interfaces;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _repository;
    private readonly IClienteService _service;
    private readonly IMapper _mapper;
    public ClienteController(IClienteRepository clienteRepository,IMapper mapper, IClienteService clienteService)
    {
        _repository = clienteRepository;    
        _mapper = mapper;
        _service = clienteService;
    }

    /// <summary>
    /// Método utilizado para consultar todos os Clientes (Ativos e Desativos)
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "BuscarClientes")]
    public Task<IEnumerable<Cliente>> GetAll()
    {
        return _repository.GetAll();
    }

    /// <summary>
    /// Método utilizado para consultar os Clientes Ativos
    /// </summary>
    /// <returns></returns>
    [HttpGet("ClientesAtivos", Name = "Buscar Clientes Ativos")]
    public Task<IEnumerable<Cliente>> GetClientesAtivos()
    {
        return _repository.GetClientesAtivos();
    }

    /// <summary>
    /// Método utilizado para consultar os Clientes Desativos
    /// </summary>
    /// <returns></returns>
    [HttpGet("ClientesDesativos", Name = "Buscar Clientes Desativos")]
    public Task<IEnumerable<Cliente>> GetClientesDesativos()
    {
        return _repository.GetClientesDesativos();
    }

    /// <summary>
    /// Método utilizado para Adicionar um Cliente
    /// </summary>
    /// <returns></returns>
    [HttpPost("AdicionarClientes")]
    public IActionResult AddClientes(RequestClienteVM clienteVM)
    {
        var cliente = _mapper.Map<Cliente>(clienteVM);
        if (_service.NomeExistente(cliente))
        {
            var result = _service.AddCliente(cliente);
            return Ok(result);
        }
        else
        {
            return BadRequest("Cliente Existente");
        }
    }
    
    /// <summary>
    /// Método utilizado para Desativar ou Ativar um Cliente
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}",Name = "Mudar Situação Clientes")]
    public IActionResult ModifiedStatusCliente(long id)
    {
        if(_repository.GetById(id) == null)
        {
            return BadRequest("Cliente não existente");
        }
        else
        {
            _repository.AtivarOuDesativarCliente(id);
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
