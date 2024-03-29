﻿using POC.Automation.Steps;
using TechTalk.SpecFlow;
using POC.Automation.Helpers;

namespace POC.Automation.Specs.Hooks
{
    [Binding]
    public sealed class BaseHooks : BaseSteps
    {
        public BaseHooks(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [BeforeScenario(Order = 1)]
        public void LoadKeys()
        {
            ScenarioContext.Add($"[{Keys.UserName}]", Env.UserName);
            ScenarioContext.Add($"[{Keys.Password}]", Env.Password);
        }

    }
}
