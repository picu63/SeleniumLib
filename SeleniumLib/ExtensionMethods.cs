using OpenQA.Selenium;
using SeleniumLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace SeleniumLib
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Sprawdza czy element istnieje.
        /// </summary>
        /// <param name="by"></param>
        /// <returns>True jeśli element istnieje na aktualnej stronie.</returns>
        public static bool IsElementPresent(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void GoToPage<T>(this INavigation navigation) where T : IPageObject
        {
            var pageType = typeof(T);
            var propertyInfos = pageType.GetFields();
            var basicUrl = propertyInfos.FirstOrDefault(prop => prop.Name == nameof(IPageObject.DefaultUrl))
                ?.GetValue(pageType).ToString();
            navigation.GoToUrl(basicUrl);
        }
    }
}
