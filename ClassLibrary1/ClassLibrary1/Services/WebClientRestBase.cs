using Newtonsoft.Json;
using System.Net;

namespace ClassLibrary1.Services
{
    public class WebClientRestBase
    {
        private WebClient _client;
        private string _baseUri;

        protected WebClientRestBase(string uri, string token)
        {
            _client = new WebClient();
            _client.Headers.Add("Authorization", token);
            _client.Headers.Add("Content-Type", "application/json");
            _client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");
            _baseUri = uri;
        }

        protected T Deserizialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        protected T Get<T>(string resourseEndpoint) where T : class
        {
            var response = _client.DownloadString(_baseUri + resourseEndpoint);
            T deserializedResponse = Deserizialize<T>(response);
            return deserializedResponse;
        }

        protected T Post<T>(string resourseEndpoint, string dataToUpload) where T : class
        {
            var response = _client.UploadString(_baseUri + resourseEndpoint, "POST", dataToUpload);
            T deserializedResponse = Deserizialize<T>(response);
            return deserializedResponse;
        }

        protected void Delete(string resourseEndpoint, string data = "")
        {
            _client.UploadString(_baseUri + resourseEndpoint, "DELETE", data);
        }

        protected T Put<T>(string resourseEndpoint, string data) where T : class
        {
            var response = _client.UploadString(_baseUri + resourseEndpoint, "POST", data);
            T deserializedResponse = Deserizialize<T>(response);
            return deserializedResponse;
        }








        

    }
}
