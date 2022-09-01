using DemoBlazeCoreFW_SpecFlow;
using DemoBlazePages.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace DemoBlazeSpecFlowTests.StepDefinitions
{
    [Binding]
    public class DemoBlazeMultipleOrdersStepDefinitions
    {
        private CartPage cartpage;

        public DemoBlazeMultipleOrdersStepDefinitions()
        {
            cartpage = new CartPage(Driver.current);
        }


        [Then(@"product names in the cart should match the ""([^""]*)""")]
        public void ThenProductNamesInTheCartShouldMatchThe(string products)
        {
            List<string> expectedProdNameList = new List<string>();

            var prodlist = products.Split(',');

            foreach(string prodname in prodlist)
                expectedProdNameList.Add(prodname);
      
            Assert.That(cartpage.GetProductNames(), Is.EquivalentTo(expectedProdNameList));
        }

        [Then(@"total price is equal to the order confirmation price")]
        public void ThenTotalPriceIsEqualToTheOrderConfirmationPrice()
        {
            Assert.That(cartpage.PriceFromOrderConfirmation(), Is.EqualTo(int.Parse(cartpage.TotalCartPrice.Text)));
        }


    }
}
