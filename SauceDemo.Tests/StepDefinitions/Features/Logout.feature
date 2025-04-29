Feature: Logout

    Scenario: Logout link redirects the user to login page
        Given I open the login page
        And I log in as "standard_user"
        And I open the menu
        When I click the logout link
        Then the "login" page is displayed

    Scenario: Logged out user cannot access protected pages via Back button
        Given I open the login page
        And I log in as "standard_user"
        And I open the menu
        When I click the logout link
        And I click the back button
        Then the "Epic sadface: You can only access '/inventory.html' when you are logged in." message is displayed

    Scenario: Logged out user cannot access protected pages via direct URL
        Given I open the login page
        And I log in as "standard_user"
        And I open the menu
        When I click the logout link
        And I open the products page
        Then the "Epic sadface: You can only access '/inventory.html' when you are logged in." message is displayed
    @wip
    Scenario: User who is actively using the app is not automatically logged out after 10 minutes

    @wip
    #we are going to navigate to the cart. Maybe back button?
    Scenario: Idle user cannot cannot modify cart after automatic logout
    
    @wip
    Scenario: Cart contents are preserved after logout