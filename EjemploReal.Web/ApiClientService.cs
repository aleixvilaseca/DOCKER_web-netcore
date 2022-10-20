using EjemploReal.Api.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EjemploReal.Web
{
    public class ApiClientService 
    {
        private readonly string _urlBase;
        public ApiClientService(string urlBase)
        {
            _urlBase = urlBase.Trim();
            if (!_urlBase.EndsWith("/"))
            {
                _urlBase = _urlBase + "/";
            }
        }

        public async Task<IEnumerable<Message>> GetMessages()
        {
            var url = $"{_urlBase}messages";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<IEnumerable<Message>>(json);
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> CreateMessage(Message message)
        {
            var url = $"{_urlBase}messages";
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(message);
                var response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
        }
    }
}