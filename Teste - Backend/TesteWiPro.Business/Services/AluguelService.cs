using TesteWiPro.Business.Interfaces;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Business.Services
{
    public class AluguelService : IAluguelService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IAluguelRepository _aluguelRepository;

        public AluguelService(IFilmeRepository filmeRepository, IClienteRepository clienteRepository, IAluguelRepository aluguelRepository)
        {
            _filmeRepository = filmeRepository;
            _clienteRepository = clienteRepository;
            _aluguelRepository = aluguelRepository;
        }
        public void AlugarFilme(Aluguel aluguel)
        {
            var filme = _filmeRepository.GetById(aluguel.FilmeId);
            filme.Alugado = true;
            _filmeRepository.UpdateFilme(filme);
            _aluguelRepository.Add(aluguel);
        }

        public bool ClienteExistente(long id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool FilmeDisponivel(long id)
        {
            var filme = _filmeRepository.GetById(id);
            if (filme.Alugado == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool FilmeExistente(long id)
        {
            var filme = _filmeRepository.GetById(id);
            if (filme == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int DevolverLivro(long id)
        {
            var item = _aluguelRepository.GetById(id);
            if (item.DataDaDevolucao == null)
            {
                item.DataDaDevolucao = DateTime.Now;
                var filme = _filmeRepository.GetById(item.FilmeId);
                filme.Alugado = false;
                _aluguelRepository.Update(item);
                _filmeRepository.UpdateFilme(filme);
                if (item.DataDaDevolucao > item.DataDePrevisao)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}
