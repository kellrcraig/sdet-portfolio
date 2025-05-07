namespace SauceDemo.Tests.UI.Components
{
    using OpenQA.Selenium;
    using SauceDemo.Tests.Extensions;
    using SauceDemo.Tests.Helpers;

    public class MenuComponent : BaseComponent
    {
        public MenuComponent(IWebDriver driver)
            : base(driver)
        {
        }

        private static By OpenMenuButtonLocator => By.Id("react-burger-menu-btn");

        private static By CloseMenuButtonLocator => By.Id("react-burger-cross-btn");

        private static By InventoryLinkLocator => By.Id("inventory_sidebar_link");

        private static By AboutLinkLocator => By.Id("about_sidebar_link");

        private static By LogoutLinkLocator => By.Id("logout_sidebar_link");

        private static By ResetLinkLocator => By.Id("reset_sidebar_link");

        public void OpenMenu()
        {
            Driver.FindRequiredElement(OpenMenuButtonLocator)?.Click();
        }

        public void CloseMenu()
        {
            Driver.FindRequiredElement(CloseMenuButtonLocator)?.Click();
        }

        public void ClickInventoryLink()
        {
            Driver.FindRequiredElement(InventoryLinkLocator)?.Click();
        }

        public void ClickAboutLink()
        {
            Driver.FindRequiredElement(AboutLinkLocator)?.Click();
        }

        public void ClickLogoutLink()
        {
            WaitHelper.WaitForElementToBeClickable(Driver, Driver.FindElementSafe, LogoutLinkLocator)?.Click();
        }

        public void ClickResetLink()
        {
            Driver.FindRequiredElement(ResetLinkLocator)?.Click();
        }
    }
}