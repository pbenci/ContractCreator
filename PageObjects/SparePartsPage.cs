using OpenQA.Selenium;

namespace ContractCreator
{
    public class SparePartsPage : BackendMenu
    {
        private Waits Wait { get; set; }
        private WebElements PageTitle => new(Driver, By.CssSelector("div.breadcrumb-wrapper.lter.b-b.wrapper-md > h1"));
        private WebElements AddNewSparePartButton => new(Driver, By.CssSelector("div.bg-white.col-12.col-sm-8.col-sm-push-4.p-t-10-xs > div > a"));
        private WebElements PartNumberField => new(Driver, By.Id("spare_part_part_number"));
        private WebElements SaveNewSparePartButton => new(Driver, By.CssSelector("a.btn.btn-primary.bootbox-accept"));
        private WebElements BrandNewSparePartDropdown => new(Driver, By.CssSelector("#spare_part_brand_id_chosen > a"));
        private WebElements BrandNewSparePartCATOptionDropdown => new(Driver, By.CssSelector("#spare_part_brand_id_chosen > div > ul > li:nth-child(2)"));

        public SparePartsPage(IWebDriver Driver) : base(Driver)
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
            FleetMainMenuButton.Element.Click();
            SparePartsMenuButton.Element.Click();
        }

        public bool IsUserInSparePartsList()
        {
            return PageTitle.Element.Text.Contains("Spare parts");
        }

        public void AddNewSparePart()
        {
            AddNewSparePartButton.Element.Click();
            Interaction.Write(PartNumberField.Element, "asda");
            Interaction.Click(BrandNewSparePartDropdown.Element);
            Interaction.Click(BrandNewSparePartCATOptionDropdown.Element);
            Interaction.Click(SaveNewSparePartButton.Element);
        }
    }
}