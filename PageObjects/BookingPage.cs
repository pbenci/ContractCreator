using OpenQA.Selenium;
using System;

namespace ContractCreator
{
    public class BookingPage : BackendMenu
    {
        private Waits Wait { get; set; }
        private WebElements CustomerDropdown => new(Driver, By.Id("booking_customer_customer_prospect_id_chosen"));
        private WebElements CustomerDropdownSearchField => new(Driver, By.ClassName("ui-autocomplete-input"));
        private WebElements CustomerDropdownSearchResult => new(Driver, By.CssSelector("#booking_customer_customer_prospect_id_chosen > div > ul > li:nth-child(2)"));
        private WebElements JobsiteDropdown => new(Driver, By.Id("booking_customer_customer_job_site_id_chosen"));
        private WebElements JobsiteDropdownSearchResult => new(Driver, By.CssSelector("#booking_customer_customer_job_site_id_chosen > div > ul > li:nth-child(2)"));

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

        public void SelectCustomer()
        {
            Interaction.Click(CustomerDropdown.Element);
            Interaction.Write(CustomerDropdownSearchField.Element, "00000005");
            Interaction.Click(CustomerDropdownSearchResult.Element);
        }

        public void SelectJobsite()
        {
            Interaction.Click(JobsiteDropdown.Element);
            Interaction.Click(JobsiteDropdownSearchResult.Element);
        }
    }
}