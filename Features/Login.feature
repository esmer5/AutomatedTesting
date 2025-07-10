
Feature: Login Form Validation

  Scenario: UC-1 - Login with empty credentials
    Given the user is on the login page
    When the user clicks the login button
    Then an error message 'Epic sadface: Username is required' should be displayed

  Scenario: UC-2 - Login with username only
    Given the user is on the login page
    When the user enters 'standard_user' as username and clears password
    And the user clicks the login button
    Then an error message 'Epic sadface: Password is required' should be displayed

  Scenario Outline: UC-3 - Valid login
    Given the user is on the login page
    When the user enters '<username>' as username and 'secret_sauce' as password
    And the user clicks the login button
    Then the user should see the title 'Swag Labs'

    Examples:
      | username       |
      | standard_user  |
      | problem_user   |
