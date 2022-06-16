using Microsoft.EntityFrameworkCore;
using ProjectML.Core.Enum;
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
    public class UserRepository : IUserRepository
    {
        readonly ApplicationContext db;

        public UserRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public async Task<User> Add(User user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteById(int? userId)
        {
            User user = await GetById(userId);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var user = await db.Users.ToListAsync();
            if (user != null)
            {
                foreach (var u in user)
                {
                    if (u.Role == Roles.Student)
                    {
                        db.Entry(u).Reference(s => s.Group).Load();
                        if (u.Group != null)
                        {
                            db.Entry(u.Group).Reference(s => s.Profession).Load();
                            db.Entry(u.Group).Reference(s => s.Cource).Load();
                        }

                    }
                }
            }
            return user;
        }

        public async Task<User> GetById(int? userId)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<User> Update(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return user;
        }
    }
}
