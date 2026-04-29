using OpenQA.Selenium;

namespace ContractCreator
{
    public class LoginPage : BackendMenu
    {
        private By LoginEmailField => By.Id("signin_username");
        private By LoginPasswordField => By.Id("signin_password");
        private By LoginButton => By.ClassName("btn-primary");

        public LoginPage(IWebDriver Driver) : base(Driver) { }

        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl(Config.BackendUrl);
        }

        public void Login()
        {
            Interaction.Write(LoginEmailField, Config.BackendUsername);
            Interaction.Write(LoginPasswordField, Config.BackendPassword);
            Interaction.Click(LoginButton);
            WaitForOverlayToDisappear();
        }
    }
}
