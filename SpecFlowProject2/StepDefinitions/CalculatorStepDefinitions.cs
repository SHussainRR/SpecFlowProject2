using System;
using System.Security.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinitions
    {

        ChromeDriver driver = new ChromeDriver();
        public ConfigImportor configImportor = new();

        public string actuall = "";

        [Given(@"goto make appointment page")]
        public void GivenGotoMakeAppointmentPage()
        {

            var Url = configImportor.details["URL"].ToString();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url);
           
        }

        [Given(@"click make appintment")]
        public void GivenClickMakeAppintment()
        {
            driver.FindElement(By.XPath(configImportor.details["xpathToAppointment"].ToString())).Click();
        }

        [Given(@"login to the Page")]
        public void GivenLoginToThePage()
        {
           

            //throw new PendingStepException();
        }

        [Given(@"Enter Login Credentials")]
        public void GivenEnterLoginCredentials()
        {
            var a = "John Doe";   //driver.FindElement(By.XPath("//body/section[@id='login']/div[1]/div[1]/div[2]/form[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Text;
            var b = "ThisIsNotAPassword"; //driver.FindElement(By.XPath("//body/section[@id='login']/div[1]/div[1]/div[2]/form[1]/div[1]/div[2]/div[1]/div[1]/input[1]")).Text;


            driver.FindElement(By.XPath("//input[@id='txt-username']")).SendKeys(a);
            driver.FindElement(By.XPath("//input[@id='txt-password']")).SendKeys(b);
           

        }

        [When(@"Validate Login Credentilas")]
        public void WhenValidateLoginCredentilas()
        {
            driver.FindElement(By.XPath("//button[@id='btn-login']")).Click();
        }

        [Then(@"It should login")]
        public void ThenItShouldLogin()
        {
            var text=driver.FindElement(By.XPath("//h2[contains(text(),'Make Appointment')]")).Text;
            Assert.AreEqual(text, "Make Appointment");
            driver.Close();

        }


        


    }
}
