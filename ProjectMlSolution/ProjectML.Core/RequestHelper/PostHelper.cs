using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.RequestHelper
{
    public static class PostHelper
    {
        public static async Task<T> PostOne<T>(string endPoint, string data)
        {

            HttpClient client = new();

            try
            {
                var responseMessage = await client.PostAsync(
                          endPoint,
                          new StringContent(data, Encoding.UTF8, "application/json"));

                string response = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }
    }
}
