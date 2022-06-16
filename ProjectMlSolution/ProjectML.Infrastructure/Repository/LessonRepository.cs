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
    public class LessonRepository : ILessonRepository
    {
        readonly ApplicationContext db;

        public LessonRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public async Task<Lesson> Add(Lesson lesson)
        {
            await db.Lessons.AddAsync(lesson);
            await db.SaveChangesAsync();
            return lesson;
        }

        public async Task<Lesson> DeleteById(int? Id)
        {
            Lesson lesson = await GetById(Id);
            db.Lessons.Remove(lesson);
            await db.SaveChangesAsync();
            return lesson;
        }

        public async Task<IEnumerable<Lesson>> GetAll()
        {
            return await db.Lessons.Include(s => s.Subject).ToListAsync();
        }

        public async Task<Lesson> GetById(int? Id)
        {
            return await db.Lessons.Include(s=>s.Subject).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Lesson> Update(Lesson lesson)
        {
            db.Lessons.Update(lesson);
            await db.SaveChangesAsync();
            return lesson;
        }
    }
}
