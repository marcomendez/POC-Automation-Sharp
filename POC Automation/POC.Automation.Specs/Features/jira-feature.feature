@WebApp
Feature: JiraFeature

  @POC-5 @POC-4 @OPEN
  Scenario: Test Jira
    Given I go to Main Page
    And I click on Welcome button
    When I click on Save
    Then I should see the Home page displayed
