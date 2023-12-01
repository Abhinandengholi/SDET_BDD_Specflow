using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkedInTests.StepDefinitions
{
    [Binding]
    public class LoginStep
    {
        public static IWebDriver? driver;
        private IWebElement? passwordInput;
        [BeforeFeature]

        public static void InitializwBrowser()
        {
            driver = new ChromeDriver();

        }

      
       
        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver.Url = "https://in.linkedin.com/";
        }

        [AfterFeature]
        public static  void CleanupBrowser()
        {
            driver?.Quit();
        }


        [When(@"User will enter username")]
        public void WhenUserWillEnterUsername()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            emailInput.SendKeys("Aswd@ddd");
        }

        [When(@"User will enter password")]
        public void WhenUserWillEnterPassword()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            passwordInput.SendKeys("234a");
            Console.WriteLine(passwordInput.GetAttribute("value"));
        }

        [When(@"User willl click on login button")]
        public void WhenUserWilllClickOnLoginButton()
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js?.ExecuteScript("arguments[0].scrollIntoView(true);", driver?.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(3000);
            js?.ExecuteScript("arguments[0].click();", driver?.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will be redirected to Homepage")]
        public void ThenUserWillBeRedirectedToHomepage()
        {
            Assert.That(driver.Title.Contains("LinkedIn"));
        }
        [Then(@"Error message for Password Length should be thrown")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {
            IWebElement? alertPara = driver?.FindElement(By.XPath("//p[@for='session_password']"));
            string? alerttext = alertPara?.Text;
            Assert.That(alerttext.Equals("The password you provided must have at least 6 characters"));
        }
        [When(@"User willl click on Show Link in the password textbox")]
        public void WhenUserWilllClickOnShowLinkInThePasswordTextbox()
        {
            IWebElement? showButton = driver?.FindElement(By.XPath("//Button[text()='Show']"));
            showButton?.Click();
        }

        [Then(@"the password character should be shown")]
        public void ThenThePasswordCharacterShouldBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("text"));
        }

        [When(@"User willl click on Hidden Link in the password textbox")]
        public void WhenUserWilllClickOnHiddenLinkInThePasswordTextbox()
        {
            IWebElement? hideButton = driver?.FindElement(By.XPath("//Button[text()='Hide']"));
            hideButton?.Click();
        }

        [Then(@"the password character should not be shown")]
        public void ThenThePasswordCharacterShouldNotBeShown()
        {

            Assert.That(passwordInput.GetAttribute("type").Equals("password"));



        }
    }
}
