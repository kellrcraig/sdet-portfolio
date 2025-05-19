namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class MenuComponent : UiObjectBase
    {
        public MenuComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public void OpenMenu()
        {
            Driver.FindRequiredElement(LocatorHelper.ById("react-burger-menu-btn"))?.Click();
        }

        public void CloseMenu()
        {
            WaitHelper.WaitForElementToBeClickableInDom(Driver, LocatorHelper.ById("react-burger-cross-btn"))?.Click();
        }

        public void ClickAllItemsLink()
        {
            WaitHelper.WaitForElementToBeClickableInDom(Driver, LocatorHelper.ById("inventory_sidebar_link"))?.Click();
        }

        public void ClickAboutLink()
        {
            WaitHelper.WaitForElementToBeClickableInDom(Driver, LocatorHelper.ById("about_sidebar_link"))?.Click();
        }

        public void ClickLogoutLink()
        {
            WaitHelper.WaitForElementToBeClickableInDom(Driver, LocatorHelper.ById("logout_sidebar_link"))?.Click();
        }

        public void ClickResetLink()
        {
            WaitHelper.WaitForElementToBeClickableInDom(Driver, LocatorHelper.ById("reset_sidebar_link"))?.Click();
        }

        public bool MenuIsVisible()
        {
            var locator = LocatorHelper.ByClassName("bm-menu-wrap");
            WaitHelper.WaitForElementToDisappear(Driver, locator);
            var element = Driver.FindElementSafe(locator);
            return element != null && element.Displayed;
        }
    }
}