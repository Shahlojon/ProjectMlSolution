using ProjectML.Core.Filter;
using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces.Services
{
    public interface IService
    {
        public Task<Items> GetPredict(Filters filter);
    }
}
