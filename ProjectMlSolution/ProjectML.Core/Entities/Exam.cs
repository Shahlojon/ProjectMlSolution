using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectML.Core.Models
{
    //храняться данные предстоящих экзаменов
    public class Exam
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStamp { get; set; }

        public int  GroupId { get; set; }
        public int  SubjectId { get; set; }
        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
