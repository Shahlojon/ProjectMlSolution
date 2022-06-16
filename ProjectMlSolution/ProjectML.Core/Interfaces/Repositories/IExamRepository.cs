using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces
{
    public interface IExamRepository
    {
        public Task<IEnumerable<Exam>> GetAll();
        public Task<Exam> Add(Exam exam);
        public Task<Exam> Update(Exam exam);
        public Task<Exam> GetById(int? Id);
        public Task<Exam> DeleteById(int? Id);
    }
}
