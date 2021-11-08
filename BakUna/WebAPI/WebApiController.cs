using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BakUna.WebAPI
{
    class WebApiController
    {
        private static WebApiController _instance = null;
        private HttpClient client;

        public static WebApiController getInstance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new WebApiController();
                }
                return _instance;
            }
        }

        public void LoadWebApi(string address)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(address);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<string> GetData(string path)
        {
            if (!path.Contains("api")) return null;
            HttpResponseMessage response = client.GetAsync(path).Result;
            return response.Content.ReadAsStringAsync();
        }

        public bool HasLoaded
        {
            get { return client != null; }
        }
    }
}
