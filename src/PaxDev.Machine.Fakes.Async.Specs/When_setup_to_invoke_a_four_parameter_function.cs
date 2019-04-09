using Machine.Fakes;
using Machine.Specifications;

namespace PaxDev.Machine.Specifications.Async.Specs
{
    [Subject(typeof(ReturnAsyncExtensions))]
    public class When_setup_to_invoke_a_four_parameter_function : WithFakes
    {
        const string ExpectedFormatString = "You passed {0} {1} {2} {3}";
        const string ExpectedParameter1 = "value 1";
        const int ExpectedParameter2 = 2;
        const decimal ExpectedParameter3 = 3.4m;
        const double ExpectedParameter4 = 1.333f;

        static string _result;

        Establish context = () =>
            The<ITestInterface>()
                .WhenToldTo(d => d.MethodWithFourParameters(Param<string>.IsAnything, Param<int>.IsAnything, Param<decimal>.IsAnything, Param<double>.IsAnything))
                .ReturnAsync((string s, int i, decimal dec, double dbl) => DoFunction(s, i, dec, dbl));

        static string DoFunction(string s, int i, decimal dec, double dbl) => string.Format(ExpectedFormatString, s, i, dec, dbl);

        Because of = () => _result = The<ITestInterface>().MethodWithFourParameters(ExpectedParameter1, ExpectedParameter2, ExpectedParameter3, ExpectedParameter4).Result;

        It should_invoke_the_function_on_the_parameter = () =>
            _result.ShouldEqual(DoFunction(ExpectedParameter1, ExpectedParameter2, ExpectedParameter3, ExpectedParameter4));
    }
}