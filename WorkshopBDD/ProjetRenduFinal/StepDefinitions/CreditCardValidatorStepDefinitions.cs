using OpenQA.Selenium;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using WorkshopBDD.ComponentHelper;

namespace ProjetRenduFinal.StepDefinitions
{
    [Binding]
    public class CreditCardValidatorStepDefinitions
    {
        [Given(@"user fills the three inputs")]
        public void GivenUserFillsTheThreeInputs()
        {
            TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"), "1164123598564785");
            TextBoxHelper.TypeInTextBox(By.Id("expirationDate"), "12/2020");
            TextBoxHelper.TypeInTextBox(By.Id("cvc"), "214");

        }

        [Given(@"credit card number is sixteen digits long")]
        public void GivenCreditCardNumberIsSixteenDigitsLong()
        {
            string value = GenericHelper.GetElement(By.Id("creditCardNumber")).GetAttribute("value");
            Assert.IsTrue(value.Length == 16);
        }

        [Given(@"expiration date is at format MM/YYYY")]
        public void GivenExpirationDateIsAtFormatMMYYYY()
        {
            string pattern = @"^\d{2}[\/]\d{4}$";
            string value = GenericHelper.GetElement(By.Id("expirationDate")).GetAttribute("value");
            bool verify = Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase);
            Assert.IsTrue(verify);
        }

        [Given(@"cvc is three digits long")]
        public void GivenCvcIsThreeDigitsLong()
        {
            string value = GenericHelper.GetElement(By.Id("cvc")).GetAttribute("value");
            Assert.IsTrue(value.Length == 3);
        }

        [When(@"submit button is pressed")]
        public void WhenSubmitButtonIsPressed()
        {
            ButtonHelper.ClickButton(By.Id("submit"));
        }

        [Then(@"user is on page paymentConfirmed")]
        public void ThenUserIsOnPagePaymentConfirmed()
        {
            Assert.AreEqual(PageHelper.GetPageUrl(), "http://localhost/final/paymentConfirmed.html");
        }

        [Given(@"credit card number is not sixteen digits long")]
        public void GivenCreditCardNumberIsNotSixteenDigitsLong()
        {
            TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"), "123");
            string value = GenericHelper.GetElement(By.Id("creditCardNumber")).GetAttribute("value");
            Assert.IsTrue(value.Length != 16);
        }

        [Then(@"user is on homePage")]
        public void ThenUserIsOnHomePage()
        {
            Assert.AreEqual(PageHelper.GetPageUrl(), "http://localhost/final/Workshop.html");
        }

        [Given(@"expiration date is not at format MM/YYYY")]
        public void GivenExpirationDateIsNotAtFormatMMYYYY()
        {
            TextBoxHelper.ClearTextBox(By.Id("expirationDate"));
            string pattern = @"^\d{2}[\/]\d{4}$";
            string value = GenericHelper.GetElement(By.Id("expirationDate")).GetAttribute("value");
            bool verify = Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase);
            Assert.IsFalse(verify);
           

        }

        [Given(@"cvc is not three digits long")]
        public void GivenCvcIsNotThreeDigitsLong()
        {
            TextBoxHelper.TypeInTextBox(By.Id("cvc"), "246565414");
            string value = GenericHelper.GetElement(By.Id("cvc")).GetAttribute("value");
            Assert.IsTrue(value.Length != 3);
        }
    }
}
