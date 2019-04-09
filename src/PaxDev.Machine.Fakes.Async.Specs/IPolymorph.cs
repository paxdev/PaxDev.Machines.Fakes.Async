using System.Threading.Tasks;

namespace PaxDev.Machine.Specifications.Async.Specs
{
    public interface IPolymorph
    {
        Task<TestBase> GetResult();
    }
}