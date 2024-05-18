using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class Feature1StepDefinitions
    {
        ChromeDriver driver = new ChromeDriver();
        public ConfigImportor configImportor = new();

        public string actuall = "";
        [Given(@"loginto appoinment page")]
        public void GivenLogintoAppoinmentPage()
        {
            var Url = configImportor.details["URL"].ToString();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url);
            driver.FindElement(By.XPath(configImportor.details["xpathToAppointment"].ToString())).Click();
            var a = "John Doe";   //driver.FindElement(By.XPath("//body/section[@id='login']/div[1]/div[1]/div[2]/form[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Text;
            var b = "ThisIsNotAPassword"; //driver.FindElement(By.XPath("//body/section[@id='login']/div[1]/div[1]/div[2]/form[1]/div[1]/div[2]/div[1]/div[1]/input[1]")).Text;
            driver.FindElement(By.XPath("//input[@id='txt-username']")).SendKeys(a);
            driver.FindElement(By.XPath("//input[@id='txt-password']")).SendKeys(b);
            driver.FindElement(By.XPath("//button[@id='btn-login']")).Click();
        }
    

        [When(@"Fill the form")]
        public void WhenFillTheForm()
        {

            //var datepicker = driver.FindElement(By.XPath("//input[@id='txt_visit_date']"));
            //datepicker.SendKeys("18/05/2024");
            driver.FindElement(By.XPath("//button[@id='btn-book-appointment']")).Click();

        }

        [When(@"Validate check validation of Input form")]
        public void WhenValidateCheckValidationOfInputForm()
        {

            var datepicker = driver.FindElement(By.XPath("//input[@id='txt_visit_date']"));
            Assert.IsTrue(datepicker.GetAttribute("required") != null, "visit_date field should be required");

            
            //throw new PendingStepException();
        }

        [When(@"fill complete form")]
        public void WhenFillCompleteForm()
        {
            driver.FindElement(By.XPath("//input[@id='txt_visit_date']")).SendKeys("18/05/2024");
            driver.FindElement(By.XPath("//textarea[@id='txt_comment']")).SendKeys("my text comment");
            
        }

        [Then(@"submit form and close browser")]
        public void ThenSubmitFormAndCloseBrowser()
        {
            driver.FindElement(By.XPath("//button[@id='btn-book-appointment']")).Click();
            var a=driver.FindElement(By.XPath("//h2[contains(text(),'Appointment Confirmation')]")).Text;
            Assert.AreEqual(a, "Appointment Confirmation");
            Thread.Sleep(2000);
            driver.Close();
            //throw new PendingStepException();
        }
    }
}
