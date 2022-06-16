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
    public class ProffessionRepository : IProfessionRepository
    {
        readonly ApplicationContext db;

        public ProffessionRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public async Task<Profession> Add(Profession profession)
        {
            await db.Professions.AddAsync(profession);
            await db.SaveChangesAsync();
            return profession;
        }

        public async Task<Profession> DeleteById(int? Id)
        {
            Profession profession = await GetById(Id);
            db.Professions.Remove(profession);
            await db.SaveChangesAsync();
            return profession;
        }

        public async Task<IEnumerable<Profession>> GetAll()
        {
            return await db.Professions.ToListAsync();
        }

        public async Task<Profession> GetById(int? Id)
        {
            return await db.Professions.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Profession> Update(Profession profession)
        {
            db.Professions.Update(profession);
            await db.SaveChangesAsync();
            return profession;
        }
    }
}
