using Machine.Fakes;
using Machine.Specifications;

namespace PaxDev.Machine.Specifications.Async.Specs
{
    [Subject(typeof(ReturnAsyncExtensions))]
    public class When_setup_to_invoke_a_two_parameter_function : WithFakes
    {
        const string ExpectedFormatString = "You passed {0} {1}";
        const string ExpectedParameter1 = "value 1";
        const int ExpectedParameter2 = 2;

        static string _result;

        Establish context = () =>
            The<ITestInterface>()
                .WhenToldTo(d => d.MethodWithTwoParameters(Param<string>.IsAnything, Param<int>.IsAnything))
                .ReturnAsync((string s, int i) => DoFunction(s, i));

        static string DoFunction(string s, int i) => string.Format(ExpectedFormatString, s, i);

        Because of = () => _result = The<ITestInterface>().MethodWithTwoParameters(ExpectedParameter1, ExpectedParameter2).Result;

        It should_invoke_the_function_on_the_parameter = () =>
            _result.ShouldEqual(DoFunction(ExpectedParameter1, ExpectedParameter2));
    }
}