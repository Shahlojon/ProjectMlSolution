using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectML.Core.Models
{
    // сохраняет те данные который студент написал при сдаче экзамена
    public class Topic
    {
        public int Id { get; set; }
        public string Description { get; set; } // эссе который написал
        public DateTime TimeStamp { get; set; } //время когда закончил
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        //public int AlgorithmId { get; set; }
        public virtual Exam Exam { get; set; } // связь с экзаменам когда сдавал экзамен какой предмет был 
        public virtual User Student { get; set; } // какой студент написал
        public virtual Lesson Lesson { get; set; }// полученная тема
    }
}
