using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces
{
    public interface ICourceRepository
    {
        public Task<IEnumerable<Cource>> GetAll();
        public Task<Cource> Add(Cource cource);
        public Task<Cource> Update(Cource cource);
        public Task<Cource> GetById(int? Id);
        public Task<Cource> DeleteById(int? Id);
    }
}
