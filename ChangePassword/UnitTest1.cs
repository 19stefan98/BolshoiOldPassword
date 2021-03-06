﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace ChangePassword
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Password()
        {
            Registration reg = new Registration(driver);
            reg.Action();

            string actual = "Успех";

            ChangePassword pass = new ChangePassword(driver,reg.pass);
            pass.Action();

            Assert.AreEqual(pass.text, actual);
        }
    }
}
