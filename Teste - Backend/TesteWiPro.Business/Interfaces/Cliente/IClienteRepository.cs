using TesteWiPro.Business.Models;

namespace TesteWiPro.Business.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();
        Cliente GetByName(string name);
        Cliente GetById(long id);
        Task<IEnumerable<Cliente>> GetClientesAtivos();
        Task<IEnumerable<Cliente>> GetClientesDesativos();
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void AtivarOuDesativarCliente(long id);
    }
}
