using Machine.Fakes;
using Machine.Specifications;

namespace PaxDev.Machine.Specifications.Async.Specs
{
    [Subject(typeof(ReturnAsyncExtensions))]
    public class When_setup_to_invoke_a_three_parameter_function : WithFakes
    {
        const string ExpectedFormatString = "You passed {0} {1} {2}";
        const string ExpectedParameter1 = "value 1";
        const int ExpectedParameter2 = 2;
        const decimal ExpectedParameter3 = 3.4m;

        static string _result;

        Establish context = () =>
            The<ITestInterface>()
                .WhenToldTo(d => d.MethodWithThreeParameters(Param<string>.IsAnything, Param<int>.IsAnything, Param<decimal>.IsAnything))
                .ReturnAsync((string s, int i, decimal d) => DoFunction(s, i, d));

        static string DoFunction(string s, int i, decimal d) => string.Format(ExpectedFormatString, s, i, d);

        Because of = () => _result = The<ITestInterface>().MethodWithThreeParameters(ExpectedParameter1, ExpectedParameter2, ExpectedParameter3).Result;

        It should_invoke_the_function_on_the_parameter = () =>
            _result.ShouldEqual(DoFunction(ExpectedParameter1, ExpectedParameter2, ExpectedParameter3));
    }
}