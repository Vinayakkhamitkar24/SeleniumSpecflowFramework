using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowProject.Pages
{
    public class SearchPage
    {
        private IWebDriver driver;

        public SearchPage(IWebDriver driver) 
        { 
            this.driver = driver;
        }


        By searchTxtBox = By.Name("search_query");

        public ResultPage searchText(string searchTxt)
        {

            driver.FindElement(searchTxtBox).SendKeys(searchTxt);
            driver.FindElement(searchTxtBox).SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            return new ResultPage(driver);
        }
    }

    
}
