using OpenQA.Selenium;

namespace ContractCreator
{
    public class Interactions
    {
        public IWebDriver Driver { get; private set; }
        public Waits Wait { get; private set; }
        public int LoadingOverlay { get; private set; }
        public string ActiveTabId
        {
            get
            {
                if (Driver.FindElement(By.Id("tab-header")).FindElements(By.ClassName("active")).Count > 0)
                {
                    return Driver.FindElement(By.Id("tab-header")).FindElement(By.ClassName("active")).GetAttribute("id");
                }
                else
                {
                    return "";
                }
            }
        }

        public WebElements ProcessingOverlay => new(Driver, By.Id(string.Format($"table-{ActiveTabId}_processing")));

        public Interactions(IWebDriver Driver)
        {
            this.Driver = Driver;
            Wait = new Waits(Driver);
        }

        public void ScrollTo(IWebElement Element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", Element);
        }

        public void Click(IWebElement Element)
        {
            Wait.ForElementToBeClickable(Element);
            ScrollTo(Element);
            Element.Click();
        }

        public void Write(IWebElement Element, string Input)
        {
            Wait.ForElementToBeClickable(Element);
            ScrollTo(Element);
            Element.Clear();
            Element.SendKeys(Input);
        }

        public void SwitchCrudPage(IWebElement Element)
        {
            Element.Click();
            Wait.ForElementToBeInvisible(ProcessingOverlay);
        }
    }
}