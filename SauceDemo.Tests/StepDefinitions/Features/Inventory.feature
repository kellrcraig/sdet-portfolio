Feature: Inventory

    Scenario: Inventory page loads with default items, sorting option, and empty cart
        Given I open the login page
        When I log in as "standard_user"
        Then the cart badge is not displayed
        And the sort dropdown displays "Name (A to Z)"
        And the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |
            | Sauce Labs Bike Light             | 2     |
            | Sauce Labs Bolt T-Shirt           | 3     |
            | Sauce Labs Fleece Jacket          | 4     |
            | Sauce Labs Onesie                 | 5     |
            | Test.allTheThings() T-Shirt (Red) | 6     |

    @wip
    Scenario: Sorting by Name (A to Z) orders items alphabetically
    @wip
    Scenario: Sorting by Name (Z to A) orders items in reverse alphabetical order
    @wip
    Scenario: Sorting by Price (low to high) orders items from cheapest to most expensive
    @wip
    Scenario: Sorting by Price (high to low) orders items from most to least expensive
    @wip
    Scenario: Add to cart button updates cart badge count
    @wip
    Scenario: Remove button updates cart badge count

    @page-navigation @wip
    Scenario: Back to products link navigates from the Item detail screen to Inventory page

    @reset-app-state @wip
    Scenario: Reset App State link reverts items, sorting option, and cart badge count to defaults
    @wip
    Scenario: Items and sorting option persist when returning to Inventory page

    @cart-button-state @wip
    Scenario: Remove button displays Add to cart after removing item from the cart
    @cart-button-state @wip
    Scenario: Add to cart button displays Remove on Inventory page after adding from item detail
    @cart-button-state @wip
    Scenario: Add to cart button displays Add to cart on Inventory page after removing from item detail
