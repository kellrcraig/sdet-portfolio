using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Tests.TestData;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests.Tests.Login
{
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver); 
        }

        [Test]
        public void StandardUser_AttemptsLogin_Successfully()
        {
            _loginPage.NavigateTo();
            _loginPage.Login(LoginUsers.StandardUser, LoginUsers.CorrectPassword);

            Assert.That(_driver.Url, Does.Contain("/inventory"));
        }

        [Test]
        public void LockedOutUser_AttemptsLogin_Unsuccessfully()
        {
            _loginPage.NavigateTo();
            _loginPage.Login(LoginUsers.LockedOutUser, LoginUsers.CorrectPassword);
            Assert.Multiple(() =>
            {
                Assert.That(_driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
                Assert.That(_loginPage.ErroMessageIsVisible(), Is.True);
                Assert.That(_loginPage.GetErrorMessageText, Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
            });
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}