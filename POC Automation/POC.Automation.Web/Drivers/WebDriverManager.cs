using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POC.Automation.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Automation.Web.Drivers
{
    public sealed class WebDriverManager
    {
        private WebDriverManager() { }

        private IWebDriver webDriver;

        private static WebDriverManager instance;

        public static WebDriverManager Instance { get => instance = instance == null ? new WebDriverManager() : instance; }

        public void Start()
        {
            webDriver = new ChromeDriver(@"C:\Users\Marco.Mendez\Downloads\Compressed\");
            webDriver.Navigate().GoToUrl(Env.WebAppUrl);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(Env.ImplicitWait));
        }

        public IWebDriver WebDriver
        {
            get { return webDriver; }
        }

        public void Close()
        {
            webDriver.Close();
            webDriver.Quit();
        }
    }
}
