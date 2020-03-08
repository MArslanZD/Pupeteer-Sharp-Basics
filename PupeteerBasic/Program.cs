using PupeteerBasic.Interfaces;
using PupeteerBasic.Repository;
using System;
using System.Threading.Tasks;

namespace PupeteerBasic
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IProxy _proxy = new ProxyRepository();
            var proxies = _proxy.getProxy();
            foreach (var proxyItems in proxies)
                await Pupeteer.Pupeteer.StartService(proxyItems);

        }
    }
}
