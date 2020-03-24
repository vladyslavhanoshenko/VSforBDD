using ClassLibrary1.Models;
using ClassLibrary1.Services;
using FluentAssertions;
using System.Linq;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Steps
{
    [Binding]
    public class GithubReposApiSteps
    {
        private GithubReposApi githubReposApi = new GithubReposApi();
        private RepositoryModel[] _repositories;
        private RepositoryModel _repository;

        [When(@"I make get request to git repost api")]
        public void WhenIMakeGetRequestToGitRepostApi()
        {
            _repositories = githubReposApi.GetListOfRepositoriesForAuthenticatedUser();
        }

        [Then(@"List of repositories with count (.*) should be returned")]
        public void ThenListOfRepositoriesWithCountShouldBeReturned(int count)
        {
            _repositories.Length.Should().Be(count);
        }

        [When(@"I create new repository with (.*) name")]
        public void WhenIMakePostRequestToCreateNewRepository(string repositoryName)
        {
            _repository = githubReposApi.CreateRepositoryWithName(repositoryName);
        }

        [Then(@"Repository with (.*) name is created")]
        public void ThenRepositoryIsCreated(string repositoryName)
        {
            repositoryName.Should().BeEquivalentTo(_repository.name);
        }

        [When(@"I delete (.*) repository")]
        public void WhenIMakeDeleteRequestToDeleteRepository(string repositoryName)
        {
            githubReposApi.DeleteRepositoryByName(repositoryName);
           
        }

        [Then(@"(.*) repository is deleted")]
        public void ThenRepositoryIsDeleted(string repositoryName)
        {
            var repositories = githubReposApi.GetListOfRepositoriesForAuthenticatedUser().ToList();
            repositories.Where(item => item.name.Equals(repositoryName)).Should().BeEquivalentTo(0);
        }

    }
}
