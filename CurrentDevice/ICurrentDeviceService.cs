using System.Threading.Tasks;

namespace BlazorCurrentDevice
{
    /// <summary>
    /// Service to get information about the current device
    /// </summary>
    public interface ICurrentDeviceService
    {
        /// <summary>
        /// Gets the user agent of the current device
        /// </summary>
        /// <returns>the user agent from the browser</returns>
        /// <inheritdoc cref="Documentation"/>
        Task<string> GetUserAgent();
        
        /// <summary>
        /// Checks if the current device is android
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> Android();
        /// <summary>
        /// Checks if the current device is android phone
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> AndroidPhone();
        /// <summary>
        /// Checks if the current device is android tablet
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> AndroidTablet();
        /// <summary>
        /// Checks if the current device is Blackberry
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> Blackberry();
        /// <summary>
        /// Checks if the current device is Blackberry phone
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> BlackberryPhone();
        /// <summary>
        /// Checks if the current device is Blackberry tablet
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> BlackberryTablet();
        /// <summary>
        /// Checks if the current device is a desktop
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> Desktop();
        /// <summary>
        /// Checks if the current device is iOS
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> iOS();
        /// <summary>
        /// Checks if the current device is iPad
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> iPad();
        /// <summary>
        /// Checks if the current device is iPhone
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> iPhone();
        /// <summary>
        /// Checks if the current device is iPod
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> iPod();
        /// <summary>
        /// Checks if the current device is on landscape orientation
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> Landscape();
        /// <summary>
        /// Checks if the current device is MacOs
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> MacOs();
        /// <summary>
        /// Checks if the current device is MeeGo
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> MeeGo();
        /// <summary>
        /// Checks if the current device is mobile
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> Mobile();
        /// <summary>
        /// Gets the current device orientation
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<string> Orientation();
        /// <summary>
        /// Checks if the current device is portrait orientation. Possible return values 'ios', 'iphone', 'ipad', 'ipod', 'android', 'blackberry', 'windows', 'macos', 'meego', 'television', or 'unknown'
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<string> OS();
        /// <summary>
        /// Gets the current device operating system. Possible return values 'landscape', 'portrait', or 'unknown'
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> Portrait();
        /// <summary>
        /// Checks if the current device is tablet
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> Tablet();
        /// <summary>
        /// Checks if the current device is television
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> Television();
        /// <summary>
        /// Gets the current device type. Possible return values 'mobile', 'tablet', 'desktop', or 'unknown'
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<string> Type();
        /// <summary>
        /// Checks if the current device is windows
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> Windows();
        /// <summary>
        /// Checks if the current device is windows phone
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> WindowsPhone();
        /// <summary>
        /// Checks if the current device is tablet
        /// </summary>
        /// <returns></returns>
        /// <inheritdoc cref="Documentation"/>
        Task<bool> WindowsTablet();
    }
    
    /// <remarks>
    /// The user agent is a string that the browser sends to the server to identify itself.
    /// A typical user agent string contains the name of the browser, the version, the operating system, and the engine of the browser.
    /// !KEEP IN MIND! The user agent can be changed by the user or by the browser itself to something different to protect the user's privacy.
    /// </remarks>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent"/>
    internal class Documentation { }
}
