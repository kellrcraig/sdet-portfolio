Feature: Login

    Scenario: Standard user logs in
        Given I open the login page
        When I log in as "standard_user"
        Then the "inventory" page is displayed
    
    Scenario: Locked out user cannot log in
        Given I open the login page
        When I log in as "locked_out_user"
        Then the "login" page is displayed
        And the "Epic sadface: Sorry, this user has been locked out." message is displayed

    Scenario: User with incorrect username cannot log in
        Given I open the login page
        When I log in as "incorrect_username"
        Then the "login" page is displayed
        And the "Epic sadface: Username and password do not match any user in this service" message is displayed

    Scenario: User with empty username cannot log in
        Given I open the login page
        When I log in with username "" and password "secret_sauce"
        Then the "login" page is displayed
        And the "Epic sadface: Username is required" message is displayed        

    Scenario: User with empty password cannot log in
        Given I open the login page
        When I log in with username "standard_user" and password ""
        Then the "login" page is displayed
        And the "Epic sadface: Password is required" message is displayed

    Scenario: User with incorrect password cannot log in
        Given I open the login page
        When I log in with username "standard_user" and password "incorrect_password"
        Then the "login" page is displayed
        And the "Epic sadface: Username and password do not match any user in this service" message is displayed

    Scenario: Login error is cleared after closing the message
        Given I open the login page
        And I log in as "incorrect_username"
        When I dismiss the error message
        Then the error message is not displayed
