using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class DataDriven
    {
        private IWebDriver driver;

        public DataDriven(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Then(@"Search Text (.*)")]
        public void ThenSearchTextSpecflowByTestersTalk(String searchKey)
        {
            driver.FindElement(By.Name("q")).SendKeys(searchKey);
            Thread.Sleep(3000);
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
        }



    }
}
