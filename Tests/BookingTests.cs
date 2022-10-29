using NUnit.Framework;
using System.Threading;

namespace ContractCreator
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class BookingTests : BaseTests
    {
        [SetUp]
        public void SparePartsTestsSetup()
        {
            BookingPage = new(Driver);
            LoginPage.LoginWithRightData();
            BookingPage.GoTo();
        }
        [Test, Retry(5), Category("Smoke"), TestCase(TestName = "Backend user with right username and pwd can login")]
        public void BackendUserCanLoginWithRightData()
        {
            BookingPage.SelectCustomer();
            BookingPage.SelectJobsite();
            BookingPage.SelectFinancialBranch();
            Thread.Sleep(5000);
        }
    }
}