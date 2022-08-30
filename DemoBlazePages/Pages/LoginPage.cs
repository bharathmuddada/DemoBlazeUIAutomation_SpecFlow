using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class LoginPage : BasePage
    {
        //private IWebDriver driver;


        public LoginPage(IWebDriver driver) : base(driver)
        {
            //this.driver = driver;
        }

        public IWebElement user_name_field => driver.FindElement(By.Id("loginusername"));

        public IWebElement password_field => driver.FindElement(By.Id("loginpassword"));

        public IWebElement loginbutton => driver.FindElement(By.XPath("//div[@class='modal-footer']//button[text()='Log in']"));

        public IWebElement loggedin_user_name => driver.FindElement(By.XPath("//a[contains(text(),'Welcome')]"));


        public HomePage DoLogin(string username, string password) {

            
            SendTextToElement(user_name_field,username);
            SendTextToElement(password_field,password);
            ClickElement(loginbutton);
            return new HomePage(driver);

        }


        public bool NoUsernameAndPassword() {


            string message = getAlertText();
            Console.WriteLine(message);
  
            return message == "Please fill out Username and Password.";

        }

        public bool WrongPassword()
        {

            string message = getAlertText();
            Console.WriteLine(message);
            return message == "Wrong password.";

        }

        public string GetLoggedinUserName() {
         
            WaitForElementTobeDisplayed(loggedin_user_name);
            Console.WriteLine($"The text from the element is {loggedin_user_name.Text}");
            return loggedin_user_name.Text; 

        }





    }
}
