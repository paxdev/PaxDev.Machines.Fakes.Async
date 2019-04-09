using Machine.Fakes;
using Machine.Specifications;

namespace PaxDev.Machine.Specifications.Async.Specs
{
    [Subject(typeof(ReturnAsyncExtensions))]
    public class When_setup_to_invoke_a_parameterless_function : WithFakes
    {
        const string ExpectedFunctionResult = "Expected Function Result";

        static string _result;

        Establish context = () =>
            The<ITestInterface>()
                .WhenToldTo(d => d.Method())
                .ReturnAsync(() => ExpectedFunctionResult);

        Because of = () => _result = The<ITestInterface>().Method().Result;

        It should_return_the_result_of_the_function = () => _result.ShouldEqual(ExpectedFunctionResult);
    }
}