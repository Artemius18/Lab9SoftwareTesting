using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tests
{
    public class Tests
    {
        private IWebDriver driver;
        private string baseURL;
        //public string englishTextButton;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            baseURL = "https://open.spotify.com";

            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
            

            IWebElement login = driver.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/header/div[5]/button[2]"));
            Thread.Sleep(2000);
            login.Click();
            Thread.Sleep(2000);


            IWebElement emailInputField = driver.FindElement(By.XPath("//*[@id=\"login-username\"]"));
            Thread.Sleep(2000);
            emailInputField.Click();
            Thread.Sleep(1000);
            emailInputField.SendKeys("artempsenko@gmail.com");

            IWebElement passwordInputField = driver.FindElement(By.XPath("//*[@id=\"login-password\"]"));
            Thread.Sleep(2000);
            passwordInputField.Click();
            Thread.Sleep(1000);
            passwordInputField.SendKeys("clashroyale2003");

            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));
            Thread.Sleep(2000);
            loginButton.Click();
            Thread.Sleep(3000);

        }



        [Test]
        public void LanguageChangeTest()
        {
            Thread.Sleep(5000);

            //закрыть элемент, который мешает тестированию поверх экрана
            IWebElement closeWindow = driver.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[1]/nav/div[2]/div[1]/div[3]/div/button"));
            Thread.Sleep(2000);
            closeWindow.Click();
            Thread.Sleep(1000);

            IWebElement profileIcon = driver.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/header/button[3]"));
            Thread.Sleep(2000);
            profileIcon.Click();
            Thread.Sleep(1000);

            
            IWebElement settingsButton = driver.FindElement(By.XPath("//*[@id=\"context-menu\"]/div/ul/li[4]/a"));
            Thread.Sleep(2000);
            settingsButton.Click();
            Thread.Sleep(1000);

            
            IWebElement languageSelectButton = driver.FindElement(By.XPath("//*[@id=\"desktop.settings.selectLanguage\"]"));
            Thread.Sleep(2000);
            languageSelectButton.Click();
            Thread.Sleep(1000);

            
            IWebElement englishLanguageButton = driver.FindElement(By.XPath("//*[@id=\"desktop.settings.selectLanguage\"]/option[18]"));
            Thread.Sleep(2000);
            englishLanguageButton.Click();
            Thread.Sleep(3000);


            IWebElement refreshButton = driver.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/div[1]/div[2]/div/div[3]/button"));
            Thread.Sleep(2000);
            refreshButton.Click();
            Thread.Sleep(3000);

            IWebElement settingsText = driver.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/div[1]/div[1]/h1"));
            Thread.Sleep(3000);
            Assert.AreEqual("Settings", settingsText.Text, "Сайт не переведен на английский");
        }

        [TearDown]
        public void TearDown()
        {
            //try
            //{
            //    driver.Quit();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //}
        }
    }
}
