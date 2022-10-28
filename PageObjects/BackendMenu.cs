using OpenQA.Selenium;

namespace ContractCreator
{
    public class BackendMenu
    {
        public IWebDriver Driver { get; set; }
        public Interactions Interaction { get; set; }
        public WebElements RentalMainMenuButton => new(Driver, By.Id("voceMenu_rentals"));
        public WebElements FleetMainMenuButton => new(Driver, By.Id("voceMenu_fleet"));
        public WebElements SparePartsMenuButton => new(Driver, By.Id("voceMenu_spare_part"));
        public WebElements Overlay => new(Driver, By.ClassName("blockOverlay"), 2);
        public WebElements CloseAllTabsButton => new(Driver, By.Id("close-all-tabs"));
        public WebElements ConfirmClosingAllTabsButton => new(Driver, By.CssSelector("div.bootbox.modal.fade.bootbox-confirm.in > div > div > div.modal-footer > button.btn.btn-primary"));
        public string ActiveTabId => Driver.FindElement(By.Id("tab-header")).FindElement(By.ClassName("active")).GetAttribute("id");
        public WebElements CrudPageNumberButton => new(Driver, By.LinkText(string.Format($"{CrudNextPage}")));
        protected int CrudNextPage { get; set; }

        public BackendMenu(IWebDriver Driver)
        {
            this.Driver = Driver;
            Interaction = new Interactions(Driver);
        }

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