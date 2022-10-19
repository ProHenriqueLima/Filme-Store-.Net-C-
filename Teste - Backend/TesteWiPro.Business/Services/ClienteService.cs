using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteWiPro.Business.Dto;
using TesteWiPro.Business.Interfaces;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Business.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository clienteRepository,IMapper mapper)
        {
            _repository = clienteRepository;
            _mapper = mapper;
        }
        public ResponseClienteDto AddCliente(Cliente cliente)
        {
            _repository.AddCliente(cliente);
            return _mapper.Map<ResponseClienteDto>(cliente);

        }

        public bool NomeExistente(Cliente cliente)
        {
            var value = _repository.GetByName(cliente.Nome);
            if(value == null) { return true; }
            else { return false; }

        }

        
    }
}
