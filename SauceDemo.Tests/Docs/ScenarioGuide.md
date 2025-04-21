# Scenario Guide for Gherkin Feature Files

A practical, opinionated guide to writing clean, consistent, and professional scenario titles and descriptions in `.feature` files. This style guide is based on your finalized scenario titles, recurring challenges, and professional conventions used in high-quality test automation projects.

---

## ✅ Overall Goals
- Prioritize clarity over cleverness
- Emphasize system behavior and user outcomes
- Stay consistent with tense, structure, and voice

---

## 📂 Feature File Naming
| Rule | Example |
|------|---------|
| Use noun-based or concept-based names | `Login.feature`, `Cart.feature` |
| Use PascalCase or kebab-case (your choice, be consistent) | `CheckoutOverview.feature` or `checkout-overview.feature` |

---

## ✅ Scenario Titles: Naming Conventions

### Format: `{Subject/Element} {Behavior} {Condition (if needed)}`

| ✅ Do | 🚫 Don’t |
|------|---------|
| `Scenario: Add to cart button updates cart icon count` | `Scenario: Can add item` |
| `Scenario: Remove button displays Add to cart on inventory page after removing from item detail` | `Scenario: Button resets` |
| `Scenario: Checkout button navigates to Checkout: Your Information page when cart is not empty` | `Scenario: Checkout works` |

### Use:
- **Present tense** verbs (`updates`, `displays`, `navigates`)
- **Descriptive nouns** (`cart icon count`, `item detail page`)
- **Clear cause-effect structure** if relevant

---

## 🔤 Grammar, Tone, and Style

### ✅ Preferred:
- **Avoid articles** unless it improves clarity:
  - ✅ `Add to cart button updates cart icon`
  - ❌ `The add to cart button updates cart icon`

- **Avoid repetition**: Don’t restate the feature or subject in the scenario title unless necessary.
  - ❌ `Scenario: Login page user logs in successfully`
  - ✅ `Scenario: User logs in successfully`
  - ❌ `Scenario: Checkout page cancel button cancels checkout`
  - ✅ `Scenario: Cancel button returns user to inventory page`

- Include the page or subject only when needed for clarity—especially if the same behavior can occur on multiple pages. This improves readability in test results, CI pipelines, and shared documentation.
- Use **lowercase** for non-proper nouns
- Capitalize **Scenario** and the first word in the title
- Use **plural** nouns when referencing multiple fields/items (e.g., `name fields accept...`)

---

## 🔁 Reusable Patterns

| Pattern | Example |
|--------|---------|
| **Navigation** | `X button navigates to Y page` |
| **State persistence** | `Cart retains items after logout` |
| **Error handling** | `Login error is cleared after closing the message` |
| **Guarded access** | `Cannot access Checkout: Overview page via direct URL` |
| **UI change reaction** | `Remove button displays Add to cart after removing item from cart` |

---

## 🧠 Design Considerations

### ✅ File-local context is **not** assumed:
- Always include page or component in the title when:
  - The action could happen on multiple pages (e.g., `Add to cart button`)
  - You are testing effects across pages
  - You want failed tests to be meaningful in isolation (e.g., in CI reports)

```gherkin
Scenario: Remove button displays Add to cart on inventory page after removing from item detail
```

### ✅ Use tags to group test types
```gherkin
@cart-contents
@reset-app-state
```

---

## 📏 Avoid These Common Mistakes

| Mistake | Fix |
|--------|-----|
| Using future or past tense (`will`, `was`) | Use present: `navigates`, `displays` |
| Relying on feature filename for context | Embed critical context in scenario title |
| Writing vague scenarios (`Login works`, `Clicking button works`) | Describe *what* it does and *why* it matters |
| Using code-style variables in titles | Prefer natural language (e.g., `item detail page` not `ItemDetailPage`) |

---

## ✍️ Optional Enhancements

- Keep scenario titles under ~120 characters for readability
- Use markdown comments in `.feature` files to clarify **why** a scenario exists
```gherkin
# Validates persisted cart state after direct navigation
Scenario: Cart displays correct contents after returning via direct URL
```

- Use scenario titles as a communication tool. Imagine:
  - Test failures in CI pipelines
  - New developers/testers reading them for coverage context

---

## 🚧 Future Improvements
- Add non-functional scenario patterns (`@performance`, `@visual`, etc.)
- Establish templates for step phrasing and variable reuse

---
