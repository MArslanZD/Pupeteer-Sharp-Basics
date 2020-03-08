using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PupeteerBasic.Pupeteer
{
    public static class ChromeProvider
    {
        private const string MacOsChromePath = "/Applications/Google Chrome.app/Contents/MacOS/Google Chrome";
        private const string WinChromePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
        private const string LinuxChromiumPath = "/usr/bin/chromium";

        public static string GetChromeProviderPath() =>
           RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? WinChromePath :
           RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? MacOsChromePath :
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? LinuxChromiumPath
            : throw new ApplicationException("Can not get Chrome path because the OS is not supported.");
    }
}
