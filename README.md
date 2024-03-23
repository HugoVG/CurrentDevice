# CurrentDevice

Device/User agent detector made in Blazor for Blazor. This library is a port of [CurrentDevice](https://github.com/matthewhudson/current-device/)

No need to use JavaScript interop to detect the device or user agent. This library is a pure C# implementation of the original library.

This library is trimmable and does not rely on Javascript (no need to add a <script> tag somewhere)

> [!WARNING]  
> This library is still in development and may not be stable or working as you expect. Please use with caution.

## Installation
![NuGet Downloads](https://img.shields.io/nuget/dt/CurrentDevice?logo=nuget&label=Nuget%20Downloads&labelColor=navy&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FCurrentDevice)


### Nuget CLI 
``dotnet add package CurrentDevice``

### Csproj
``<PackageReference Include="CurrentDevice" Version="1.0.1" />``

## Add reference in _Imports.razor

`@using CurrentDevice`

## Usage

### Add the service in your services method

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
//...  Shortend for brevity
builder.Services.AddBlazorCurrentDevice();
//... Shortend for brevity
await builder.Build().RunAsync();
```

### Inject the service in your component

```csharp
@code{
    [Inject] IBlazorCurrentDeviceService BlazorCurrentDeviceService { get; set; }
}
```
or 
```csharp
@inject IBlazorCurrentDeviceService BlazorCurrentDeviceService
```

### Usage in your component

#### Blazor WASM

```csharp
protected override async Task OnInitializedAsync()
{
    UserAgent = await BlazorCurrentDeviceService.GetUserAgent();
}
```

#### Blazor Server

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        UserAgent = await BlazorCurrentDeviceService.GetUserAgent();
        StateHasChanged();
    }
}
```



#### Device Methods

To see a real world example you can visit the example [here on Github](https://hugovg.github.io/CurrentDevice/)
<table>
	<tr>
		<th>CurrentDeviceService: Returns True/False</th>
		<th>Method</th>
	</tr>
	<tr>
		<td>Mobile</td>
		<td>BlazorCurrentDeviceService.Mobile()</td>
	</tr>
	<tr>
		<td>Tablet</td>
		<td>BlazorCurrentDeviceService.Tablet()</td>
	</tr>
	<tr>
		<td>Desktop</td>
		<td>BlazorCurrentDeviceService.Desktop()</td>
	</tr>
	<tr>
		<td>iOS</td>
		<td>BlazorCurrentDeviceService.iOS()</td>
	</tr>
	<tr>
		<td>iPad</td>
		<td>BlazorCurrentDeviceService.iPad()</td>
	</tr>
	<tr>
		<td>iPhone</td>
		<td>BlazorCurrentDeviceService.iPhone()</td>
	</tr>
	<tr>
		<td>iPod</td>
		<td>BlazorCurrentDeviceService.iPod()</td>
	</tr>
	<tr>
		<td>Android</td>
		<td>BlazorCurrentDeviceService.Android()</td>
	</tr>
	<tr>
		<td>Android Phone</td>
		<td>BlazorCurrentDeviceService.AndroidPhone()</td>
	</tr>
	<tr>
		<td>Android Tablet</td>
		<td>BlazorCurrentDeviceService.AndroidTablet()</td>
	</tr>
	<tr>
		<td>BlackBerry</td>
		<td>BlazorCurrentDeviceService.Blackberry()</td>
	</tr>
	<tr>
		<td>BlackBerry Phone</td>
		<td>BlazorCurrentDeviceService.BlackberryPhone()</td>
	</tr>
	<tr>
		<td>BlackBerry Tablet</td>
		<td>BlazorCurrentDeviceService.BlackberryTablet()</td>
	</tr>
	<tr>
		<td>Windows</td>
		<td>BlazorCurrentDeviceService.Windows()</td>
	</tr>
	<tr>
		<td>Windows Phone</td>
		<td>BlazorCurrentDeviceService.WindowsPhone()</td>
	</tr>
	<tr>
		<td>Windows Tablet</td>
		<td>BlazorCurrentDeviceService.WindowsTablet()</td>
	</tr>
  	<tr>
		<td>MacOs</td>
		<td>BlazorCurrentDeviceService.MacOs()</td>
	</tr>
	<tr>
		<td>MeeGo</td>
		<td>BlazorCurrentDeviceService.MeeGo()</td>
	</tr>
	<tr>
		<td>Television</td>
		<td>BlazorCurrentDeviceService.Television()</td>
	</tr>
</table>

#### Orientation Methods

<table>
	<tr>
		<th>Orientation returns string "landscape" or "portrait"</th>
		<th>Method</th>
	</tr>
	<tr>
		<td>Landscape</td>
		<td>BlazorCurrentDeviceService.Landscape()</td>
	</tr>
	<tr>
		<td>Portrait</td>
		<td>BlazorCurrentDeviceService.Portrait()</td>
	</tr>
</table>

### Useful Methods

<table>
	<tr>
		<th>Method</th>
		<th>Returns</th>
	</tr>
	<tr>
		<td>BlazorCurrentDeviceService.Type()</td>
		<td>'mobile', 'tablet', 'desktop', or 'unknown'</td>
	</tr>
	<tr>
		<td>BlazorCurrentDeviceService.Orientation()</td>
		<td>'landscape', 'portrait', or 'unknown'</td>
	</tr>
	<tr>
		<td>BlazorCurrentDeviceService.OS()</td>
		<td>'ios', 'iphone', 'ipad', 'ipod', 'android', 'blackberry', 'windows', 'macos', 'meego', 'television', or 'unknown'</td>
	</tr>
</table>

## Technical information

### Lifetimes

Eventhough in DI it get added as scoped, 
blazor WASM will treat it as a singleton [more on that here](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/dependency-injection?view=aspnetcore-8.0#service-lifetime) 
meaning that if an user changes User agents and refreshes the page it'll still display old data untill a page refresh

For blazor server it is scoped and every page request will have up to date information, interal responses get cached clientside per request so that if you check for Ipad then iOs it'll save some requests to the browser



## License
MIT
