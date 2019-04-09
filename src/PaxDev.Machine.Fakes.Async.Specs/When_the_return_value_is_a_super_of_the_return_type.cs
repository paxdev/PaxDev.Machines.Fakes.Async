using Machine.Fakes;
using Machine.Specifications;

namespace PaxDev.Machine.Fakes.Async.Specs
{
    [Subject(typeof(ReturnAsyncExtensions))]
    public class When_the_return_value_is_a_super_of_the_return_type : WithFakes
    {
        static TestBase _result;

        Establish context = () =>
            The<IPolymorph>()
                .WhenToldTo(i => i.GetResult())
                .ReturnAsync(new TestImpl());

        Because of = () => _result = The<IPolymorph>().GetResult().Result;

        It should_return_the_correct_type = () => _result.ShouldBeOfExactType<TestImpl>();
    }
}