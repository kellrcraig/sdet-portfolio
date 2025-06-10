namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;
    using SauceDemo.Tests.UI.Shared;

    public class MenuComponent : UiObjectBase
    {
        private readonly By menuLocator = LocatorHelper.ByClassName("bm-menu-wrap");

        public MenuComponent(IWebDriver driver)
            : base(driver)
        {
        }

        public void OpenMenu()
        {
            Driver.FindElementRequired(LocatorHelper.ById("react-burger-menu-btn"))?.Click();
        }

        public void CloseMenu()
        {
            WaitHelper.WaitForElementToBeClickableInDom(Driver, LocatorHelper.ById("react-burger-cross-btn"))?.Click();
            WaitHelper.WaitForElementToDisappear(Driver, menuLocator);
        }

        public bool MenuIsVisible()
        {
            return Driver.FindElementSafe(menuLocator).IsVisible();
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
    }
}