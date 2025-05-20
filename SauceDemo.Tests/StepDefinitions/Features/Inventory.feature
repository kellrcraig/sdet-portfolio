Feature: Inventory

    Scenario: Inventory page loads with default items, cart button state, sorting option, and empty cart
        Given I open the login page
        When I log in as "standard_user"
        Then the cart badge is not displayed
        And the sort dropdown displays "Name (A to Z)"
        And the "Sauce Labs Bolt T-Shirt" cart button displays "Add to cart"
        And the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |
            | Sauce Labs Bike Light             | 2     |
            | Sauce Labs Bolt T-Shirt           | 3     |
            | Sauce Labs Fleece Jacket          | 4     |
            | Sauce Labs Onesie                 | 5     |
            | Test.allTheThings() T-Shirt (Red) | 6     |

    Scenario: Sorting by Name (A to Z) orders items alphabetically
        Given I open the login page
        And I log in as "standard_user"
        When I sort by "Name (Z to A)"
        And I sort by "Name (A to Z)"
        Then the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |
            | Sauce Labs Bike Light             | 2     |
            | Sauce Labs Bolt T-Shirt           | 3     |
            | Sauce Labs Fleece Jacket          | 4     |
            | Sauce Labs Onesie                 | 5     |
            | Test.allTheThings() T-Shirt (Red) | 6     |

    Scenario: Sorting by Name (Z to A) orders items in reverse alphabetical order
        Given I open the login page
        And I log in as "standard_user"
        When I sort by "Name (Z to A)"
        Then the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 6     |
            | Sauce Labs Bike Light             | 5     |
            | Sauce Labs Bolt T-Shirt           | 4     |
            | Sauce Labs Fleece Jacket          | 3     |
            | Sauce Labs Onesie                 | 2     |
            | Test.allTheThings() T-Shirt (Red) | 1     |

    Scenario: Sorting by Price (low to high) orders items from cheapest to most expensive
        Given I open the login page
        And I log in as "standard_user"
        When I sort by "Price (low to high)"
        Then the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 5     |
            | Sauce Labs Bike Light             | 2     |
            | Sauce Labs Bolt T-Shirt           | 3     |
            | Sauce Labs Fleece Jacket          | 6     |
            | Sauce Labs Onesie                 | 1     |
            | Test.allTheThings() T-Shirt (Red) | 4     |

    Scenario: Sorting by Price (high to low) orders items from most to least expensive
        Given I open the login page
        And I log in as "standard_user"
        When I sort by "Price (high to low)"
        Then the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 2     |
            | Sauce Labs Bike Light             | 5     |
            | Sauce Labs Bolt T-Shirt           | 3     |
            | Sauce Labs Fleece Jacket          | 1     |
            | Sauce Labs Onesie                 | 6     |
            | Test.allTheThings() T-Shirt (Red) | 4     |

    Scenario: Add to cart button increases cart badge count
        Given I open the login page
        And I log in as "standard_user"
        When I add the following items to the cart:
            | Product                  | Order |
            | Sauce Labs Backpack      | 1     |
            | Sauce Labs Bike Light    | 2     |
            | Sauce Labs Fleece Jacket | 3     |
        Then the cart badge displays "3"

    Scenario: Remove button decreases cart badge count
        Given I open the login page
        And I log in as "standard_user"
        When I add the following items to the cart:
            | Product                  | Order |
            | Sauce Labs Bolt T-Shirt  | 1     |
            | Sauce Labs Bike Light    | 2     |
            | Sauce Labs Fleece Jacket | 3     |
            | Sauce Labs Onesie        | 4     |
        And I remove the following items from the cart:
            | Product                  |
            | Sauce Labs Fleece Jacket |
            | Sauce Labs Onesie        |
        Then the cart badge displays "2"

    @page-navigation
    Scenario: Back to products link navigates from the Item detail screen to Inventory page
        Given I open the login page
        And I log in as "standard_user"
        And I click the "Test.allTheThings() T-Shirt (Red)" link
        When I click Back to products
        Then the "inventory" page is displayed

    @cart-button-state
    Scenario: Cart button displays Remove after adding item to the cart
        Given I open the login page
        And I log in as "standard_user"
        When I add "Sauce Labs Onesie" to the cart
        Then the "Sauce Labs Onesie" cart button displays "Remove"

    @cart-button-state
    Scenario: Remove button displays Add to cart after removing item from the cart
        Given I open the login page
        And I log in as "standard_user"
        And I add "Sauce Labs Bolt T-Shirt" to the cart
        And I click the cart icon
        And I remove "Sauce Labs Bolt T-Shirt" from the cart
        When I click Continue Shopping
        Then the "Sauce Labs Bolt T-Shirt" cart button displays "Add to cart"

    @cart-button-state
    Scenario: Add to cart button displays Remove on Inventory page after adding from item detail
        Given I open the login page
        And I log in as "standard_user"
        And I click the "Sauce Labs Bolt T-Shirt" link
        And I click Add to cart
        When I click Back to products
        Then the "Sauce Labs Bolt T-Shirt" cart button displays "Remove"

    @cart-button-state
    Scenario: Add to cart button displays Add to cart on Inventory page after removing from item detail
        Given I open the login page
        And I log in as "standard_user"
        And I add "Sauce Labs Fleece Jacket" to the cart
        And I click the "Sauce Labs Fleece Jacket" link
        And I click Remove
        When I click Back to products
        Then the "Sauce Labs Fleece Jacket" cart button displays "Add to cart"
