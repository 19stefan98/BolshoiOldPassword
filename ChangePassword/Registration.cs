using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ChangePassword
{
    class Registration
    {
        public IWebDriver driver { get; set; }
        public string pass { get; set; }
        TimeSpan timeout = new TimeSpan(00, 01, 00);
        Random rand = new Random();

        public Registration(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Action()
        {
            string a = "";
            string num = "";

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://bolshoy.itech-test.ru/");

            var human = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"gh-extras\"]/a[3]")));
            human.Click();
            var registracia = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"is-tabs-nav\"]/a[2]")));
            registracia.Click();

            for (int v = 0; v < 4; v++)
            {
                a += Convert.ToChar(rand.Next(97, 122));
            } 

            var login = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[LOGIN]")));
            login.SendKeys(a + "test");

            var name = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[NAME]")));
            name.SendKeys("Тест");
            var last_name = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[LAST_NAME]")));
            last_name.SendKeys("Тестовая");
            var email = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[EMAIL]")));
            email.SendKeys(a + "@mail.ru");

            for (int v = 0; v < 6; v++)
            {
                num += rand.Next(1, 9);
            }

            var phone = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[PERSONAL_PHONE]")));
            phone.SendKeys("+7929" + num);
            pass = "123456";
            var password = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[PASSWORD]")));
            password.SendKeys(pass);
            var passsword1 = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[CONFIRM_PASSWORD]")));
            passsword1.SendKeys(pass);
            var checkbox = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("checkbox-label")));
            checkbox.Click();
            checkbox.Submit();
        }
    }
}
