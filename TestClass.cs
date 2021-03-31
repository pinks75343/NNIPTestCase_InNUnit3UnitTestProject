// NUnit 3 tests
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NNIPTestCase_InNUnit3UnitTestProject
{
    [TestFixture]
    public class TestClass
    {
        // For FireFox Browser
        IWebDriver driver = new FirefoxDriver();
        [SetUp]
        public void SetUP()
        {
            // Maximize windows sizw
            driver.Manage().Window.Maximize();

            // To Navigate the page
            driver.Navigate().GoToUrl("https://www.nnip.com/");  

            // To Delete Cookies
            driver.Manage().Cookies.DeleteAllCookies();

            // To Check the correct page
            Assert.AreEqual("NN Investment Partners", driver.Title);

        }             
       

        [Test]
        public void GoTOFitVermogen()
        {
           
            driver.FindElement(By.XPath("*//* [contains(text(),'Show more countries')]")).Click();

            //To choose specific language 
            driver.FindElement(By.LinkText("Nederland")).Click();

            //  To select 'Particuliere belegger' button
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();

            // Accept disclamer
            driver.FindElement(By.XPath("//button[contains(.,'Akkoord')]")).Click();

            // To click Ontdek FitVermogen
            driver.FindElement(By.LinkText("Ontdek FitVermogen")).Click();

            //Window handeling

            List<string> lstWindow = driver.WindowHandles.ToList();
            foreach (var handle in lstWindow)
            {
                Console.WriteLine("Switching to window - > " + handle);
                driver.SwitchTo().Window(handle);

                //Verify expected page (FitVermogen)
                Assert.AreEqual("Beleggen in Fondsen | FitVermogen", driver.Title);
                
            }
        }

        [TearDown]
        public void Close()
        {  
            //To Close the browser
            driver.Quit();
        }
    }
}
