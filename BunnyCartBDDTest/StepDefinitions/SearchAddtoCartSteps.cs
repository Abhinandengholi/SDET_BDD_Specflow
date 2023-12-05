using BunnyCartBDDTest.Hooks;
using BunnyCartBDDTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Security.Cryptography;
using TechTalk.SpecFlow;

namespace BunnyCartBDDTest.StepDefinitions
{
    [Binding]
    internal class SearchAddtoCartSteps : CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;

        [Given(@"User will be on Homepage")]
        public void GivenUserWillBeOnHomepage()
        {
            driver.Url = "https://www.bunnycart.com/";
            driver.Manage().Window.Maximize();
        }

        [When(@"User will type the '([^']*)' in the searchbox")]
        public void WhenUserWillTypeTheInTheSearchbox(string searchtext)
        {
            IWebElement? searchInput = driver?.FindElement(By.Id("search"));
            searchInput?.SendKeys(searchtext);
            searchInput?.SendKeys(Keys.Enter);
        }



        [Then(@"Search Results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            TakeScreenshot(driver);
            try
            {
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test Passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }
        }
        [Then(@"Heading should have '([^']*)'")]
        public void ThenHeadingShouldHave(string searchtext)
        {
            IWebElement searchheading = driver.FindElement(By.XPath("//h1[@class='page-title']"));
            TakeScreenshot(driver);
            try
            {
                Assert.That(searchheading.Text, Does.Contain(searchtext));
                LogTestResult("Search Test", "Search Test Passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);

            }
        }



        [When(@"User selects a '([^']*)'")]
        public void WhenUserSelectsA(string pId)
        {
            driver.FindElement(By.XPath("(//div[@data-container='product-grid'])[" + pId + "]")).Click();
        }

        [Then(@"Product page '([^']*)' is loaded")]
        public void ThenProductPageIsLoaded(string searchtext)
        {
            TakeScreenshot(driver);
            try
            {
                Assert.That(driver.Title, Does.Contain(searchtext));
                LogTestResult("Search Test", "Search Test Passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }
        }

        [When(@"User Will select quantity of the product")]
        public void WhenUserWillSelectQuantityOfTheProduct()
        {
            driver.FindElement(By.XPath("//a[@class='qty-inc']")).Click();
            Thread.Sleep(10000);
        }


        [When(@"User add the product to  cart")]
        public void WhenUserAddTheProductToCart()
        {

            driver.FindElement(By.XPath("//button[@class='action primary tocart']")).Click();
            Thread.Sleep(10000);
        }
        [Then(@"Product'([^']*)' added to cart")]
        public void ThenProductAddedToCart(string water)
        {
            driver.FindElement(By.XPath("//a[contains(@class,'showcart')]")).Click();
            Thread.Sleep(3000);

        }


    }

}