using Machine.Fakes;
using Machine.Specifications;

namespace PaxDev.Machine.Fakes.Async.Specs
{
    [Subject(typeof(ReturnAsyncExtensions))]
    public class When_a_function_is_invoked_twice : WithFakes
    {
        static int _functionCounter;

        static string _result;

        Establish context = () =>
        {
            The<ITestInterface>()
                .WhenToldTo(d => d.Method())
                .ReturnAsync(() => (++_functionCounter).ToString());

            var _ = The<ITestInterface>().Method().Result;
        };

        Because of = () => _result = The<ITestInterface>().Method().Result;

        It should_call_the_function_again = () => _result.ShouldEqual("2");
    }
}