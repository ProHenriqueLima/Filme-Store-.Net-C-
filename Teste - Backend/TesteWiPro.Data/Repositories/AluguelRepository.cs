using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteWiPro.Business.Interfaces;
using TesteWiPro.Business.Models;
using TesteWiPro.Data.Context;

namespace TesteWiPro.Data.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        protected readonly TesteWiProDbContext Db;
        protected readonly DbSet<Aluguel> DbSet;
        public AluguelRepository(TesteWiProDbContext db)
        {
            Db = db;
            DbSet = db.Set<Aluguel>();
        }

        public void Add(Aluguel aluguel)
        {
            DbSet.Add(aluguel);
            Db.SaveChanges();
        }
        public void Update(Aluguel aluguel)
        {
            DbSet.Update(aluguel);
            Db.SaveChanges();
        }

        public async Task<IEnumerable<Aluguel>> GetAll()
        {
            return await DbSet.Include(c => c.Cliente).Include(c => c.Filme).ToListAsync();
        }
        
        public Aluguel GetById(long id)
        {
            var query = DbSet.AsNoTracking().Where(c => c.Id == id);
            return query.FirstOrDefault();
        }
    }
}
