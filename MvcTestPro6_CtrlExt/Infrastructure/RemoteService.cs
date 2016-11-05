using System.Threading;
using System.Threading.Tasks;

namespace MvcTestPro6_CtrlExt.Infrastructure
{
    public class RemoteService
    {
        public string GetRemoteData()
        {
            Thread.Sleep(2000);
            return "Hello world";
        }

        public async Task<string> GetRemoteDataAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Hello world";
            });
        }
    }
}