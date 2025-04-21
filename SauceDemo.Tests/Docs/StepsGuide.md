# Steps Guide for BDD Testing in SpecFlow

A practical reference for understanding and writing clean, expressive, and maintainable step definitions in your `.feature` files using SpecFlow with C#.

---

## ✅ Step-by-Step Clarifications

### 1. **Given = Preconditions**
Use `Given` to describe the setup or initial state of the system before the main action occurs.

```gherkin
Given I am on the login page
```

---

### 2. **When = Actions**
Use `When` to represent user or system interactions that trigger the behavior under test.

```gherkin
When I add "Sauce Labs Backpack" to the cart
```

---

### 3. **Tense for Given/When/Then?**
All steps (even `Given`) should be written in **present tense**, not past.

#### ❌ Don't:
```gherkin
Given I had logged in
```

#### ✅ Do:
```gherkin
Given I log in as "standard_user"
```

---

### 4. **Can a Step Be Given or When?**
Yes, depending on the context.

- If login is **setup**, use:
  ```gherkin
  Given I log in as "standard_user"
  ```

- If login is the **behavior being tested**, use:
  ```gherkin
  When I log in as "standard_user"
  ```

---

### 5. **Then = Outcomes / Assertions**
Use `Then` to validate the result or output of the scenario.

```gherkin
Then the cart icon displays 1
```

---

### 6. **Each Step Binds to a Single Method**
```gherkin
When I click the login button
```
Requires a binding like:
```csharp
[When("I click the login button")]
public void WhenIClickTheLoginButton() { ... }
```

---

### 7. **Steps File Structure**
- One `Steps.cs` file per `.feature` file is common
- Shared steps (e.g., login) can go in a `CommonSteps.cs`

---

### 8. **Use a Common Steps File**
Useful for:
- Logging in
- Navigating between pages
- Validating shared components (e.g., menu, cart icon)

Create it as:
```csharp
[Binding]
public class CommonSteps { ... }
```

---

### 9. **Use Regular Expressions to Capture Parameters**
```csharp
[Given(@"I log in with username \"(.*)\" and password \"(.*)\")]
public void Login(string username, string password) { ... }
```

More readable:
```csharp
[Given("I log in with credentials: \"(.*)\" and \"(.*)\")]
```

---

### 10. **Use Tables with `|` for Structured Data**
```gherkin
Given I log in with the following:
  | username      | password     |
  | standard_user | secret_sauce |
```

Step binding:
```csharp
[Given("I log in with the following:")]
public void LoginWithTable(Table table) {
    var creds = table.Rows[0];
    Login(creds["username"], creds["password"]);
}
```

---

### 11. **Step Definitions Should Call Page Objects**
Keep bindings thin and delegate UI interactions to Page Object Models (POMs).

```csharp
_loginPage.EnterUsername(user);
_loginPage.Submit();
```

---

### 12. **Assertions Go in the Steps.cs Files**
```csharp
[Then("the inventory page is displayed")]
public void InventoryPageIsDisplayed() {
    Assert.That(_inventoryPage.IsVisible, Is.True);
}
```

---

## 🔑 Sharing Data Between Steps

### Why?
To verify outcomes based on prior actions (e.g., checking which item was added to cart).

---

### Option 1: Store in Fields
```csharp
private string _addedItem;

[When("I add \"(.*)\" to the cart")]
public void AddToCart(string item) {
    _cartPage.AddItem(item);
    _addedItem = item;
}

[Then("the cart should contain the added item")]
public void CartShouldContainAddedItem() {
    Assert.That(_cartPage.GetItems(), Contains.Item(_addedItem));
}
```

---

### Option 2: Use `ScenarioContext`
```csharp
private readonly ScenarioContext _ctx;

public CartSteps(ScenarioContext ctx) {
    _ctx = ctx;
}

[When("I add \"(.*)\" to the cart")]
public void AddItem(string item) {
    _ctx["addedItem"] = item;
}

[Then("the cart should contain the added item")]
public void AssertCart() {
    var item = _ctx["addedItem"].ToString();
    Assert.That(_cartPage.GetItems(), Contains.Item(item));
}
```

---

### Option 3: Use Your Own `TestContext`
```csharp
public class TestContext {
    public string CurrentUser { get; set; }
    public string LastAddedItem { get; set; }
}
```
Then inject and reuse it:
```csharp
public CartSteps(TestContext context) {
    _ctx = context;
}
```
