using System.Threading.Tasks;

namespace PaxDev.Machine.Specifications.Async.Specs
{
    public interface ITestInterface
    {
        Task<string> Method();

        Task<string> MethodWithOneParameter(string parameter);

        Task<string> MethodWithTwoParameters(string parameter1, int parameter2);

        Task<string> MethodWithThreeParameters(string parameter1, int parameter2, decimal parameter3);

        Task<string> MethodWithFourParameters(string parameter1, int parameter2, decimal parameter3, double parameter4);
    }
}