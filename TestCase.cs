using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace Task1
{
    public class TestCase 
    {
        public IWebDriver driver;
        [SetUp]
        public void OpenBrowser()
        {

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.flipkart.com/";


        }

        [Test]
        public void Login ()
        {

            // TestCase 1
            driver.FindElement(By.XPath("//input[@class='_2IX_2- VJZDxU']")).SendKeys("9738020725");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("ashwathnarayan");
            driver.FindElement(By.XPath("//button[@class='_2KpZ6l _2HKlqd _3AWRsL']")).Click();


            // TestCase 2
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='_3704LK']")));
            driver.FindElement(By.XPath("//input[@class='_3704LK']")).SendKeys("samsung galaxy m32");
            driver.FindElement(By.XPath("//input[@class='_3704LK']")).SendKeys(Keys.Enter);

            // TestCase 3 & 4
             wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='_2I9KP_'][1]")));
            driver.FindElement(By.XPath("//img[@alt='SAMSUNG Galaxy M32 5G (Sky Blue, 128 GB)']")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.FindElement(By.XPath("//button[@class='_2KpZ6l _2U9uOA _3v1-ww']")).Click();

            // TestCase 5
             wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='_3dsJAO'][2]")));
            driver.FindElement(By.XPath("//div[normalize-space()='Save for later']")).Click();

        }
    }
}