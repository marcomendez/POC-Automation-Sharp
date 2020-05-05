using POC.Automation.Helpers.Attributes;
using System;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace POC.Automation.Steps.ApiSteps
{
    [Binding]
    public class BaseApiSteps : TechTalk.SpecFlow.Steps
    {
        protected new ScenarioContext ScenarioContext { get; }
        public Type CurrentViewClassType { get; set; }

        private const string PagesAssemblyName = "POC.Automation.Api";

        public BaseApiSteps(ScenarioContext injectedContext)
        {
            ScenarioContext = injectedContext;
        }

        protected Type GetPageClassType(string pageName)
        {
            if (!string.IsNullOrEmpty(pageName))
            {
                CurrentViewClassType = Assembly.Load(PagesAssemblyName).GetTypes()
                                         .Where(classType => classType.IsClass && classType.GetCustomAttribute<PageAttribute>()?.Name == pageName)
                                         .FirstOrDefault();
            }

            return CurrentViewClassType;
        }

        public dynamic ExecuteMethodRequest(string pageName, string method, params object[] param)
        {
            var pageClassType = GetPageClassType(pageName);
            object pageInstance = Activator.CreateInstance(pageClassType);
            MethodInfo methodInfo = pageClassType.GetMethod(method);
            return methodInfo.Invoke(pageInstance, param);
        }
    }
}
