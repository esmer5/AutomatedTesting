
Feature: Login Form Validation
  Verify different login behaviors of the SauceDemo login page

  Scenario: UC-1 - Login with empty credentials
  Given the user navigates to the SauceDemo login page
  When clicks the login button
  Then an error message 'Epic sadface: Username is required' should be displayed

  Scenario: UC-2 - Login with username only
  Given the user navigates to the SauceDemo login page
  When the user enters 'standard_user' as username and clears password
  And clicks the login button
  Then an error message 'Epic sadface: Password is required' should be displayed

  Scenario Outline: UC-3 - Valid login
    Given the user navigates to the SauceDemo login page
    When the user enters '<username>' as username and 'secret_sauce' as password
    And clicks the login button
    Then the user should see the title 'Swag Labs'

    Examples:
      | username       |
      | standard_user  |
      | problem_user   |
