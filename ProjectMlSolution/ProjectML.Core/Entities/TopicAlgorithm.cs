using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectML.Core.Models
{
    // будет сохранен результат каждого алгоритма который дал результат оценку смотря по проценту процент на сколько процентов соответствует
    // теме названия алгоритма и данные студента который сдал экзамен 
    public class TopicAlgorithm
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public int Percent { get; set; }
        public string NewTheme { get; set; }
        public int AlgorithmId { get; set; }
        public int TopicId { get; set; }

        public virtual Algorithm Algorithm { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
