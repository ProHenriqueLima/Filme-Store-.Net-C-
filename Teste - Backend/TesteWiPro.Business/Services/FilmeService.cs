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
    public class FilmeService : IFilmeService
    {
        private readonly IMapper _mapper;
        private readonly IFilmeRepository _repository;
        public FilmeService(IFilmeRepository filmeRepository,IMapper mapper)
        {
            _repository = filmeRepository;
            _mapper = mapper;
        }
        public ResponseFilmeDto AddFilme(Filme filme)
        {
            _repository.AddFilme(filme);
            return _mapper.Map<ResponseFilmeDto>(filme);

        }

        public bool NomeExistente(Filme filme)
        {
            var value = _repository.GetByName(filme.Nome);
            if(value == null) { return true; }
            else { return false; }

        }

        
    }
}
