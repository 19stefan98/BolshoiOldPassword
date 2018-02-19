using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ChangePassword
{
    public class ChangePassword
    {
        public IWebDriver driver { get; set; }
        public string text { get; set; }
        public string pass { get; set; }
        TimeSpan timeout = new TimeSpan(00, 00, 15);

        public ChangePassword(IWebDriver driver, string pass )
        {
            this.driver = driver;
            this.pass = pass;
        }

        public void Action()
        {
            var OldPassword = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("CHANGE[OLD_PASS]")));
            OldPassword.SendKeys(pass);
            var NewPass = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("CHANGE[NEW_PASS]")));
            NewPass.SendKeys(pass);
            var NewPassConf = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("CHANGE[CONFIRM_NEW_PASS]")));
            NewPassConf.SendKeys(pass);
            NewPassConf.Submit();
            text = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("md-header"))).Text;
        }
    }
}