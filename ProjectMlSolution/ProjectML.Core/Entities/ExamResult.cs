using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectML.Core.Models
{
    // хранится результат экзаменов
    public class ExamResult 
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public int TopicId { get; set; }
        public virtual Topic  Topic { get; set; }
    }
}
