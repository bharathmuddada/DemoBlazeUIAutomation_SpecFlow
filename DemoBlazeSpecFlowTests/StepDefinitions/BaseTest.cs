using DemoBlazeCoreFW_SpecFlow;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace DemoBlazeSpecFlowTests.StepDefinitions
{
    [Binding]
    public class BaseTest
    {
  


        [BeforeScenario]
        public static void BeforeScenario()
        {
            var browsername = ConfigReaderHelpers.GetconfigDetails("browsername");
            Driver.init(browsername);
            //Driver.current.Navigate().GoToUrl(url);

        }


        [AfterScenario]
        public static void AfterScenario()
        {

            var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".png";
            var ss_path = Directory.GetCurrentDirectory() + $"\\allure-results\\{filename}";
            Driver.getScreenshot(ss_path);
            Driver.current.Quit();
        }
    }
}
