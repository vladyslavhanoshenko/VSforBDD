Feature: Github Repos Api
	As PO I want to having Repository API to allow users to have access to their repositories from other applications.

Scenario: 01 List of repository should be returned when user make get request to git repos api
	When I make get request to git repos api
	Then List of repositories with count 2 should be returned
	And List of repositories should contain git_lesson_1 name

Scenario: 02 Repository should be created after post request performed
	Given I have data prepared for repository with CreatedByWebClient2 name
	When I create new repository
	Then Repository with CreatedByWebClient2 name is created
	And Repository is present in git

Scenario: 03 Repository should be deleted after delete request performed
	When I delete CreatedByWebClient2 repository
	Then CreatedByWebClient2 repository is deleted
