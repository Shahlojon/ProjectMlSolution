using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces
{
    /// <summary>
    /// Interfaces
    ///     Repositories
    ///     Services
  
    /// </summary>
    public interface IAlgorithmRepository
    {
        public Task<IEnumerable<Algorithm>> GetAll();
        public Task<Algorithm> Add(Algorithm algorithm);
        public Task<Algorithm> Update(Algorithm algorithm);
        public Task<Algorithm> GetById(int? Id);
        public Task<Algorithm> DeleteById(int? Id);
    }
}
