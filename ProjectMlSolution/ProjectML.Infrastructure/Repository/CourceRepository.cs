using Microsoft.EntityFrameworkCore;
using ProjectML.Core.Interfaces;
using ProjectML.Core.Models;
using ProjectML.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Infrastructure.Repository
{
    public class CourceRepository : ICourceRepository
    {
        readonly ApplicationContext db;

        public CourceRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public async Task<Cource> Add(Cource cource)
        {
            await db.Cources.AddAsync(cource);
            await db.SaveChangesAsync();
            return cource;
        }

        public async Task<Cource> DeleteById(int? Id)
        {
            Cource cource = await GetById(Id);
            db.Cources.Remove(cource);
            await db.SaveChangesAsync();
            return cource;
        }

        public async Task<IEnumerable<Cource>> GetAll()
        {
            return await db.Cources.ToListAsync();
        }

        public async Task<Cource> GetById(int? Id)
        {
            return await db.Cources.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Cource> Update(Cource cource)
        {
            db.Cources.Update(cource);
            await db.SaveChangesAsync();
            return cource;
        }
    }
}
