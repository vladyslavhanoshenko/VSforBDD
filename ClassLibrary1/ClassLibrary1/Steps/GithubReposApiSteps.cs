using System.Linq;
using ClassLibrary1.Models;
using ClassLibrary1.Services;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Steps
{
    [Binding]
    public class GithubReposApiSteps
    {
        private GithubReposApi _gitHubApi = new GithubReposApi();
        private RepositoryModel[] _repositories;
        private RepositoryModel _repository;
        private RepositoryModel _repositoryCreateModel;
        private RepositoryCreateModel _repositoryDataModel;

        [Given(@"I have data prepared for repository with (.*) name")]
        public void GivenIHaveDataPreparedForRepositoryCreation(string name)
        {
            _repositoryDataModel = new RepositoryCreateModel
            {
                name = name,
                description = "created by webclient",
                homepage = "https://github.com",
                @private = false,
                has_issues = true,
                has_projects = true,
                has_wiki = true
            };
        }


        [When(@"I make get request to git repos api")]
        public void WhenIMakeGetRequestToGitReposApi()
        {
            _repositories = _gitHubApi.GetListOfRepositoriesForAuthenticatedUser();
        }

        [When(@"I delete (.*) repository")]
        public void WhenIDeleteTestRepository(string repoName)
        {
            _gitHubApi.DeleteRepositoryByName(repoName);
        }

        [When(@"I create new repository")]
        public void WhenICreateNewRepositoryWithFirstRepoName()
        {
            _repositoryCreateModel = _gitHubApi.CreateRepository(_repositoryDataModel);
        }

        [Then(@"List of repositories with count (.*) should be returned")]
        public void ThenListOfRepositoriesWithCountShouldBeReturned(int numberOfRepos)
        {
            _repositories.Length.Should().Be(numberOfRepos);
        }

        [Then(@"List of repositories should contain (.*) name")]
        public void ThenListOfReposShouldContaint(string name)
        {
            _repositories.Any(i => i.name.Equals(name));
        }

        [Then(@"Repository with (.*) name is created")]
        public void ThenRepositoryWithFirstRepoNameIsCreated(string repoName)
        {
            _repositoryCreateModel.name.Should().BeEquivalentTo(repoName);
        }

        [Then(@"Repository is present in git")]
        public void ThenRepositoryIsPresentInGit()
        {
            var actualRepositories = _gitHubApi.GetListOfRepositoriesForAuthenticatedUser();
            actualRepositories.Any(repo => repo.name.Equals(_repositoryCreateModel.name));
        }

        [Then(@"(.*) repository is deleted")]
        public void ThenTestRepositoryIsDeleted(string name)
        {
            var actualRepositories = _gitHubApi.GetListOfRepositoriesForAuthenticatedUser();
            actualRepositories.Any(repo => !repo.name.Equals(name));
            Assert.AreEqual();
            Assert.IsTrue();
        }
    }
}
