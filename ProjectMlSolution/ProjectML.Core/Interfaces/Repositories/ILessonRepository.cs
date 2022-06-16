using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces
{
    public interface ILessonRepository
    {
        public Task<IEnumerable<Lesson>> GetAll();
        public Task<Lesson> Add(Lesson lesson);
        public Task<Lesson> Update(Lesson lesson);
        public Task<Lesson> GetById(int? Id);
        public Task<Lesson> DeleteById(int? Id);
    }
}
