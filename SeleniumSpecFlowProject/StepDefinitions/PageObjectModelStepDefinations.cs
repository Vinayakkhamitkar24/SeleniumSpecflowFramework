using NUnit.Framework;
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
    public sealed class PageObjectModelStepDefinations :Base
    {
        private IWebDriver driver;

        SearchPage searchPage;
        ResultPage resultPage;
        ChannelPage channelPage;


        public PageObjectModelStepDefinations(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Enter youtube URL")]
        public void GivenEnterYoutubeURL()
        {
            driver.Url = getDataParser().extractData("AppUrl");
            MaximizeWindow(driver);
            //driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
        }


        [When(@"Search for Testers Talk")]
        public void WhenSearchForTestersTalk()
        {
            searchPage = new SearchPage(driver);
            resultPage=searchPage.searchText(getDataParser().extractData("searchText"));
        }

        [When(@"Navigate to channel")]
        public void WhenNavigateToChannel()
        {
            channelPage=resultPage.goToChannel();
        }

        [Then(@"Verify the title of page")]
        public void ThenVerifyTheTitleOfPage()
        {
            String expectedTitle = "Testers Talk - YouTube";
            Boolean result = expectedTitle.Equals(channelPage.getTitle());
            Assert.That(result,"Page Title Didn't Matched");
        }


    }
}
