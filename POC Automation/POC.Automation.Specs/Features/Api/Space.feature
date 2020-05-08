Feature: Spaceeeeeeeeee

  @ApiTest
  Scenario: Verify that Space Id is Got
    Given I send 'GetTeam' from Team as 'TeamResponse'
    When I send 'GetTeamById' with 'TeamResponse' from Space as 'SpaceResponse'
    Then I should see '3043881' in SpaceID with 'SpaceResponse' from Space

  @ApiTest @POC-5 @OPEN
  Scenario: Verify that Space is Created
    Given I send 'GetTeam' from Team as 'TeamResponse'
    When I send 'CreateSpace' with 'SpaceName' and 'TeamResponse' from Space as 'SpaceResponseCreated'
    Then I should see 'SpaceName' in SpaceName with 'SpaceResponseCreated' from Space
    And I send 'DeleteSpace' with 'SpaceResponseCreated' from Space as 'SpaceResponseDeleted'
