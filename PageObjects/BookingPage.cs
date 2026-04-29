using OpenQA.Selenium;

namespace ContractCreator
{
    public class BookingPage : BackendMenu
    {
        private By CustomerDropdown => By.Id("booking_customer_customer_prospect_id_chosen");
        private By CustomerDropdownSearchField => By.ClassName("ui-autocomplete-input");
        private By CustomerDropdownSearchResult => By.CssSelector("#booking_customer_customer_prospect_id_chosen > div > ul > li:nth-child(2)");
        private By JobsiteDropdown => By.Id("booking_customer_customer_job_site_id_chosen");
        private By JobsiteDropdownSearchResult => By.CssSelector("#booking_customer_customer_job_site_id_chosen > div > ul > li:nth-child(2)");
        private By FinancialBranchDropdown => By.Id("booking_customer_branch_id_chosen");
        private By FinancialBranchDropdownSearchResult => By.CssSelector("#booking_customer_branch_id_chosen > div > ul > li:nth-child(7)");
        private By AddNewEquipmentButton => By.CssSelector("#form-booking-items > div > div > div > div > div > span:nth-child(1)");
        private By AddNewEquipmentModelDropdown => By.Id("advSearch_tab_4_fleet_subcategory_id_chosen");
        private By AddNewEquipmentModelDropdownSearchField => By.XPath("//*[@id=\"advSearch_tab_4_fleet_subcategory_id_chosen\"]/div/div/input");
        private By NewEquipmentModelDropdownSearchResult => By.CssSelector("#advSearch_tab_4_fleet_subcategory_id_chosen > div > ul > li:nth-child(2)");
        private By NewEquipmentApplyFiltersButton => By.CssSelector("#crud_filter_form_tab_4 > div.crud_search_action.p-b-sm.hidden-xs > div > div > div.col-lg-2.hidden-xs > div > button");
        private By NewEquipmentQuantityField => By.CssSelector("#table-tab_4 > tbody > tr > td.clickable.dt-td-nowrap.dt-right.inputable-td > div.crud_dt_value > div > input");
        private By NewEquipmentConfirmButton => By.CssSelector("#content-tab_4 > div:nth-child(2) > div.row.m-0 > div > a");
        private By DepositAmountField => By.Id("booking_payments-invoicing_deposit");
        private By NewContractConfirmButton => By.CssSelector("#booking-process-tab_3 > div:nth-child(9) > div > div > a:nth-child(3)");

        public BookingPage(IWebDriver Driver) : base(Driver)
        {
        }

        public void GoTo()
        {
            Interaction.Click(RentalMainMenuButton);
            Interaction.Click(BookingMenuButton);
            WaitForOverlayToDisappear();
        }

        public void SelectCustomer(string customerId = "00000005")
        {
            Interaction.Click(CustomerDropdown);
            Interaction.Write(CustomerDropdownSearchField, customerId);
            Interaction.Click(CustomerDropdownSearchResult);
            WaitForOverlayToDisappear();
        }

        public void SelectJobsite()
        {
            Interaction.Click(JobsiteDropdown);
            Interaction.Click(JobsiteDropdownSearchResult);
            WaitForOverlayToDisappear();
        }

        public void SelectFinancialBranch()
        {
            Interaction.Click(FinancialBranchDropdown);
            Interaction.Click(FinancialBranchDropdownSearchResult);
            WaitForOverlayToDisappear();
        }

        public void AddNewEquipment()
        {
            Interaction.Click(AddNewEquipmentButton);
            WaitForOverlayToDisappear();
            SelectFromAndToDate();
            SelectModel();
        }

        public void ConfirmContract()
        {
            Interaction.Write(DepositAmountField, "100");
            Interaction.Click(NewContractConfirmButton);
        }

        private void SelectFromAndToDate()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("document.getElementsByName('advSearch_tab_4[date_dal]').item(0).value = '09/01/2023';");
            ((IJavaScriptExecutor)Driver).ExecuteScript("document.getElementsByName('advSearch_tab_4[date_al]').item(0).value = '01/02/2023';");
        }

        private void SelectModel()
        {
            Interaction.Click(AddNewEquipmentModelDropdown);
            Interaction.Write(AddNewEquipmentModelDropdownSearchField, "CAT 300.9");
            Interaction.Click(NewEquipmentModelDropdownSearchResult);
            Interaction.Click(NewEquipmentApplyFiltersButton);
            WaitForOverlayToDisappear();
            Interaction.Write(NewEquipmentQuantityField, "1");
            Interaction.Click(NewEquipmentConfirmButton);
            WaitForOverlayToDisappear();
        }
    }
}
