using ClassLibrary1.Models;

namespace ClassLibrary1.Services
{
    public class GithubContentsApi : WebClientRestBase
    {
        protected const string _baseUrl = "https://api.github.com/repos/";
        private static string _token = "a8f98be4742958319f7d50d6b12f7f5510cfbfc2";

        public GithubContentsApi() : base(_baseUrl, _token)
        {

        }

        public ContentsModel GetContents(string ownerName, string repositoryName)
        {
            return Get<ContentsModel>(ownerName + "/" + repositoryName + "/contents/");
        }

        public FileContentModel GetFileContent(string ownerName, string repositoryName, string fileName)
        {
            return Get<FileContentModel>(ownerName + "/" + repositoryName + "/contents/" + fileName);
        }

        public FolderContentModel GetFolderContent(string ownerName, string repositoryName, string fileName)
        {
            return Get<FolderContentModel>(ownerName + "/" + repositoryName + "/contents/" + fileName);
        }

        public CreatedFileModel CreateOrUpdateFile(string ownerName, string repositoryName, string fileName, string value)
        {
            return Put<CreatedFileModel>(ownerName + "/" + repositoryName + "/contents/" + fileName, value);
        }
    }
}
