using Newtonsoft.Json;
using ProjectML.Core.Filter;
using ProjectML.Core.Interfaces.Services;
using ProjectML.Core.Models;
using ProjectML.Core.RequestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMl.Core.Services
{
    public class Service: IService
    {
        public async Task<Items> GetPredict(Filters filter)
        {
            string url = "http://127.0.0.1:8000/analyze";

            var jsonSettings = new JsonSerializerSettings();

            string _data = JsonConvert.SerializeObject(filter, jsonSettings);
            return await PostHelper.PostOne<Items>(url, _data);
        }

        
    }
}
