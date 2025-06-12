Feature: Menu Component

    Scenario: Close button hides the menu
        Given I open the login page
        And I log in as "standard_user"
        And I open the menu
        When I close the menu
        Then the menu is not displayed

    @page-navigation
    Scenario: All Items link navigates to Inventory page
        Given I open the login page
        And I log in as "standard_user"
        And I click the cart icon
        And I open the menu
        When I click the all items link
        Then the "inventory" page is displayed

    @page-navigation @regression
    Scenario: About link navigates to the Sauce Labs website
        Given I open the login page
        And I log in as "standard_user"
        And I open the menu
        When I click the about link
        Then the "sauce labs" page is displayed

    @reset-app-state
    Scenario: Reset App State link reverts cart icon count to default
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                  | Order |
            | Sauce Labs Bolt T-Shirt  | 1     |
            | Sauce Labs Bike Light    | 2     |
            | Sauce Labs Fleece Jacket | 3     |
            | Sauce Labs Onesie        | 4     |
        And the cart badge displays "4"
        And I open the menu
        When I click the reset app state link
        Then the cart badge is not displayed