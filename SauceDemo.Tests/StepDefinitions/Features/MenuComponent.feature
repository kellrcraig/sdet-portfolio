Feature: Menu Component

    # Reset App State behavior is tested in:
    # - Inventory.feature
    # - InventoryDetail.feature
    # - CheckoutYourCart.feature
    # - CheckoutOverview.feature

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

    @page-navigation
    Scenario: About link navigates to the Sauce Labs website
        Given I open the login page
        And I log in as "standard_user"
        And I open the menu
        When I click the about link
        Then the "sauce labs" page is displayed