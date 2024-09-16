using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class DataDrivenStepDefinations
    {
        private IWebDriver driver;

        public DataDrivenStepDefinations(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Then(@"Search Texts '([^']*)'")]
        public void ThenSearchTexts(string searchKey)
        {
            driver.FindElement(By.Name("q")).SendKeys(searchKey);
            Thread.Sleep(3000);
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
        }

    }
}
