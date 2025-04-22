using OpenQA.Selenium;
namespace SauceDemo.Tests.Pages
{
    public class MenuPageObject : BasePageObject
    {
        private static By OpenMenuButtonLocator => By.Id("react-burger-menu-btn");
        private static By CloseMenuButtonLocator => By.Id("react-burger-cross-btn");
        private static By InventoryLinkLocator => By.Id("inventory_sidebar_link");
        private static By AboutLinkLocator => By.Id("about_sidebar_link");
        private static By LogoutLinkLocator => By.Id("logout_sidebar_link");
        private static By ResetLinkLocator => By.Id("reset_sidebar_link");
        public MenuPageObject(IWebDriver driver) : base(driver) {}
        public void OpenMenu()
        {
            FindElementSafe(OpenMenuButtonLocator)?.Click();
        }
        public void CloseMenu()
        {
            FindElementSafe(CloseMenuButtonLocator)?.Click();
        }
        public void ClickInventoryLink()
        {
            FindElementSafe(InventoryLinkLocator)?.Click();
        }
        public void ClickAboutLink()
        {
            FindElementSafe(AboutLinkLocator)?.Click();
        }
        public void ClickLogoutLink()
        {
            FindElementSafe(LogoutLinkLocator)?.Click();
        }
        public void ClickResetLink()
        {
            FindElementSafe(ResetLinkLocator)?.Click();
        }
    }
}