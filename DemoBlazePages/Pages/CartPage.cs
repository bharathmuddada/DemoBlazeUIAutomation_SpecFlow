using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement productname => driver.FindElement(By.XPath("//*[@id='tbodyid']/tr[1]/td[2]"));

        public IReadOnlyCollection<IWebElement> Productnames => driver.FindElements(By.XPath("//*[@id='tbodyid']//td[2]"));
        public IWebElement placeOrderButton => driver.FindElement(By.XPath("//button[text()='Place Order']"));

        public IWebElement namefield => driver.FindElement(By.Id("name"));

        public IWebElement countryfield => driver.FindElement(By.Id("country"));


        public IWebElement cityfield => driver.FindElement(By.Id("city"));

        public IWebElement creditcardfield => driver.FindElement(By.Id("card"));

        public IWebElement monthfield => driver.FindElement(By.Id("month"));

        public IWebElement yearfield => driver.FindElement(By.Id("year"));

        public IWebElement purchasebutton => driver.FindElement(By.XPath("//button[text()='Purchase']"));

        public IWebElement thankyouheader => driver.FindElement(By.XPath("//div[@class='sweet-alert  showSweetAlert visible']//h2"));

        public IWebElement DeleteProductFromCart => driver.FindElement(By.XPath("//a[text()='Delete']"));

        public IWebElement TotalCartPrice => driver.FindElement(By.XPath("//h3[@id='totalp']"));

        public IReadOnlyCollection<IWebElement> ProductPrices => driver.FindElements(By.XPath("//*[@id='tbodyid']//td[3]"));


        public IWebElement PriceonConfirmation => driver.FindElement(By.XPath("//div[@class='sweet-alert  showSweetAlert visible']//p"));
        public string GetProductName() {

            WaitForElementTobeDisplayed(productname);

            return productname.Text;
        }

        public void PlaceOrder() {

            ClickElement(placeOrderButton);
            SendTextToElement(namefield, "Automationuser");
            SendTextToElement(countryfield, "India");
            SendTextToElement(cityfield, "Hyderabad");
            SendTextToElement(creditcardfield, "visa card");
            SendTextToElement(monthfield, "August");
            SendTextToElement(yearfield, "2022");
            ClickElement(purchasebutton);

        }

        public string GetOrderConfirmation(){

            return GetTextFromElement(thankyouheader);

         }

        public void DeleteItemFromCart()
        {
            ClickElement(DeleteProductFromCart);

        }

        public List<string> GetProductNames()
        {

            var prodnameList = new List<string>();

    
            WaitForElementsTobeDisplayed(Productnames);

            foreach (var prodname in Productnames)
                prodnameList.Add(prodname.Text);
            return prodnameList;

            
           
        }


        public int SumOfProductPrices() {

            int total = 0;

            foreach (var prodprice in ProductPrices) {
               total += int.Parse(prodprice.Text);
               }

            return total;

        }


        public int PriceFromOrderConfirmation() {

            string price = GetTextFromElement(PriceonConfirmation);
            Console.WriteLine($"Price from the confirmation page {price}");
            string[] pricearray = price.Split("\n");
            string final_price = pricearray[1];
            Console.WriteLine($"final price from the confirmation page {final_price}");
            string amount = final_price.Substring(8,9);
            string[] final_amount = amount.Split(" ");
            Console.WriteLine($"final_amount price from the confirmation page {final_amount}");
            Console.WriteLine($"Final amount for comparison is {final_amount[0].Trim()}");
            return int.Parse(final_amount[0].Trim());
        }
        

    }
}
