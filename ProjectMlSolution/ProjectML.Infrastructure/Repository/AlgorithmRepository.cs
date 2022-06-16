using ProjectML.Core.Models;
using ProjectML.Core.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectML.Infrastructure.Context;

namespace ProjectML.Infrastructure.Repository
{
    public class AlgorithmRepository : IAlgorithmRepository
    {
        readonly ApplicationContext db;

        public AlgorithmRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public async Task<Algorithm> Add(Algorithm algorithm)
        {
            await db.Algorithms.AddAsync(algorithm);
            await db.SaveChangesAsync();
            return algorithm;
        }

        public async Task<Algorithm> DeleteById(int? Id)
        {
            Algorithm algorithm =await GetById(Id);
            db.Algorithms.Remove(algorithm);
            await db.SaveChangesAsync();
            return algorithm;
        }

        public async Task<IEnumerable<Algorithm>> GetAll()
        {
            return await db.Algorithms.ToListAsync();
        }

        public async Task<Algorithm> GetById(int? Id)
        {
            return await db.Algorithms.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Algorithm> Update(Algorithm algorithm)
        {
            db.Algorithms.Update(algorithm);
            await db.SaveChangesAsync();
            return algorithm;
        }
    }
}
