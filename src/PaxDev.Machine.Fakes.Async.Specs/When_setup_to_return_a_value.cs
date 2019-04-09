using Machine.Fakes;
using Machine.Specifications;

namespace PaxDev.Machine.Specifications.Async.Specs
{
    [Subject(typeof(ReturnAsyncExtensions))]
    public class When_setup_to_return_a_value : WithFakes
    {
        const string ExpectedValue = "Expected Value";

        static string _result;

        Establish context = () =>
            The<ITestInterface>()
                .WhenToldTo(d => d.Method())
                .ReturnAsync(ExpectedValue);

        Because of = () => _result = The<ITestInterface>().Method().Result;

        It should_return_the_value = () => _result.ShouldEqual(ExpectedValue);
    }
}