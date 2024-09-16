using AventStack.ExtentReports.Reporter.Config;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AventStack.ExtentReports.Model;

namespace SeleniumSpecFlowProject.Utility
{
    public class ExtentReportsUtility
    {

        public static ExtentReports extent;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");
        public static string reportPath = testResultPath + "//index.html";

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentSparkReporter(reportPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Application", "Google");
            extent.AddSystemInfo("Browser", "Chrome");
            extent.AddSystemInfo("OS", "Windows");

        }

        public static void ExtentReportTearDown()
        {
            extent.Flush();
        }

        public static String captureScreenShot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
           
            screenshot.SaveAsFile(screenshotLocation);
            
            return screenshotLocation;

        }


    }

}


