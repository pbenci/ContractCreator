using NUnit.Framework;
using System.Threading;

namespace ContractCreator
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class BookingTests : BaseTests
    {
        private BookingPage BookingPage { get; set; }

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
            Thread.Sleep(5000);
        }
    }
}