Feature: Your Cart

    @page-navigation
    Scenario: Continue Shopping button navigates back to inventory page
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |
            | Sauce Labs Fleece Jacket          | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |
            | Sauce Labs Onesie                 | 4     |
        And I click the cart icon
        When I click Continue Shopping
        Then the "inventory" page is displayed

    @page-navigation
    Scenario: Checkout button navigates to Checkout: Your Information page
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Onesie                 | 1     |
            | Sauce Labs Fleece Jacket          | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |
            | Sauce Labs Bike Light             | 4     |
        And I click the cart icon
        When I click Checkout
        Then the "checkout information" page is displayed

    @cart-contents
    Scenario: Cart displays all added items
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Backpack               | 2     |
            | Sauce Labs Bike Light             | 1     |
            | Sauce Labs Bolt T-Shirt           | 4     |
            | Sauce Labs Fleece Jacket          | 3     |
            | Sauce Labs Onesie                 | 6     |
            | Test.allTheThings() T-Shirt (Red) | 5     |
        When I click the cart icon
        Then the checkout product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 2     |
            | Sauce Labs Bike Light             | 1     |
            | Sauce Labs Bolt T-Shirt           | 4     |
            | Sauce Labs Fleece Jacket          | 3     |
            | Sauce Labs Onesie                 | 6     |
            | Test.allTheThings() T-Shirt (Red) | 5     |

    @cart-contents
    Scenario: Cart displays previously added items after logout
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                  | Order |
            | Sauce Labs Backpack      | 2     |
            | Sauce Labs Bike Light    | 1     |
            | Sauce Labs Bolt T-Shirt  | 4     |
            | Sauce Labs Fleece Jacket | 3     |
        And I open the menu
        And I click the logout link
        And I log in as "standard_user"
        When I click the cart icon
        Then the checkout product area displays the following items:
            | Product                  | Order |
            | Sauce Labs Backpack      | 2     |
            | Sauce Labs Bike Light    | 1     |
            | Sauce Labs Bolt T-Shirt  | 4     |
            | Sauce Labs Fleece Jacket | 3     |

    @cart-contents
    Scenario: Cart displays empty when there are no items in it
        Given I open the login page
        And I log in as "standard_user"
        When I click the cart icon
        Then the checkout product area displays empty

    @cart-contents
    Scenario: Remove button removes item from cart
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                  | Order |
            | Sauce Labs Backpack      | 2     |
            | Sauce Labs Bike Light    | 1     |
            | Sauce Labs Bolt T-Shirt  | 4     |
            | Sauce Labs Fleece Jacket | 3     |
        And I click the cart icon
        When I remove "Sauce Labs Fleece Jacket" from the cart
        Then the checkout product area displays the following items:
            | Product                  | Order |
            | Sauce Labs Backpack      | 2     |
            | Sauce Labs Bike Light    | 1     |
            | Sauce Labs Bolt T-Shirt  | 4     |