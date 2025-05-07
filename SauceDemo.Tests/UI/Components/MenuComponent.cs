namespace SauceDemo.Tests.UI.Components
{
    using System;
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;

    public class MenuComponent : BaseComponent
    {
        public MenuComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public void OpenMenu()
        {
            Driver.FindRequiredElement(By.Id("react-burger-menu-btn"))?.Click();
        }

        public void CloseMenu()
        {
            WaitHelper.WaitForElementToBeClickable(Driver, By.Id("react-burger-cross-btn"))?.Click();
        }

        public void ClickAllItemsLink()
        {
            WaitHelper.WaitForElementToBeClickable(Driver, By.Id("inventory_sidebar_link"))?.Click();
        }

        public void ClickAboutLink()
        {
            WaitHelper.WaitForElementToBeClickable(Driver, By.Id("about_sidebar_link"))?.Click();
        }

        public void ClickLogoutLink()
        {
            WaitHelper.WaitForElementToBeClickable(Driver, By.Id("logout_sidebar_link"))?.Click();
        }

        public void ClickResetLink()
        {
            WaitHelper.WaitForElementToBeClickable(Driver, By.Id("reset_sidebar_link"))?.Click();
        }

        public bool MenuIsVisible()
        {
            var locator = By.ClassName("bm-menu-wrap");
            WaitHelper.WaitForElementToDisappear(Driver, locator);
            var element = Driver.FindElementSafe(locator);
            return element != null && element.Displayed;
        }
    }
}