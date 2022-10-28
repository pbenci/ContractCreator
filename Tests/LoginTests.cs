using NUnit.Framework;

namespace ContractCreator
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTests : BaseTests
    {
        [Test, Retry(5), Category("Smoke"), TestCase(TestName = "Backend user with right username and pwd can login")]
        public void BackendUserCanLoginWithRightData()
        {
            LoginPage.LoginWithRightData();
            Assert.IsTrue(LoginPage.IsBackendMenuDisplayed());
        }

        [Test, Retry(5), Category("Smoke"), TestCase(TestName = "Backend user with wrong username and pwd can't login")]
        public void BackendUserCantLoginWithWrongData()
        {
            LoginPage.LoginWithWrongData();
            Assert.IsTrue(LoginPage.IsWrongUserOrPasswordToastDisplayed());
        }
    }
}