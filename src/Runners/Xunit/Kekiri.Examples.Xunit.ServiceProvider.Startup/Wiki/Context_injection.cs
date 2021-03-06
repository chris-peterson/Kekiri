using Kekiri.Examples.WebApp;
using Kekiri.Xunit;
using Xunit;

namespace Kekiri.Examples.Xunit
{
    public class Context
    {
        public Context(IFoo foo)
        {
            Foo = foo;
        }

        public IFoo Foo { get; }
    }

    public class Context_injection : ExampleScenariosTyped<Context>
    {
        [ScenarioOutline]
        [Example(1)]
        [Example(2)]
        public void Service_overrides_work(int counter)
        {
            When(Running_scenario, counter);
            Then(It_should_use_correct_types, counter);
        }
    
        void Running_scenario(int counter) {
            // no-op
        }

        void It_should_use_correct_types(int counter) {
            Assert.IsType<TestFoo>(Context.Foo);
        }
    }
}