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
        Then the "Epic sadface: You can only access '/inventory.html' when you are logged in." form error message is displayed

    Scenario: Logged out user cannot access protected pages via direct URL
        Given I open the login page
        And I log in as "standard_user"
        And I open the menu
        When I click the logout link
        And I open the inventory page
        Then the "Epic sadface: You can only access '/inventory.html' when you are logged in." form error message is displayed
    
    Scenario: Cart badge count is preserved after logout
        Given I open the login page
        And I log in as "standard_user"
        And I add "Sauce Labs Backpack" to the cart
        When I open the menu
        And I click the logout link
        And I log in as "standard_user"
        Then the cart badge displays "1"
    
    Scenario: Item in cart is preserved after logout
        Given I open the login page
        And I log in as "standard_user"
        And I add "Sauce Labs Backpack" to the cart
        When I open the menu
        And I click the logout link
        And I log in as "standard_user"
        And I click the cart icon
        Then the checkout product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |        

    @regression
    Scenario: User is logged out after 10 minutes
        Given I open the login page
        And I log in as "standard_user"
        And I wait for "10" minutes
        When I click the cart icon
        Then the "login" page is displayed
        And the "Epic sadface: You can only access '/cart.html' when you are logged in." form error message is displayed