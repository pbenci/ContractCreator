using OpenQA.Selenium;

namespace ContractCreator
{
    public class Interactions
    {
        public IWebDriver Driver { get; private set; }
        public Waits Wait { get; private set; }

        public Interactions(IWebDriver Driver)
        {
            this.Driver = Driver;
            Wait = new Waits(Driver);
        }

        public void ScrollTo(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", element);
        }

        public void Click(By locator)
        {
            Wait.ForElementToBeClickable(locator);
            IWebElement element = Driver.FindElement(locator);
            ScrollTo(element);
            element.Click();
        }

        public void Write(By locator, string input)
        {
            Wait.ForElementToExist(locator);
            IWebElement element = Driver.FindElement(locator);
            ScrollTo(element);
            element.Clear();
            element.SendKeys(input);
        }
    }
}
