using NUnit.Framework;
using TechTalk.SpecFlow;

namespace POC.Automation.Steps.ApiSteps
{
    [Binding]
    public sealed class GenericApiSteps : BaseApiSteps
    {
        public GenericApiSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [StepDefinition(@"I send '([^']+?)' from ([^']+?) as '([^']+?)'")]
        public void SendRequest(string method, string pageName, string responseName)
        {
            dynamic response = ExecuteMethodRequest(pageName, method);
            ScenarioContext.Add(responseName, response);
        }

        [StepDefinition(@"I send '([^']+?)' with '([^']+?)' from ([^']+?) as '([^']+?)'")]
        public void SendRequest(string method, string requestParam, string pageName, string responseName)
        {
            dynamic response = ScenarioContext.Get<dynamic>(requestParam);
            dynamic responseResult = ExecuteMethodRequest(pageName, method, response);

            ScenarioContext.Add(responseName, responseResult);
        }

        [StepDefinition(@"I send '([^']+?)' with '([^']+?)' and '([^']+?)' from ([^']+?) as '([^']+?)'")]
        public void SendRequest(string method, string requestParam1, string requestParam2, string pageName, string responseName)
        {
            dynamic response = ScenarioContext.Get<dynamic>(requestParam2);
            dynamic responseResult = ExecuteMethodRequest(pageName, method, requestParam1, response);

            ScenarioContext.Add(responseName, responseResult);
        }

        [StepDefinition(@"I should see '([^']+?)' in ([^']+?) with '([^']+?)' from ([^']+?)")]
        public void Validation(string value, string method, string requestParam, string pageName)
        {
            dynamic response = ScenarioContext.Get<dynamic>(requestParam);
            bool responseResult = ExecuteMethodRequest(pageName, method, value, response );
            
            Assert.IsTrue(responseResult);
        }
    }
}



