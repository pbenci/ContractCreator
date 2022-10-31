using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ContractCreator
{
    public class Waits
    {
        public IWait<IWebDriver> Wait { get; private set; }
        public IWebDriver Driver { get; private set; }
        public int Timer => 120;

        public Waits(IWebDriver Driver)
        {
            this.Driver = Driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Timer));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public void ForPageToBeLoaded()
        {
            Wait.Until(Driver => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void ForElementToBeClickable(IWebElement Element)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(Element));
        }

        public void ForElementToExist(WebElements Element)
        {
            Wait.Until(ExpectedConditions.ElementExists(Element.Locator));
        }

        public void ForElementToBeInvisible(WebElements Element)
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Element.Locator));
        }

        public void ForElementToBeVisible(WebElements Element)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(Element.Locator));
        }
    }
}