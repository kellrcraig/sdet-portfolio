Feature: Item Detail

    @page-navigation
    Scenario: Item Detail page displays correct item after selecting item name from Inventory
        Given I open the login page
        And I log in as "standard_user"
        When I click the "Sauce Labs Fleece Jacket" link
        Then the "item detail" page is displayed
        And the item detail product area displays the "Sauce Labs Fleece Jacket"

    @page-navigation
    Scenario: Item Detail page displays correct item after selecting image from Inventory 
        Given I open the login page
        And I log in as "standard_user"
        When I click the "Sauce Labs Onesie" image
        Then the "item detail" page is displayed
        And the item detail product area displays the "Sauce Labs Onesie"
        
    @page-navigation
    Scenario: Item Detail page displays correct item after selecting item name from Cart
        Given I open the login page
        And I log in as "standard_user"
        And I add "Sauce Labs Backpack" to the cart
        And I click the cart icon
        When I click the "Sauce Labs Backpack" link
        Then the "item detail" page is displayed
        And the item detail product area displays the "Sauce Labs Backpack"

    @cart-button-state
    Scenario: Remove button displays Add to cart on Item Detail page after removing item from the cart
        Given I open the login page
        And I log in as "standard_user"
        And I add "Test.allTheThings() T-Shirt (Red)" to the cart
        And I click the cart icon
        And I remove "Test.allTheThings() T-Shirt (Red)" from the cart
        And I click Continue Shopping
        When I click the "Test.allTheThings() T-Shirt (Red)" link
        Then the "item detail" page is displayed
        And the item detail product area displays the "Test.allTheThings() T-Shirt (Red)"
        And the cart button displays "Add to cart"

    @cart-button-state
    Scenario: Add to cart button displays Remove on Item Detail page after adding from inventory
        Given I open the login page
        And I log in as "standard_user"
        And I add "Sauce Labs Bike Light" to the cart
        When I click the "Sauce Labs Bike Light" link
        Then the "item detail" page is displayed
        And the item detail product area displays the "Sauce Labs Bike Light"
        And the cart button displays "Remove"

    @cart-button-state
    Scenario: Add to cart button displays Add to cart on Item Detail page after removing from inventory
        Given I open the login page
        And I log in as "standard_user"
        And I add "Sauce Labs Backpack" to the cart
        And the "Sauce Labs Backpack" cart button displays "Remove"
        And I remove "Sauce Labs Backpack" from the cart
        When I click the "Sauce Labs Backpack" image
        Then the "item detail" page is displayed
        And the item detail product area displays the "Sauce Labs Backpack"
        And the cart button displays "Add to cart"