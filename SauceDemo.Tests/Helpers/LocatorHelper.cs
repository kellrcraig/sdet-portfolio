namespace SauceDemo.Tests.Helpers
{
    using OpenQA.Selenium;

    public static class LocatorHelper
    {
        public static By ById(string id) => By.Id(id);

        public static By ByCssSelector(string selector) => By.CssSelector(selector);

        public static By ByXPath(string xpath) => By.XPath(xpath);

        public static By ByTag(string tag) => By.TagName(tag);

        public static By ByClassName(string className) => By.ClassName(className);

        public static By ByCssDataTestExact(string value) =>
            By.CssSelector(CssSelectorHelper.DataTestExact(value));

        public static By ByCssDataTestEndsWith(string value) =>
            By.CssSelector(CssSelectorHelper.DataTestEndsWith(value));
    }
}