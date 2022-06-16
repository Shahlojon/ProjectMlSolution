using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces
{
    public interface IContentEssayRepository
    {
        public Task<IEnumerable<ContentEssay>> GetAll();
        public Task<ContentEssay> Add(ContentEssay content);
        public Task<ContentEssay> Update(ContentEssay content);
        public Task<ContentEssay> GetById(int? Id);
        public Task<ContentEssay> DeleteById(int? Id);
    }
}
