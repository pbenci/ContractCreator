using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;

namespace ContractCreator
{
    public class Screenshots
    {
        protected IWebDriver Driver;

        public Screenshots(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public void Take()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var runtime = DateTime.Now.ToString("dd-MM-yyyy" + " " + "HH_mm_ss_fff");
            string fileName;
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)Driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                fileName = "PASSED" + " " + testName + " " + runtime + ".Png";
            }
            else
            {
                fileName = "FAILED" + " " + testName + " " + runtime + ".Png";
            }
            screenshot.SaveAsFile(fileName);
            TestContext.AddTestAttachment(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + fileName);
        }
    }
}