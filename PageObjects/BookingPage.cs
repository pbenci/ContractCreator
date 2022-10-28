using OpenQA.Selenium;
using System;

namespace ContractCreator
{
    public class BookingPage : BackendMenu
    {
        private Waits Wait { get; set; }

        public BookingPage(IWebDriver Driver) : base(Driver)
        {
            this.Driver = Driver;
            Interaction = new Interactions(Driver);
            Wait = new(Driver);
        }

        public void GoTo()
        {
            if (Overlay.Elements.Count > 0)
            {
                Wait.ForElementToBeInvisible(Overlay);
            }
            RentalMainMenuButton.Element.Click();
            BookingMenuButton.Element.Click();
        }
    }
}