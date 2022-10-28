using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;

namespace ContractCreator
{
    public class WebElements : IWebElement
    {
        private IWebElement element;
        private IList<IWebElement> elements;
        public IWebDriver Driver { get; private set; }
        public By Locator { get; private set; }
        public IWebElement Element
        {
            get { return element; }
            set { element = value; }
        }

        public IList<IWebElement> Elements
        {
            get { return elements; }
            set { elements = value; }
        }

        public WebElements(IWebDriver Driver, By Locator)
        {
            this.Driver = Driver;
            this.Locator = Locator;
            int retryCounter = 0;

            while (true)
            {
                try
                {
                    Element = Driver.FindElement(Locator);
                    break;
                }
                catch (NoSuchElementException)
                {
                    if (retryCounter < 5)
                    {
                        retryCounter++;
                        Thread.Sleep(500);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        public WebElements(IWebDriver Driver, By Locator, int lo)
        {
            this.Driver = Driver;
            this.Locator = Locator;
            Elements = Driver.FindElements(Locator);
        }

        public string TagName => throw new NotImplementedException();

        public string Text => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }
    }
}