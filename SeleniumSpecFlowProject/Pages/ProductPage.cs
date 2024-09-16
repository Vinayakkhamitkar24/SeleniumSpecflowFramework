using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowProject.Pages
{
    public class ProductPage
    {
        private IWebDriver driver;
        public ProductPage(IWebDriver driver) 
        {
            this.driver = driver;

        }

        private By checkoutBtn = By.PartialLinkText("Checkout");
        private By productTitldLbl = By.CssSelector("h4 a");
        private By addBtn = By.CssSelector(".card-footer button");
        private By shopLink = By.LinkText("Shop");
        private By products = By.TagName("app-card");

        public void addProductToCart(String[] expectedProducts)
        {
            driver.FindElement(shopLink).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(checkoutBtn));
            IList<IWebElement> productList = driver.FindElements(products);
            foreach (IWebElement product in productList)
            {
                string actualTitle = product.FindElement(productTitldLbl).Text;

                if (expectedProducts.Contains(actualTitle))
                {
                    product.FindElement(addBtn).Click();
                }
            }
        }

        
    }
}
