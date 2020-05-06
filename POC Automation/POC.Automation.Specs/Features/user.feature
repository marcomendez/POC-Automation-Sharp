@ApiTest
Feature: User

  I as an user I want to test bla bla bla
  
  Background: mm
    Given  I navigate to ClickUpp
    And I set '10' in count

  Background:
    Given I navigate to ClickUpp

  @ORPHAN @WebApp
  Scenario: Test from jira
    Given Given I navigate to ClickUpp
    And I set '10' in count
    And I click
