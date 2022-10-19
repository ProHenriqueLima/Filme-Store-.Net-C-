using Microsoft.EntityFrameworkCore;
using TesteWiPro.Business.Interfaces;
using TesteWiPro.Business.Models;
using TesteWiPro.Data.Context;

namespace TesteWiPro.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        protected readonly TesteWiProDbContext Db;
        protected readonly DbSet<Cliente> DbSet;
        public ClienteRepository(TesteWiProDbContext db)
        {
            Db = db;
            DbSet = db.Set<Cliente>();
        }

        //Add e Update

        public async void AddCliente(Cliente cliente)
        {
            cliente.Ativo = true;
            await DbSet.AddAsync(cliente);
            Db.SaveChanges();
        }
        public void UpdateCliente(Cliente cliente)
        {
            DbSet.Update(cliente);
            Db.SaveChanges();
        }

        //Get's 
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public Cliente GetById(long id)
        {
            var query = DbSet.AsNoTracking().Where(c => c.Id == id);
            return query.FirstOrDefault();

        }

        public Cliente GetByName(string name)
        {
            var query = DbSet.AsNoTracking().Where(c => c.Nome == name);
            return query.FirstOrDefault();
        }

        public async Task<IEnumerable<Cliente>> GetClientesAtivos()
        {
            return await DbSet.Where(c => c.Ativo == true).ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> GetClientesDesativos()
        {
            return await DbSet.Where(c => c.Ativo == false).ToListAsync();
        }

        public void AtivarOuDesativarCliente(long id)
        {
            var item = GetById(id);
            item.Ativo = !item.Ativo;
            DbSet.Update(item);
            Db.SaveChanges();
        }
    }
}
