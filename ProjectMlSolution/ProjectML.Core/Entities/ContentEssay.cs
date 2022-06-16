using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectML.Core.Models
{
    // это таблица для админа в ней он для обучения данных на алгоритмов добавляют данные эссе и его премета( как бы категорию)
    public class ContentEssay
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Predmet Predmet { get; set; }
    }
}
