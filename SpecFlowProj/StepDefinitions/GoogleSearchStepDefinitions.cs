using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection.Metadata.Ecma335;
using TechTalk.SpecFlow;

namespace SpecFlowProj.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        public IWebDriver? driver;
        [BeforeScenario] 
        
        public void InitializwBrowser() 
        {
            driver=new ChromeDriver();    
          
        }
        [AfterScenario]
        public void CleanupBrowser()
        {
            driver.Quit();
        }
    
        [Given(@"Google home page should be loaded")]
        public void GivenGoogleHomePageShouldBeLoaded()
        {
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }
        [When(@"Type ""([^""]*)"" in the search text input")]
        public void WhenTypeInTheSearchTextInput(string searchText)
        {
            IWebElement searchInput = driver.FindElement(By.Id("APjFqb"));
            searchInput.SendKeys(searchText);
        }

        [When(@"Click on the google search button")]
        public void WhenClickOnTheGoogleSearchButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement? gsb = fluentWait.Until(d =>
            {
                IWebElement? searchButton = driver?.FindElement(By.Name("btnK"));
                return searchButton.Displayed ? searchButton : null;
            });
            if(gsb!=null)
            {
                gsb.Click();
            }
            
        }

        [Then(@"Results should be displayed on the next page with title ""([^""]*)""")]
        public void ThenResultsShouldBeDisplayedOnTheNextPageWithTitle(string title)
        {
            Assert.That(driver?.Title, Is.EqualTo(title));
        }


        [When(@"Click on the IMFL button")]
        public void WhenClickOnTheIMFLButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement? imfl = fluentWait.Until(d =>
            {
                IWebElement? searchButton = driver?.FindElement(By.Name("btnI"));
                return searchButton.Displayed ? searchButton : null;
            });
            if (imfl != null)
            {
                imfl.Click();
            }
        }

        [Then(@"the results should be redirected to a new page with title ""([^""]*)""")]
        public void ThenTheResultsShouldBeRedirectedToANewPageWithTitle(string title)
        {
            Assert.That(driver.Title.Contains(title));
        }

    }
}
