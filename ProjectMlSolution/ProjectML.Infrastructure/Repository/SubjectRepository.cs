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
    public class SubjectRepository : ISubjectRepository
    {
        readonly ApplicationContext db;

        public SubjectRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public async Task<Subject> Add(Subject subject)
        {
            await db.Subjects.AddAsync(subject);
            await db.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> DeleteById(int? Id)
        {
            Subject subject = await GetById(Id);
            db.Subjects.Remove(subject);
            await db.SaveChangesAsync();
            return subject;
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await db.Subjects.ToListAsync();
        }

        public async Task<Subject> GetById(int? Id)
        {
            return await db.Subjects.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Subject> Update(Subject subject)
        {
            db.Subjects.Update(subject);
            await db.SaveChangesAsync();
            return subject;
        }
    }
}
