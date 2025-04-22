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
    Scenario: User with incorrect password cannot log in
    Scenario: User with empty username cannot log in
    Scenario: User with empty password cannot log in    
    Scenario: Login error is cleared after closing the message
    Scenario: Chrome's "change your password" notice is dismissed