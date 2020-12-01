using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLib
{
    /// <summary>
    /// https://www.youtube.com/watch?v=9xOpl1BhjUc&list=PL6tu16kXT9PqKSouJUV6sRVgmcKs-VCqo&index=5
    /// </summary>
    public static class SetMethods
    {

        /// <summary>
        /// Extended method or entering text in the control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        /// <summary>
        /// Click into a button, checkbox, option etc
        /// </summary>
        /// <param name="element"></param>
        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Selecting a drop down control element by string value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void SelectDropDown(this IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }
        /// <summary>
        /// Selecting a drop down control element by integer value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value">Index of </param>
        public static void SelectDropDown(this IWebElement element, int value)
        {
            new SelectElement(element).SelectByIndex(value);
        }
    }
}
