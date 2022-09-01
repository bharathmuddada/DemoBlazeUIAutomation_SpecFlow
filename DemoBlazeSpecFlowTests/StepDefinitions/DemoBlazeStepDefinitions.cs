using DemoBlazeCoreFW_SpecFlow;
using DemoBlazePages.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace DemoBlazeSpecFlowTests.StepDefinitions
{
    [Binding]
    public class DemoBlazeStepDefinitions 
    {
        private LoginPage? loginpage;

        // private ISpecFlowOutputHelper specFlowOutputHelper;

        private readonly ScenarioContext _scenarioContext;

        private ISpecFlowOutputHelper _specFlowOutputHelper;

        public DemoBlazeStepDefinitions(ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            //_settings = settings;
            _scenarioContext = scenarioContext;
            _specFlowOutputHelper = specFlowOutputHelper;
        }


        [Given(@"I navigate to the demoblaze website")]
        public void GivenINavigateToTheDemoblazeWebsite()
        {
          //  var browsername = ConfigReaderHelpers.GetconfigDetails("browsername");
            var url = ConfigReaderHelpers.GetconfigDetails("applicationurl");
            //Driver.init(browsername);
            _specFlowOutputHelper.WriteLine($"navigating to {url}");
            Driver.current.Navigate().GoToUrl(url);

        }

        [When(@"I login with empty credentials")]
        public void WhenILoginWithEmptyCredentials()
        {
            HeaderNav headernav = new HeaderNav(Driver.current);


            loginpage = headernav.NavigateToLoginPage();

            _specFlowOutputHelper.WriteLine($"logging in with empty credentials");
            loginpage.DoLogin(string.Empty, string.Empty);
            
        }

        

        [When(@"I login with '([^']*)' and '([^']*)'")]
        public void WhenILoginWithAnd(string username, string password)
        {
            HeaderNav headernav = new HeaderNav(Driver.current);

            loginpage = headernav.NavigateToLoginPage();

            _specFlowOutputHelper.WriteLine($"logging in with {username} and {password} ");
            loginpage.DoLogin(username, password);
        }

        [Given(@"I login with ""([^""]*)"" credentials")]
        [When(@"I login with ""([^""]*)"" credentials")]
        public void WhenILoginWithCredentials(string credtype)
        {
            HeaderNav headernav = new HeaderNav(Driver.current);


            loginpage = headernav.NavigateToLoginPage();

            _specFlowOutputHelper.WriteLine($"logging in with {credtype} credentials");

            if (credtype == "empty") {

                loginpage.DoLogin(string.Empty, string.Empty);

            }


            else if (credtype == "invalid")
            {

                loginpage.DoLogin("AutomationUser", "wrong");

            }

            if (credtype == "valid")
            {

                string username = ConfigReaderHelpers.GetconfigDetails("username");
                string password = ConfigReaderHelpers.GetconfigDetails("password");
                loginpage.DoLogin(username,password);

            }
        }



        [Then(@"No username and password alert should be displayed")]
        public void NoUsernamePasswordAlertShouldBeDisplayed()
        {
            Assert.That(loginpage.NoUsernameAndPassword(), Is.True);
            _specFlowOutputHelper.WriteLine($" NoUsernamePasswordAlert is Displayed");
        }

        [Then(@"Wrong password alert should be displayed")]
        public void WrongPasswordAlertShouldBeDisplayed()
        {
            Assert.That(loginpage.WrongPassword(), Is.True);
            _specFlowOutputHelper.WriteLine($" wrong password alert is Displayed");

        }

        [Then(@"Login should be successfull")]
        public void SuccessfullLogin()
        {

            Assert.That(loginpage.GetLoggedinUserName(), Is.EqualTo("Welcome AutomationUser"));
            _specFlowOutputHelper.WriteLine($" Login is successfull");

        }



        [Then(@"Outcome should match '([^']*)'")]
        public void ThenOutcomeShouldMatch(string expectedresult)
        {
            _specFlowOutputHelper.WriteLine($" validating the {expectedresult}");

            if (expectedresult == "nousernamepasswordalert")
            {

                Assert.That(loginpage.NoUsernameAndPassword(), Is.True);

            }


            else if (expectedresult == "wrongpassword")
            {

                Assert.That(loginpage.WrongPassword(), Is.True);



            }

            if (expectedresult == "successfulllogin")
            {

                Assert.That(loginpage.GetLoggedinUserName(), Is.EqualTo("Welcome AutomationUser"));
            }
        }

    }
}
