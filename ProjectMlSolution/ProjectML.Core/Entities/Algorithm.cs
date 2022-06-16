using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectML.Core.Models
{
    // хранится названия алгоритмов
    public class Algorithm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameTj { get; set; }
        public string Key { get; set; }
    }
}
