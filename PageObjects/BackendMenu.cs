using OpenQA.Selenium;
using System;

namespace ContractCreator
{
    public class BackendMenu
    {
        public IWebDriver Driver { get; set; }
        public Interactions Interaction { get; set; }
        public Waits Wait { get; set; }
        public By RentalMainMenuButton => By.Id("voceMenu_rentals");
        public By BookingMenuButton => By.Id("voceMenu_booking");
        public By Overlay => By.CssSelector("div > svg");
        public By CloseAllTabsButton => By.Id("close-all-tabs");

        public BackendMenu(IWebDriver Driver)
        {
            this.Driver = Driver;
            Interaction = new(Driver);
            Wait = new(Driver);
        }

        public void WaitForOverlayToDisappear()
        {
            try {
                Wait.ForElementToBeInvisible(Overlay);
            } catch (WebDriverTimeoutException)
        }
    }
}
