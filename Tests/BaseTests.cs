using NUnit.Framework;
using OpenQA.Selenium;

namespace ContractCreator
{
    public class BaseTests
    {
        protected IWebDriver Driver { get; set; }
        protected Browsers Browser => new();
        protected LoginPage LoginPage { get; set; }
        protected BookingPage BookingPage { get; set; }
        protected Screenshots Screenshot { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = Browser.LaunchChrome();
            Driver.Manage().Window.Maximize();
            LoginPage = new(Driver);
            BookingPage = new(Driver);
            Screenshot = new(Driver);
            LoginPage.GoToUrl();
        }

        [TearDown]
        public void TearDown()
        {
            //Screenshot.Take();
            Driver.Quit();
        }
    }
}