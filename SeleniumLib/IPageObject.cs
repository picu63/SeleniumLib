using OpenQA.Selenium;

namespace SeleniumLib
{
    public interface IPageObject
    {
        IWebDriver Driver { get; }
        string DefaultUrl { get; }

        void GoToDefaultUrl()
        {
            Driver.Navigate().GoToUrl(DefaultUrl);
        }
    }
}