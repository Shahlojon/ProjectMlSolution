using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces
{
    public interface ISubjectRepository
    {
        public Task<IEnumerable<Subject>> GetAll(); 
        public Task<Subject> Add(Subject subject);
        public Task<Subject> Update(Subject subject); 
        public Task<Subject> GetById(int? Id); 
        public Task<Subject> DeleteById(int? Id);
    }
}
