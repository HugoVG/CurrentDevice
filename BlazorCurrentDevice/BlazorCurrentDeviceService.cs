using System.Collections.Generic;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorCurrentDevice
{
    internal class BlazorCurrentDeviceService : IBlazorCurrentDeviceService
    {
        protected IJSRuntime JSRuntime { get; set; }
        public BlazorCurrentDeviceService(IJSRuntime jSRuntime)
        {
            JSRuntime = jSRuntime;
        }

        private Dictionary<string, bool> _deviceCache = new Dictionary<string, bool>();
        
        
        
        public async Task<bool> MacOs()
        {
            return await Find("mac");
        }

        public async Task<string> Type()
        {
            return await Desktop() ? "desktop" : await Tablet() ? "tablet" : await Mobile() ? "mobile" : await Television() ? "television" : "unknown";
        }

        public Task<bool> Windows()
        {
            return Find("windows");
        }

        public async Task<bool> WindowsPhone()
        {
            return await Windows() && await Find("phone");
        }
        
        public async Task<bool> WindowsTablet()
        {
            return await Windows() && await Find("touch") && !await WindowsPhone();
        }

        public Task<bool> iPhone()
        {
            return Find("iphone");
        }

        public Task<bool> iPod()
        {
            return Find("ipod");
        }
        
        public Task<bool> iPad()
        {
            return Find("ipad");
        }

        public async Task<bool> Desktop()
        {
            return (!await Mobile()) && (!await Tablet()) && (!await Television());
        }

        public async Task<bool> iOS()
        {
            return await iPhone() || await iPod() || await iPad();
        }
        
        public async Task<bool> Android()
        {
            return await Find("android");
        }

        public async Task<bool> AndroidPhone()
        {
            return await Android() && await Find("mobile");
        }
        
        public async Task<bool> AndroidTablet()
        {
            return await Android() && !await AndroidPhone();
        }

        public async Task<bool> Blackberry()
        {
            return await Find("blackberry") || await Find("bb10") || await Find("rim");
        }

        public async Task<bool> BlackberryPhone()
        {
            return await Blackberry() && !(await Find("tablet"));
        }
        
        public async Task<bool> BlackberryTablet()
        {
            return await Blackberry() && await Find("tablet");
        }

        public Task<bool> MeeGo()
        {
            return Find("meego");
        }

        public async Task<bool> Mobile()
        {
            return await AndroidPhone() || await iPhone() || await iPod() || await WindowsPhone() || await BlackberryPhone() || await MeeGo();
        }

        public async Task<bool> Tablet()
        {
            return await iPad() || await AndroidTablet() || await BlackberryTablet() || await WindowsTablet();
        }

        public async Task<bool> Television()
        {
            return FindIn(UserAgent ??= await GetUserAgent(), Televisions) != "unknown";
        }



        public async Task<bool> Landscape()
        {
            return await Orientation() == "landscape";
        }
        
        public async Task<bool> Portrait()
        {
            return await Orientation() == "portrait";
        }
        
        //--------------------------------------------------------------------------------
        
        
        public async Task<string> Orientation()
        {
            return FindIn(await GetOrientation(), Orientations);
        }
        public async Task<string> OS()
        {
            return FindIn(UserAgent ??= await GetUserAgent(), OperatingSystems);
        }
        
        
        
        
        
        
        

        private async Task<bool> Find(string value)
        {
            if (_deviceCache.TryGetValue(value, out var foundValue))
            {
                return foundValue;
            }
            UserAgent ??=  await GetUserAgent();
            foundValue = UserAgent.Contains(value);
            _deviceCache.Add(value, foundValue);
            return foundValue;
        }

        private string FindIn(string searchString, string[] values)
        {
            foreach (var value in values)
            {
                if (searchString.Contains(value))
                {
                    return value;
                }
            }
            return "unknown";
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Current User Agent</returns>
        public async Task<string> GetUserAgent()
        {
            return (await JSRuntime.InvokeAsync<string>("eval", "window.navigator.userAgent")).ToLower();
        }
        
        /// <summary>
        /// We are using either Scoped or Singleton so this method will be called only once for wasm, and once per connection for server
        /// </summary>
        private string UserAgent { get; set; }
        
        public async Task<string> GetOrientation()
        {
            return await JSRuntime.InvokeAsync<string>("eval", "const y435fds=screen.orientation;y435fds.type");
        }
        

        private static readonly string[] Televisions =
        {
            "googletv",
            "viera",
            "smarttv",
            "internet.tv",
            "netcast",
            "nettv",
            "appletv",
            "boxee",
            "kylo",
            "roku",
            "dlnadoc",
            "pov_tv",
            "hbbtv",
            "ce-html"
        };

        private static readonly string[] OperatingSystems =
        {
            "ios",
            "iphone",
            "ipad",
            "ipod",
            "android",
            "blackberry",
            "macos",
            "windows",
            "fxos",
            "meego",
            "television"
        };
        private static readonly string[] Devices =
        {
            "mobile",
            "tablet",
            "desktop",
            "television"
        };
        private static readonly string[] Orientations =
        {
            "portrait",
            "landscape"
        };
    }
}
