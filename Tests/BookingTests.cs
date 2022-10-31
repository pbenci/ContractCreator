using NUnit.Framework;

namespace ContractCreator
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class BookingTests : BaseTests
    {
        [SetUp]
        public void BookingTestsSetup()
        {
            BookingPage = new(Driver);
            LoginPage.LoginWithRightData();
            BookingPage.GoTo();
        }

        [Test, Repeat(1500), Retry(5), Category("Smoke"), TestCase(TestName = "Backend user can create contract")]
        public void CanCreateContract()
        {
            BookingPage.SelectCustomer();
            BookingPage.SelectJobsite();
            BookingPage.SelectFinancialBranch();
            BookingPage.AddNewEquipment();
            BookingPage.ConfirmContract();
        }
    }
}