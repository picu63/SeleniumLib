using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumLib
{
    public class SelDriver
    {
        public static void CreateNew(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        public static IWebDriver WebDriver { get; private set; }
    }
}