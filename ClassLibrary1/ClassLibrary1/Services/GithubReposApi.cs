using System.Net;
using ClassLibrary1.Models;
using Newtonsoft.Json;

namespace ClassLibrary1.Services
{
    public class GithubReposApi
    {
        private readonly string _baseUrl = "https://api.github.com/";
        private readonly string _token = "Bearer 45916a3ec58f610a55c87a9a8d8d744cd3427ea3";
        private WebClient _client;

        public GithubReposApi()
        {
            _client = new WebClient();
            _client.Headers.Add("Authorization", _token);
            _client.Headers.Add("Content-Type", "application/json");
            _client.Headers.Add("User-Agent", "Mozilla/5.0 (Linux; Android 6.0.1; SM-G935S Build/MMB29K; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/55.0.2883.91 Mobile Safari/537.36");
        }

        public RepositoryModel[] GetListOfRepositoriesForAuthenticatedUser()
        {
            var response = _client.DownloadString(_baseUrl + "user/repos");
            var deserializedResponse = JsonConvert.DeserializeObject<RepositoryModel[]>(response);
            return deserializedResponse;
        }

        public RepositoryModel CreateRepository(RepositoryCreateModel modelToBeCreated)
        {
            var serializiedDataToBeCreated = JsonConvert.SerializeObject(modelToBeCreated);
            var response = _client.UploadString(_baseUrl + "user/repos", serializiedDataToBeCreated);
            var deserializedResponse = JsonConvert.DeserializeObject<RepositoryModel>(response);
            return deserializedResponse;
        }

        public void DeleteRepositoryByName(string repositoryName, string data ="")
        {
            _client.UploadString(_baseUrl + "repos/vladyslav-hanoshenko/" + repositoryName, "DELETE", data);
        }

    }
}
