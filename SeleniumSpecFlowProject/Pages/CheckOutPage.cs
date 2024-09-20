using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowProject.Pages
{
    public class CheckOutPage
    {

        private IWebDriver driver;
        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        private By countryOptions = By.XPath("//div[@class='suggestions']//ul//li//a");
        private By CheckoutOption = By.PartialLinkText("Checkout");
        private By addedCartProducts = By.CssSelector(".media-body h4 a");

        private By CheckoutBtn = By.XPath("//button[@class='btn btn-success']");
        private By CountryOptionsTxtBox = By.Id("country");
        private By CountryItem = By.XPath("//div[@class='suggestions']//ul//li//a");
        private By TermsConditionChkBox = By.XPath("//input[@type='checkbox']");
        private By PurchaseBtn = By.XPath("//input[@value='Purchase']");
        private By SucessAlert = By.XPath("//div[starts-with(@class,'alert')]");


        public void verifyAddedCartProducts(String[] expectedProducts)
        {
            driver.FindElement(CheckoutOption).Click();
            IList<IWebElement> addedCartProductsList=driver.FindElements(addedCartProducts);
            bool result = addedCartProductsList.Any(element => expectedProducts.Contains(element.Text));
            Assert.That(result);
        }

        public void checkoutProduct(String Country)
        {
            driver.FindElement(CheckoutBtn).Click();
            driver.FindElement(CountryOptionsTxtBox).SendKeys(Country);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(countryOptions));

            driver.FindElement(CountryItem).Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", driver.FindElement(TermsConditionChkBox));

            driver.FindElement(PurchaseBtn).Click();

        }

        public void verifyProductPurchesedSuccessfully()
        {
            string successMsg = driver.FindElement(SucessAlert).Text;

            TestContext.Progress.WriteLine(successMsg);

            Assert.That(successMsg.Contains("Success"));
        }
    }
}
