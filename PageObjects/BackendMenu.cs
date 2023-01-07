using OpenQA.Selenium;
using System;

namespace ContractCreator
{
    public class BackendMenu
    {
        public IWebDriver Driver { get; set; }
        public Interactions Interaction { get; set; }
        public Waits Wait { get; set; }
        public WebElements RentalMainMenuButton => new(Driver, By.Id("voceMenu_rentals"));
        public WebElements BookingMenuButton => new(Driver, By.Id("voceMenu_booking"));        
        public WebElements FleetMainMenuButton => new(Driver, By.Id("voceMenu_fleet"));
        public WebElements SparePartsMenuButton => new(Driver, By.Id("voceMenu_spare_part"));
        public WebElements Overlay => new(Driver, By.CssSelector("div > svg"), 2);
        public WebElements CloseAllTabsButton => new(Driver, By.Id("close-all-tabs"));
        public WebElements ConfirmClosingAllTabsButton => new(Driver, By.CssSelector("div.bootbox.modal.fade.bootbox-confirm.in > div > div > div.modal-footer > button.btn.btn-primary"));
        public string ActiveTabId => Driver.FindElement(By.Id("tab-header")).FindElement(By.ClassName("active")).GetAttribute("id");
        public WebElements CrudPageNumberButton => new(Driver, By.LinkText(string.Format($"{CrudNextPage}")));
        protected int CrudNextPage { get; set; }

        public BackendMenu(IWebDriver Driver)
        {
            this.Driver = Driver;
            Interaction = new(Driver);
            Wait = new(Driver);
        }

        public void WaitForOverlayToDisappear()
        {
            try
            {
                Console.WriteLine("Yeah");
                Wait.ForElementToExist(Overlay);
                Wait.ForElementToBeInvisible(Overlay);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nope");
            }
        }

        //public void WaitForOverlayToDisappear()
        //{
        //    if (Overlay.Elements.Count > 0)
        //    {
        //        Console.WriteLine("Yeah");
        //        Wait.ForElementToBeInvisible(Overlay);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Nope");
        //    }
        //}

        public void CloseAllTabs()
        {
            if (CloseAllTabsButton.Element.Displayed)
            {
                Interaction.Click(CloseAllTabsButton.Element);
                Interaction.Click(ConfirmClosingAllTabsButton.Element);
            }
        }
    }
}