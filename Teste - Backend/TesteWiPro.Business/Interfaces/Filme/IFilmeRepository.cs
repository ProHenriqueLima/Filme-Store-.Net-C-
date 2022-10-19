using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Business.Interfaces
{
    public interface IFilmeRepository
    {
        Task<IEnumerable<Filme>> GetAll();
        Filme GetByName(string name);
        Filme GetById(long id);
        Task<IEnumerable<Filme>> GetFilmesAtivos();
        Task<IEnumerable<Filme>> GetFilmesDesativos();
        void AddFilme(Filme filme);
        void UpdateFilme(Filme filme);
        void AtivarOuDesativarFilme(long id);
    }
}
