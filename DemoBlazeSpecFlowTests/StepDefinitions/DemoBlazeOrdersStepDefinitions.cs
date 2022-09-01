using DemoBlazeCoreFW_SpecFlow;
using DemoBlazePages.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace DemoBlazeSpecFlowTests.StepDefinitions
{
    [Binding]
    public class DemoBlazeOrdersStepDefinitions
    {
        private HomePage homepage;
        private ProductPage productPage;
        private CartPage cartpage;

        public DemoBlazeOrdersStepDefinitions()
        {
            homepage = new HomePage(Driver.current);
        }

        [When(@"I navigate to ""([^""]*)"" menu and select ""([^""]*)""")]
        public void GivenINavigateToMenuAndSelect(string menusection, string productname)
        {
            homepage.clickOnMenu(menusection);
            productPage = homepage.SelectItemToView(productname);
        }

        [When(@"Product is added to cart")]
        public void GivenIAddTheProductToCart()
        {
            cartpage = productPage.AddProductToCart();
        }

        [When(@"I navigate to homepage")]
        public void GivenINavigateToHomepage()
        {
            HeaderNav headerNav= new HeaderNav(Driver.current);

            headerNav.NavigateToHomePage();
        }



        [When(@"I place an order for the items in cart")]
        public void WhenIPlaceAnOrderForTheSelectedProduct()
        {
            cartpage.PlaceOrder();
        }

        [Then(@"Confirmation should show the message ""([^""]*)""")]
        public void ThenConfirmationShouldShowTheMessage(string confirmationmessage)
        {
            Assert.That(cartpage.GetOrderConfirmation(), Is.EqualTo(confirmationmessage));
        }
    }
}
