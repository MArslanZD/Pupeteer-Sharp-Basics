using PupeteerBasic.Models;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace PupeteerBasic.Pupeteer
{
   public static class Pupeteer
    {

        public static async Task StartService(ProxyModels _proxy)
        {
            try
            {
                Browser browser = await PrepareBrowser(_proxy.ProxyIP, _proxy.ProxyPort);
                var pages = await browser.PagesAsync();
                var page = pages.Single();
                Credentials proxyCredentails = new Credentials
                {
                    Username = _proxy.ProxyUserName,
                    Password = _proxy.ProxyPassword
                };
                Console.WriteLine("Authenticating Proxy...");
                await page.AuthenticateAsync(proxyCredentails);
                Console.WriteLine("Navigating...");
                
                // Navigate to Facebook
                await page.GoToAsync("https://www.facebook.com/");

                // Write Email
                await page.WaitForSelectorAsync("#email");
                await page.ClickAsync("#email");
                await page.Keyboard.TypeAsync("Your Email Goes Here");

                // Write Password
                await page.WaitForSelectorAsync("#pass");
                await page.ClickAsync("#pass");
                await page.Keyboard.TypeAsync("Your Password Goes Here");

                // Login 
                await page.ClickAsync("#u_0_b");
                           
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured..." + ex.Message);
            }
        }
        private static async Task<Browser> PrepareBrowser(string ipAddress, int port)
        {
            Browser browser = null;
            try
            {
                var options = new LaunchOptions
                {
                    ExecutablePath = ChromeProvider.GetChromeProviderPath(),
                    Headless = false,
                    Args = ipAddress == null ? new string[0] : new[]
                        {

                            $"--proxy-server={ipAddress}:{port}"
                        }
                };

                if (options.ExecutablePath.Equals("Can not get Chrome path because the OS is not supported."))
                {
                    Console.WriteLine("No Chrome Found. Downloading chromium...");
                    await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
                }

                Console.WriteLine("Opening Browser...");
                browser = await Puppeteer.LaunchAsync(options);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in function PrepareBrowser... " +ex.Message);                
            }
            return browser;
        }
    }
}
