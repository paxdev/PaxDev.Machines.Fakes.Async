using Machine.Fakes;
using Machine.Specifications;

namespace PaxDev.Machine.Fakes.Async.Specs
{
    [Subject(typeof(ReturnAsyncExtensions))]
    public class When_setup_to_invoke_a_single_parameter_function : WithFakes
    {
        const string ExpectedFormatString = "You passed {0}";
        const string ExpectedParameter = "value";

        static string _result;

        Establish context = () =>
            The<ITestInterface>()
                .WhenToldTo(d => d.MethodWithOneParameter(Param<string>.IsAnything))
                .ReturnAsync((string s) => DoFunction(s));

        static string DoFunction(string s) => string.Format(ExpectedFormatString, s);

        Because of = () => _result = The<ITestInterface>().MethodWithOneParameter(ExpectedParameter).Result;

        It should_invoke_the_function_on_the_parameter = () =>
            _result.ShouldEqual(DoFunction(ExpectedParameter));
    }
}