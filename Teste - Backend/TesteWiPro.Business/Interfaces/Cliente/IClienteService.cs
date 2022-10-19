using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteWiPro.Business.Dto;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Business.Interfaces
{
    public interface IClienteService
    {
        ResponseClienteDto AddCliente(Cliente cliente);
        bool NomeExistente(Cliente cliente);
    }
}
