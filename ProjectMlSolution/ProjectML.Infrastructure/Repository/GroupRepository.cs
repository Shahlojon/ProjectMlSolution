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
    public class GroupRepository : IGroupRepository
    {
        readonly ApplicationContext db;

        public GroupRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public async Task<Group> Add(Group group)
        {
            await db.Groups.AddAsync(group);
            await db.SaveChangesAsync();
            return group;
        }
        
        public async Task<Group> AddNew(Group group)
        {
            await db.Groups.AddAsync(group);
            await db.SaveChangesAsync();
            return group;
        }

        public async Task<Group> DeleteById(int? Id)
        {
            Group group = await GetById(Id);
            db.Groups.Remove(group);
            await db.SaveChangesAsync();
            return group;
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            var group = await db.Groups.ToListAsync();
            foreach (var g in group)
            {
                if (g != null)
                {
                    db.Entry(g).Reference(s => s.Profession).Load();
                    db.Entry(g).Reference(s => s.Cource).Load();
                }
            }
            return group;

        }

        public async Task<IEnumerable<Group>> GetAllWithRelation()
        {
            var group = await GetAll();
            foreach (var g in group)
            {
                db.Entry(g).Reference(s => s.Cource).Load();
                db.Entry(g).Reference(s => s.Profession).Load();
            }
            return group;
        }

        

        public async Task<Group> GetById(int? Id)
        {
            return await db.Groups.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Group> Update(Group group)
        {
            db.Groups.Update(group);
            await db.SaveChangesAsync();
            return group;
        }

        
    }
}
