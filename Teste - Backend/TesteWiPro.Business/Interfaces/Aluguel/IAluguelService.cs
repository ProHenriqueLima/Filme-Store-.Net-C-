using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Business.Interfaces
{
    public interface IAluguelService
    {
        bool ClienteExistente(long id);
        bool FilmeExistente(long id);
        bool FilmeDisponivel(long id);
        void AlugarFilme(Aluguel aluguel);
        int DevolverLivro(long id);
    }
}
