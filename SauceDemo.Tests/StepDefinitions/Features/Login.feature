Feature: Login

    Scenario: Standard user logs in
        Given I open the login page
        When I log in as "standard_user"
        Then the "inventory" page is displayed
    
    Scenario: Locked out user cannot log in
        Given I open the login page
        When I log in as "locked_out_user"
        Then the "login" page is displayed
        And the "Epic sadface: Sorry, this user has been locked out." form error message is displayed
        And all fields display error styling

    Scenario: User with incorrect username cannot log in
        Given I open the login page
        When I log in as "incorrect_username"
        Then the "login" page is displayed
        And the "Epic sadface: Username and password do not match any user in this service" form error message is displayed
        And all fields display error styling

    Scenario: User with empty username cannot log in
        Given I open the login page
        When I log in with username "" and password "secret_sauce"
        Then the "login" page is displayed
        And the "Epic sadface: Username is required" form error message is displayed
        And all fields display error styling

    Scenario: User with empty password cannot log in
        Given I open the login page
        When I log in with username "standard_user" and password ""
        Then the "login" page is displayed
        And the "Epic sadface: Password is required" form error message is displayed
        And all fields display error styling

    Scenario: User with incorrect password cannot log in
        Given I open the login page
        When I log in with username "standard_user" and password "incorrect_password"
        Then the "login" page is displayed
        And the "Epic sadface: Username and password do not match any user in this service" form error message is displayed
        And all fields display error styling

    Scenario: Login error is cleared after closing the message
        Given I open the login page
        And I log in as "incorrect_username"
        And the "Epic sadface: Username and password do not match any user in this service" form error message is displayed
        When I dismiss the form error message
        Then the form error message is not displayed
        And no fields display error styling
