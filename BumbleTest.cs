using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace DateSeleniumApp
{
    [TestClass]
    public class BumbleTest
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public BumbleTest() { 
        }

        [TestMethod]
        [TestCategory("Chrome")]

        public void TestBumble()
        {
            driver.Navigate().GoToUrl(appURL + "/");            
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div/div[2]/a")).Click();
            Thread.Sleep(7000);
            driver.FindElement(By.XPath("//*[@id='main']/div/div[1]/div[2]/main/div/div[3]/form/div[1]/div/div[2]/div")).Click();
            Thread.Sleep(7000);
            string MainWindow = driver.CurrentWindowHandle;
            string popupFacebookWindow = "";
            foreach (var windowHandlerid in driver.WindowHandles)
            {
                if (MainWindow!= windowHandlerid)
                {
                    popupFacebookWindow = windowHandlerid;
                }
            }

            driver.SwitchTo().Window(popupFacebookWindow);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys("");
            driver.FindElement(By.XPath("//*[@id='pass']")).SendKeys("");
            driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/form/div/div[3]/label[2]/input")).Click();
            Thread.Sleep(30000);
            driver.SwitchTo().Window(MainWindow);
            Thread.Sleep(3000);
            int count = 0;
            while (true)
            {
                try {
                  
                    driver.FindElement(By.XPath("/html/body/div/div/div[1]/main/div[2]/div/div/span/div[2]/div/div[2]/div/div[3]/div/div[1]/span")).Click();
                    Thread.Sleep(2000);
                    count++;
                    Console.WriteLine("Likes dados: "+count.ToString());
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "https://bumble.com";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;                
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
