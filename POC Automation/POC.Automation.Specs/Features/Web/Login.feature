@Smoke
Feature: Login
Background: 
Given I navigate to Login
    When I set '[UserName]' in UserName on Login
    And I set '[Password]' in Password 
    And I click Login

  @Login
  Scenario: Verify that Projects page is loaded
    Then I should see 'Projects' displayed on Projects
    And I should see 'Search' displayed 
    And I should see 'Create Project' displayed 
       

  @Login
  Scenario: Verify Search project 
   Given I set 'Banco de la Union' in Search on Projects
   When I click More
