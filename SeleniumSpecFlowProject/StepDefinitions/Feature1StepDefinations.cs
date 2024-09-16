using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class Feature1StepDefinations
    {
        private IWebDriver driver;
        public string expectedTitle = "Testers Talk - Google Search";

        public Feature1StepDefinations(IWebDriver driver)
        {
           this.driver = driver;
        }

        [Given(@"Open Browser")]
        public void GivenOpenBrowser()
        {
           // driver=new ChromeDriver();
           // driver.Manage().Window.Maximize();
        }


        [When(@"Enter the URL")]
        public void WhenEnterTheURL()
        {
            driver.Url = "https:google.com";
            Thread.Sleep(5000);
        }

        [Then(@"Search Text")]
        public void ThenSearchText()
        {
            driver.FindElement(By.Name("q")).SendKeys("Testers Talk");
            Thread.Sleep(3000);
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
           // driver.Quit();
        }

        [Then(@"Verify Page Title")]
        public void ThenVerifyPageTitle()
        {
            Thread.Sleep(3000);
            String actualTitle=driver.Title;

            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
            //Assert.AreEqual(expectedTitle, actualTitle);
           
        }

    }
}
