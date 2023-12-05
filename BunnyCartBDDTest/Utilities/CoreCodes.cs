using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Page;
using OpenQA.Selenium.Edge;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BunnyCartBDDTest.Utilities
{
    internal class CoreCodes
    {
       public IWebDriver driver;
        protected void TakeScreenshot(IWebDriver driver)
        {
            ITakesScreenshot its = (ITakesScreenshot)driver;
            Screenshot screenshot = its.GetScreenshot();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string filepath = currDir + "/Screenshot/ss_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            screenshot.SaveAsFile(filepath);
            Console.WriteLine("Taken ss");
        }
        protected void LogTestResult(string testName, string result, string errorMessage = null)
        {
            Log.Information(result);
            if (errorMessage == null)
            {
                Log.Information(testName + "passed");
               
            }
            else
            {
                Log.Error($"Test failed for{testName}.\n Exception: \n{errorMessage}");
              
            }
        }

    }
}