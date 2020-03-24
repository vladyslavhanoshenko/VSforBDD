using ClassLibrary1.Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace ClassLibrary1.Services
{
    public class GithubReposApi
    {
        private readonly string _baseUrl = "https://api.github.com";
        private readonly string Token = "a8f98be4742958319f7d50d6b12f7f5510cfbfc2";
        private WebClient _client;

        public GithubReposApi()
        {
            _client = new WebClient();
            _client.Headers.Add("Authorization", "Bearer a8f98be4742958319f7d50d6b12f7f5510cfbfc2");
            _client.Headers.Add("Content-Type", "application/json");
            _client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");
        }

        public RepositoryModel[] GetListOfRepositoriesForAuthenticatedUser()
        {
            var response = _client.DownloadString(_baseUrl + "/user/repos");
            var deserializedResponse = JsonConvert.DeserializeObject<RepositoryModel[]>(response);
            return deserializedResponse;
        }

        public RepositoryModel CreateRepositoryWithName(string repositoryName)
        {
            var repositoryData = new RepositoryCreateModel
            {
                name = repositoryName,
                description = "This is your first repository",
                homepage = "https://github.com",
                @private = false,
                has_issues = true,
                has_projects = true,
                has_wiki = true
            };
            var serializedData = JsonConvert.SerializeObject(repositoryData);       
            var response = _client.UploadString(_baseUrl + "/user/repos", serializedData);
            var deserializedResponse = JsonConvert.DeserializeObject<RepositoryModel>(response);
            return deserializedResponse;
        }

        public void DeleteRepositoryByName(string repositoryName)
        {
            try
            {
                _client.UploadString(_baseUrl + "/repos/vladyslavhanoshenko/" + repositoryName, "DELETE", "");
            }
            catch(WebException e)
            {
                Console.WriteLine($"Delete request failed with status code {e.Status} and {e.Message} message)");
                throw e;
            }
        }
    }
}
