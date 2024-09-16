using CSharpSeleniumFramework.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowProject.Utility
{
    public  class Base
    {

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }

        public void OpenUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElementById(IWebDriver driver, string id)
        {
            return driver.FindElement(By.Id(id));
        }

        public IWebElement FindElementByName(IWebDriver driver, string name)
        {
            return driver.FindElement(By.Name(name));
        }

        public IWebElement FindElementByXPath(IWebDriver driver, string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        public IWebElement FindElementByCssSelector(IWebDriver driver, string cssSelector)
        {
            return driver.FindElement(By.CssSelector(cssSelector));
        }

        public void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public void EnterText(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public void ClearText(IWebElement element)
        {
            element.Clear();
        }

        public string GetText(IWebElement element)
        {
            return element.Text;
        }

        public void SelectDropdownOption(IWebElement dropdown, string optionText)
        {
            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText(optionText);
        }

        public void AcceptAlert(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void DismissAlert(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
        }

        public string GetAlertText(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            return alert.Text;
        }

        public void SwitchToFrame(IWebDriver driver, string frameId)
        {
            driver.SwitchTo().Frame(frameId);
        }

        public void SwitchToDefaultContent(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public void CloseBrowser(IWebDriver driver)
        {
            driver.Quit();
        }

        public void MaximizeWindow(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public void WaitForElementToBeVisible(IWebDriver driver, By locator, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToBeClickable(IWebDriver driver, By locator, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public void ExecuteJavaScript(IWebDriver driver, string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script);
        }
    }
}
