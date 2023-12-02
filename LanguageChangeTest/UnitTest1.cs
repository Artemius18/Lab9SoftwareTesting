using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace LanguageChangeTest
{
    public class Tests
    {
        private IWebDriver driver;
        private string baseURL;
        public string englishTextButton;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.mts.by";
        }

        [Test]
        public void LanguageChangeTest()
        {
            driver.Navigate().GoToUrl("https://www.mts.by");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            IWebElement changeLanguageButton = wait.Until(driver => driver.FindElement(By.XPath("/html/body/div[6]/header/div[1]/div/div/div[2]/div/div/a[2]")));
            changeLanguageButton.Click();

            IWebElement englishTextButtonForCompare = wait.Until(driver => driver.FindElement(By.XPath("/html/body/div[6]/header/div[1]/div/div/div[1]/div[1]/a")));

            string actualText = englishTextButtonForCompare.Text;
            englishTextButton = "Private customers";
            Assert.AreEqual(englishTextButton, actualText);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
