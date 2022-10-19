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
    public class FilmeRepository : IFilmeRepository
    {
        protected readonly TesteWiProDbContext Db;
        protected readonly DbSet<Filme> DbSet;
        public FilmeRepository(TesteWiProDbContext db)
        {
            Db = db;
            DbSet = db.Set<Filme>();
        }

        //Add e Update

        public async void AddFilme(Filme filme)
        {
            await DbSet.AddAsync(filme);
            Db.SaveChanges();
        }
        public void UpdateFilme(Filme filme)
        {
            DbSet.Update(filme);
            Db.SaveChanges();
        }

        //Get's 
        public async Task<IEnumerable<Filme>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public Filme GetById(long id)
        {
            var query = DbSet.AsNoTracking().Where(c => c.Id == id);
            return query.FirstOrDefault();
            
        }

        public Filme GetByName(string name)
        {
            var query = DbSet.AsNoTracking().Where(c => c.Nome == name);
            return query.FirstOrDefault();
        }

        public async Task<IEnumerable<Filme>> GetFilmesAtivos()
        {
            return await DbSet.Where(c => c.Ativo == true).ToListAsync();
        }
        public async Task<IEnumerable<Filme>> GetFilmesDesativos()
        {
            return await DbSet.Where(c => c.Ativo == false).ToListAsync();
        }
        
        public void AtivarOuDesativarFilme(long id)
        {
            var item = GetById(id);
            item.Ativo = !item.Ativo;
            DbSet.Update(item);
            Db.SaveChanges();
        }
    }
}
