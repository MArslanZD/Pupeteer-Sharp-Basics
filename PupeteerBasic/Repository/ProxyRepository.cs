using PupeteerBasic.Interfaces;
using PupeteerBasic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PupeteerBasic.Repository
{
    public class ProxyRepository : IProxy
    {
        public List<ProxyModels> getProxy()
        {
            List<ProxyModels> _proxy = new List<ProxyModels>();
            try
            {
                _proxy.Add(new ProxyModels { ProxyIP = "p.webshare.io", ProxyUserName = "ygfzfgqs-6", ProxyPassword = "fvpxf2bpzi1q", ProxyPort = 80, Message = "Success" });
                _proxy.Add(new ProxyModels { ProxyIP = "p.webshare.io", ProxyUserName = "ygfzfgqs-7", ProxyPassword = "fvpxf2bpzi1q", ProxyPort = 80, Message = "Success" });
                _proxy.Add(new ProxyModels { ProxyIP = "p.webshare.io", ProxyUserName = "ygfzfgqs-8", ProxyPassword = "fvpxf2bpzi1q", ProxyPort = 80, Message = "Success" });

            }
            catch (Exception ex)
            {
                // Log Error
                _proxy.Add(new ProxyModels { ProxyIP = "", ProxyUserName = "", ProxyPassword = "", ProxyPort = 0, Message = "Error: " + ex.Message });
            }

            return _proxy;
        }
    }
}
