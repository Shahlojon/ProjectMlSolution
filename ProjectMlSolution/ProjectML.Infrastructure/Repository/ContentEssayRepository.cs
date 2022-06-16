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
    public class ContentEssayRepository : IContentEssayRepository
    {
        readonly ApplicationContext db;

        public ContentEssayRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public async Task<ContentEssay> Add(ContentEssay content)
        {
            await db.ContentEssays.AddAsync(content);
            await db.SaveChangesAsync();
            return content;
        }

        public async Task<ContentEssay> DeleteById(int? Id)
        {
            ContentEssay essay = await GetById(Id);
            db.ContentEssays.Remove(essay);
            await db.SaveChangesAsync();
            return essay;
        }

        public async Task<IEnumerable<ContentEssay>> GetAll()
        {
            return await db.ContentEssays.ToListAsync();
        }

        public async Task<ContentEssay> GetById(int? Id)
        {
            return await db.ContentEssays.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<ContentEssay> Update(ContentEssay content)
        {
            db.ContentEssays.Update(content);
            await db.SaveChangesAsync();
            return content;
        }
    }
}
