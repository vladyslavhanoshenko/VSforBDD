Feature: Github Repos Api
	As PO I want to have working API to allow users to have access to their repositories from other applications. 

Scenario: 01 List of repository should be returned when user make get request to git repos api
  When I make get request to git repost api
  Then List of repositories with count 30 should be returned

Scenario: 02 Repository should be created after post request performed
  When I create new repository with FirstRepo name
  Then Repository with FirstRepo name is created

Scenario: 03 Repository should be deleted after delete request performed
  When I delete Hello-World repository
  Then Hello-World repository is deleted