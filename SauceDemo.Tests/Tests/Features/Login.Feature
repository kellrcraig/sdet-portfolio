Feature: Login

    Scenario: Standard user logs in
        Given I am on the login page
        When I log in as "standard_user"
        Then I should be redirected to the inventory page
    
    Scenario: Locked out user cannot log in
    Scenario: User with incorrect username cannot log in
    Scenario: User with incorrect password cannot log in
    Scenario: User with empty username cannot log in
    Scenario: User with empty password cannot log in    
    Scenario: Login error is cleared after closing the message
    Scenario: Chrome's "change your password" notice is dismissed