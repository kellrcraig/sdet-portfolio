using OpenQA.Selenium;
namespace SauceDemo.Tests.Pages
{
    public class MenuComponent : Base
    {
        private static By OpenMenuButtonLocator => By.Id("react-burger-menu-btn");
        private static By CloseMenuButtonLocator => By.Id("react-burger-cross-btn");
        private static By InventoryLinkLocator => By.Id("inventory_sidebar_link");
        private static By AboutLinkLocator => By.Id("about_sidebar_link");
        private static By LogoutLinkLocator => By.Id("logout_sidebar_link");
        private static By ResetLinkLocator => By.Id("reset_sidebar_link");
        public MenuComponent(IWebDriver driver) : base(driver) {}
        public void OpenMenu()
        {
            _driver.FindElement(OpenMenuButtonLocator).Click();
        }
        public void CloseMenu()
        {
            _driver.FindElement(CloseMenuButtonLocator).Click();
        }
        public void ClickInventoryLink()
        {
            _driver.FindElement(InventoryLinkLocator).Click();
        }
        public void ClickAboutLink()
        {
            _driver.FindElement(AboutLinkLocator).Click();
        }
        public void ClickLogoutLink()
        {
            _driver.FindElement(LogoutLinkLocator).Click();
        }
        public void ClickResetLink()
        {
            _driver.FindElement(ResetLinkLocator).Click();
        }
    }
}