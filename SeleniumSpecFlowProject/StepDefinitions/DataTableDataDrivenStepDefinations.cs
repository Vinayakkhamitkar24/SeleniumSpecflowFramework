using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Assist;

namespace SeleniumSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class DataTableDataDrivenStepDefinations
    {
        private IWebDriver driver;

        public DataTableDataDrivenStepDefinations(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Then(@"Search in google site")]
        public void ThenSearchInGoogleSite(Table table)
        {
            var searchCriteria=table.CreateSet<SearchKeyTestData>();

            foreach (var key in searchCriteria)
            {
                driver.FindElement(By.Name("q")).Clear();
                driver.FindElement(By.Name("q")).SendKeys(key.searchKey);
                Thread.Sleep(3000);
                driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            }

        }



    }

    public class SearchKeyTestData
    {
        public string searchKey { get; set; }
    }
}
