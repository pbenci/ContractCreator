using OpenQA.Selenium;
using System;

namespace ContractCreator
{
    public class LoginPage : BackendMenu
    {
        private WebElements LoginEmailField => new(Driver, By.Id("signin_username"));
        private WebElements LoginPasswordField => new(Driver, By.Id("signin_password"));
        private WebElements LoginButton => new(Driver, By.ClassName("btn-primary"));
        private WebElements Toast => new(Driver, By.ClassName("toast-message"));

        public LoginPage(IWebDriver Driver) : base(Driver)
        {
            this.Driver = Driver;
            Interaction = new Interactions(Driver);
        }

        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl("https://cgte-it.cdrs-alias2k.com/");
        }

        public void LoginWithRightData()
        {
            Interaction.Write(LoginEmailField.Element, Config.BackendUsername);
            Interaction.Write(LoginPasswordField.Element, Config.BackendPassword);
            Interaction.Click(LoginButton.Element);
        }

        public void LoginWithWrongData()
        {
            Interaction.Write(LoginEmailField.Element, "2");
            Interaction.Write(LoginPasswordField.Element, "3");
            Interaction.Click(LoginButton.Element);
        }

        public bool IsBackendMenuDisplayed()
        {
            if (RentalMainMenuButton.Element.Displayed)
            {
                Console.WriteLine("Backend user logged in successfully");
            }
            else
            {
                Console.WriteLine("Backend user failed to login");
            }
            return RentalMainMenuButton.Element.Displayed;
        }

        public bool IsWrongUserOrPasswordToastDisplayed()
        {
            Console.WriteLine("The toast with an error has been displayed");
            return Toast.Element.Text.Contains("The username and/or password is invalid.");
        }
    }
}