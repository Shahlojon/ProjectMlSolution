using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces
{
    public interface IGroupRepository
    {
        public Task<IEnumerable<Group>> GetAll();
        public Task<IEnumerable<Group>> GetAllWithRelation();
        public Task<Group> Add(Group group);
        public Task<Group> AddNew(Group group);
        public Task<Group> Update(Group group);
        public Task<Group> GetById(int? Id);
        public Task<Group> DeleteById(int? Id);
    }
}
