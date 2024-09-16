using OpenQA.Selenium;
using SeleniumSpecFlowProject.Pages;
using SeleniumSpecFlowProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class EcommerceEndToEndStepDefination :Base
    {
        private IWebDriver driver;

        ProductPage productPage;
        CheckOutPage checkoutPage;


        String[] expectedProducts = getDataParser().extractDataArray("expectedProducts");
        public EcommerceEndToEndStepDefination(IWebDriver driver)
        {
            this.driver = driver;
            productPage = new ProductPage(driver);
            checkoutPage = new CheckOutPage(driver);
        }
   

        [Given(@"I am on product page")]
        public void GivenIAmOnProductPage()
        {
            driver.Url = getDataParser().extractData("EcommAppUrl");
            MaximizeWindow(driver);
            Thread.Sleep(3000);
        }

        [When(@"Add product to cart")]
        public void WhenAddProductToCart()
        {
            
            productPage.addProductToCart(expectedProducts);
            
        }

        [When(@"check product Added to cart")]
        public void WhenCheckProductAddedToCart()
        {
            
            checkoutPage.verifyAddedCartProducts(expectedProducts);
            
        }

        [When(@"Complete product purchase")]
        public void WhenCompleteProductPurchase()
        {
            checkoutPage.checkoutProduct(getDataParser().extractData("country"));
        }

        [Then(@"Verify Product purchased sucessfully")]
        public void ThenVerifyProductPurchasedSucessfully()
        {
            checkoutPage.verifyProductPurchesedSuccessfully();
        }


    }
}
