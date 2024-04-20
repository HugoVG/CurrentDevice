using System.Collections.Generic;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CurrentDevice
{
    internal class CurrentDeviceService : ICurrentDeviceService
    {
        private IJSRuntime JsRuntime { get; set; }

        public CurrentDeviceService(IJSRuntime jSRuntime) => JsRuntime = jSRuntime;

        private readonly Dictionary<string, bool> _deviceCache = new Dictionary<string, bool>();


        public async Task<bool> MacOs() => await Find("mac");

        public async Task<string> Type() =>
            await Desktop() ? "desktop" :
            await Tablet() ? "tablet" :
            await Mobile() ? "mobile" :
            await Television() ? "television" : "unknown";

        public Task<bool> Windows() => Find("windows");

        public async Task<bool> WindowsPhone() => await Windows() && await Find("phone");

        public async Task<bool> WindowsTablet() => await Windows() && await Find("touch") && !await WindowsPhone();

        public Task<bool> iPhone() => Find("iphone");

        public Task<bool> iPod() => Find("ipod");

        public Task<bool> iPad() => Find("ipad");

        public async Task<bool> Desktop() => !await Mobile() && !await Tablet() && (!await Television());

        public async Task<bool> iOS() => await iPhone() || await iPod() || await iPad();

        public async Task<bool> Android() => await Find("android");

        public async Task<bool> AndroidPhone() => await Android() && await Find("mobile");

        public async Task<bool> AndroidTablet() => await Android() && !await AndroidPhone();

        public async Task<bool> Blackberry() => await Find("blackberry") || await Find("bb10") || await Find("rim");
        
        public async Task<bool> BlackberryPhone() => await Blackberry() && !(await Find("tablet"));

        public async Task<bool> BlackberryTablet() => await Blackberry() && await Find("tablet");

        public Task<bool> MeeGo() => Find("meego");

        public async Task<bool> Mobile() =>
            await AndroidPhone() || await iPhone() || await iPod() || await WindowsPhone() ||
            await BlackberryPhone() || await MeeGo();

        public async Task<bool> Tablet() => await iPad() || await AndroidTablet() || await BlackberryTablet() || await WindowsTablet();

        public async Task<bool> Television() => FindIn(UserAgent ??= await GetUserAgent(), Televisions) != "unknown";


        public async Task<bool> Landscape() => await Orientation() == "landscape";

        public async Task<bool> Portrait() => await Orientation() == "portrait";

        public async Task<string> Orientation() => FindIn(await GetOrientation(), Orientations);

        public async Task<string> OS() => FindIn(UserAgent ??= await GetUserAgent(), OperatingSystems);


        private async Task<bool> Find(string value)
        {
            if (_deviceCache.TryGetValue(value, out var foundValue))
            {
                return foundValue;
            }

            UserAgent ??= await GetUserAgent();
            foundValue = UserAgent.Contains(value);
            _deviceCache.TryAdd(value, foundValue);
            return foundValue;
        }

        private static string FindIn(string searchString, string[] values)
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
        
        public async Task<string> GetUserAgent() => (await JsRuntime.InvokeAsync<string>("eval", "window.navigator.userAgent")).ToLower();

        /// <summary>
        /// We are using either Scoped or Singleton so this method will be called only once for wasm, and once per connection for server
        /// </summary>
        private string UserAgent { get; set; }

        public async Task<string> GetOrientation()
        {
            return await JsRuntime.InvokeAsync<string>("eval", "const y435fds=screen.orientation;y435fds.type");
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

        private static readonly string[] Orientations =
        {
            "portrait",
            "landscape"
        };
    }
}