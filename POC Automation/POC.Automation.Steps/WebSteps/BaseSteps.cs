using POC.Automation.Helpers;
using POC.Automation.Helpers.Attributes;
using POC.Automation.Helpers.Enums;
using POC.Automation.Web.Elements;
using System;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace POC.Automation.Steps
{
    [Binding]
    public class BaseSteps : TechTalk.SpecFlow.Steps
    {
        protected new ScenarioContext ScenarioContext { get; }

        private const string PagesAssemblyName = "POC.Automation.Web";

        private const string ElementTypeClassName = "POC.Automation.Web.Elements.{0}";

        private const string UIElementsAssemblyName = "POC.Automation.Web";

        public BaseSteps(ScenarioContext injectedContext)
        {
            ScenarioContext = injectedContext;
        }

        [StepArgumentTransformation]
        protected string GetKeyWord(string param)
        {

            try
            {
                if (ScenarioContext.Any(p => p.Key.Equals(param)))
                {
                    return ScenarioContext.Get<string>(param);
                }
                return param;
            }
            catch 
            {

                return param;
            }
        }

        protected Type CurrentViewClassType
        {
            get
            {
                if (!ScenarioContext.Any(p => p.Key.Equals(Keys.CurrentViewClassType)))
                {
                    ScenarioContext.Add(Keys.CurrentViewClassType, string.Empty);
                }
                return (Type)ScenarioContext[Keys.CurrentViewClassType];
            }
            set => ScenarioContext[Keys.CurrentViewClassType] = value;
        }

        protected Type GetPageClassType(string PageName)
        {
            if (!string.IsNullOrEmpty(PageName))
            {
                CurrentViewClassType = Assembly.Load(PagesAssemblyName).GetTypes()
                                         .Where(classType => classType.IsClass && classType.GetCustomAttribute<PageAttribute>()?.Name == PageName)
                                         .FirstOrDefault();
            }

            return CurrentViewClassType;
        }

        protected dynamic Element(string elementName, string PageName)
        {
            var pageClassType = GetPageClassType(PageName);

            PropertyInfo elementInfo = pageClassType.GetTypeInfo().GetProperties()
                .Where(property => property.GetCustomAttribute<ElementAttribute>().Name == elementName)
                .FirstOrDefault();

            ElementType elementType = elementInfo.GetCustomAttribute<ElementAttribute>().Type;

            string elementClass = string.Format(ElementTypeClassName, elementType.ToString());
            Type elementClassType = Assembly.Load(UIElementsAssemblyName).GetType(elementClass);

            return Activator.CreateInstance(elementClassType, new object[] { elementName, GetLocator(elementInfo) });
        }

        protected Locator GetLocator(PropertyInfo elementInfo)
        {
            LocatorAttribute locatorAttr = elementInfo.GetCustomAttributes<LocatorAttribute>().FirstOrDefault();
            Locator locator = new Locator(locatorAttr.LocatorType, locatorAttr.LocatorValue);
            return locator;
        }
    }
}
