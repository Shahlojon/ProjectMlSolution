using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces
{
    public interface IPredmetRepository
    {
        public Task<IEnumerable<Predmet>> GetAll(); 
        public Task<Predmet> Add(Predmet predmet); 
        public Task<Predmet> Update(Predmet predmet); 
        public Task<Predmet> GetById(int? Id); 
        public Task<Predmet> DeleteById(int? Id);
    }
}
