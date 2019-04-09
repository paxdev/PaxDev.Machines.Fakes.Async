using System.Threading.Tasks;

namespace PaxDev.Machine.Fakes.Async.Specs
{
    public interface IPolymorph
    {
        Task<TestBase> GetResult();
    }
}