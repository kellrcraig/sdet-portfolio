namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;

    public class CartIconComponent : BaseComponent
    {
        public CartIconComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public string CartIconCount => Driver.FindRequiredElement(By.CssSelector("[data-test='shopping-cart-badge']")).Text;

        public void ClickCartIcon()
        {
            var locator = By.CssSelector("[data-test='shopping-cart-link']");
            Driver.FindRequiredElement(locator).Click();
        }
    }
}