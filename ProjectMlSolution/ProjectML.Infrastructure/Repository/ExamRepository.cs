using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class ExamRepository : IExamRepository
    {
        readonly ApplicationContext db;

        public ExamRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public async Task<Exam> Add(Exam exam)
        {
            await db.Exams.AddAsync(exam);
            await db.SaveChangesAsync();
            return exam;
        }

        public async Task<Exam> DeleteById(int? Id)
        {
            Exam exam = await GetById(Id);
            db.Exams.Remove(exam);
            await db.SaveChangesAsync();
            return exam;
        }

        public async Task<IEnumerable<Exam>> GetAll()
        {
            var exam = await db.Exams.ToListAsync();
            foreach (var g in exam)
            {
                if (g != null)
                {
                    db.Entry(g).Reference(s => s.Group).Load();
                    if (g.Group != null)
                    {
                        db.Entry(g.Group).Reference(s => s.Cource).Load();
                        db.Entry(g.Group).Reference(s => s.Profession).Load();
                    }
                    db.Entry(g).Reference(s => s.Subject).Load();
                }
            }
            return exam;
        }

        public async Task<Exam> GetById(int? Id)
        {
            return await db.Exams.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Exam> Update(Exam exam)
        {
            db.Exams.Update(exam);
            await db.SaveChangesAsync();
            return exam;
        }
    }
}
