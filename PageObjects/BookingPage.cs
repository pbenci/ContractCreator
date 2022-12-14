using OpenQA.Selenium;

namespace ContractCreator
{
    public class BookingPage : BackendMenu
    {
        private WebElements CustomerDropdown => new(Driver, By.Id("booking_customer_customer_prospect_id_chosen"));
        private WebElements CustomerDropdownSearchField => new(Driver, By.ClassName("ui-autocomplete-input"));
        private WebElements CustomerDropdownSearchResult => new(Driver, By.CssSelector("#booking_customer_customer_prospect_id_chosen > div > ul > li:nth-child(2)"));
        private WebElements JobsiteDropdown => new(Driver, By.Id("booking_customer_customer_job_site_id_chosen"));
        private WebElements JobsiteDropdownSearchResult => new(Driver, By.CssSelector("#booking_customer_customer_job_site_id_chosen > div > ul > li:nth-child(2)"));
        private WebElements FinancialBranchDropdown => new(Driver, By.Id("booking_customer_branch_id_chosen"));
        private WebElements FinancialBranchDropdownSearchResult => new(Driver, By.CssSelector("#booking_customer_branch_id_chosen > div > ul > li:nth-child(7)"));
        private WebElements AddNewEquipmentButton => new(Driver, By.CssSelector("#form-booking-items > div > div > div > div > div > span:nth-child(1)"));
        private WebElements AddNewEquipmentModelDropdown => new(Driver, By.Id("advSearch_tab_4_fleet_subcategory_id_chosen"));
        private WebElements AddNewEquipmentModelDropdownSearchField => new(Driver, By.XPath("//*[@id=\"advSearch_tab_4_fleet_subcategory_id_chosen\"]/div/div/input"));
        private WebElements NewEquipmentModelDropdownSearchResult => new(Driver, By.CssSelector("#advSearch_tab_4_fleet_subcategory_id_chosen > div > ul > li:nth-child(2)"));
        private WebElements NewEquipmentApplyFiltersButton => new(Driver, By.CssSelector("#crud_filter_form_tab_4 > div.crud_search_action.p-b-sm.hidden-xs > div > div > div.col-lg-2.hidden-xs > div > button"));
        private WebElements NewEquipmentQuantityField => new(Driver, By.CssSelector("#table-tab_4 > tbody > tr > td.clickable.dt-td-nowrap.dt-right.inputable-td > div.crud_dt_value > div > input"));
        private WebElements NewEquipmentConfirmButton => new(Driver, By.CssSelector("#content-tab_4 > div:nth-child(2) > div.row.m-0 > div > a"));
        private WebElements DepositAmountField => new(Driver, By.Id("booking_payments-invoicing_deposit"));
        private WebElements NewContractConfirmButton => new(Driver, By.CssSelector("#booking-process-tab_3 > div:nth-child(9) > div > div > a:nth-child(3)"));

        public BookingPage(IWebDriver Driver) : base(Driver)
        {
            this.Driver = Driver;
            Interaction = new Interactions(Driver);
            Wait = new(Driver);
        }

        public void GoTo()
        {
            RentalMainMenuButton.Element.Click();
            BookingMenuButton.Element.Click();
            WaitForOverlayToDisappear();
        }

        public void SelectCustomer()
        {
            Interaction.Click(CustomerDropdown.Element);
            Interaction.Write(CustomerDropdownSearchField.Element, "00000005");
            Interaction.Click(CustomerDropdownSearchResult.Element);
            WaitForOverlayToDisappear();
        }

        public void SelectJobsite()
        {
            Interaction.Click(JobsiteDropdown.Element);
            Interaction.Click(JobsiteDropdownSearchResult.Element);
            WaitForOverlayToDisappear();
        }

        public void SelectFinancialBranch()
        {
            Interaction.Click(FinancialBranchDropdown.Element);
            Interaction.Click(FinancialBranchDropdownSearchResult.Element);
            WaitForOverlayToDisappear();
        }

        public void AddNewEquipment()
        {
            Interaction.Click(AddNewEquipmentButton.Element);
            WaitForOverlayToDisappear();
            SelectFromAndToDate();
            SelectModel();
        }

        public void ConfirmContract()
        {
            Interaction.Write(DepositAmountField.Element, "100");
            Interaction.Click(NewContractConfirmButton.Element);
        }

        private void SelectFromAndToDate()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("document.getElementsByName('advSearch_tab_4[date_dal]').item(0).value = '09/01/2023';");
            ((IJavaScriptExecutor)Driver).ExecuteScript("document.getElementsByName('advSearch_tab_4[date_al]').item(0).value = '01/02/2023';");
        }

        private void SelectModel()
        {
            Interaction.Click(AddNewEquipmentModelDropdown.Element);
            Interaction.Write(AddNewEquipmentModelDropdownSearchField.Element, "CAT 300.9");
            Interaction.Click(NewEquipmentModelDropdownSearchResult.Element);
            Interaction.Click(NewEquipmentApplyFiltersButton.Element);
            WaitForOverlayToDisappear();
            Interaction.Write(NewEquipmentQuantityField.Element, "1");
            Interaction.Click(NewEquipmentConfirmButton.Element);
            WaitForOverlayToDisappear();
        }
    }
}