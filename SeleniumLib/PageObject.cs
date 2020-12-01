using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumLib
{
    public abstract class PageObject : IPageObject
    {
        protected PageObject(IWebDriver driver)
        {
            Driver = driver;
        }

        public virtual IWebDriver Driver { get; set; }

        public abstract string DefaultUrl { get; set; }
    }
}
