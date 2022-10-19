using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Business.Interfaces
{
    public interface IAluguelRepository
    {
        Task<IEnumerable<Aluguel>> GetAll();
        void Add(Aluguel aluguel);
        void Update(Aluguel aluguel);
        Aluguel GetById(long id);
    }
}
