using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces
{
    public interface IProfessionRepository
    {
        public Task<IEnumerable<Profession>> GetAll(); 
        public Task<Profession> Add(Profession profession); 
        public Task<Profession> Update(Profession profession); 
        public Task<Profession> GetById(int? Id);
        public Task<Profession> DeleteById(int? Id);
    }
}
