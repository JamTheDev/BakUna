using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Diagnostics;

namespace BakUna.WebAPI
{
    class WebApiController
    {
        private static WebApiController _instance = null;
        private HttpClient client;

        // Singleton Pattern
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

        public bool HasInternet()
        {
            try
            {
                using (var internetConnection = new WebClient())
                {
                    using (internetConnection.OpenRead("http://google.com/generate_204"))
                        return true;
                }
            } catch
            {
                return false;
            }
        }

        public void LoadWebApi(string address)
        {
            if(!HasInternet())
            {
                throw new Exception("No internet!");
            }
            client = new HttpClient();
            client.BaseAddress = new Uri(address);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public bool LoadApi(string address)
        {
            try
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }


        public HttpClient GetHttpClient => client;

        public async Task<T> Get<T>(string path)
        {
            return await GetHttpClient.GetFromJsonAsync<T>(path);
        }

        public async Task<HttpResponseMessage> Put<T>(string path, T dataToPost)
        {
            return await GetHttpClient.PostAsJsonAsync(path, dataToPost);
        }



        public bool HasLoaded
        {
            get { return client != null; }
        }
    }
}
