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
        public int Timer => 30;

        public Waits(IWebDriver Driver)
        {
            this.Driver = Driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Timer));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public void ForPageToBeLoaded()
        {
            Wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void ForElementToBeClickable(By locator)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void ForElementToExist(By locator)
        {
            Wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public void ForElementToBeInvisible(By locator)
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void ForElementToBeVisible(By locator)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
