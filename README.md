# CurrentDevice

Device/User agent detector made in Blazor for Blazor. This library is a port of [CurrentDevice](https://github.com/matthewhudson/current-device/)

No need to use JavaScript interop to detect the device or user agent. This library is a pure C# implementation of the original library.

> [!WARNING]  
> This library is still in development and may not be stable or working as you expect. Please use with caution.

## Add reference in _Imports.razor

`@using BlazorCurrentDevice`


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

<table>
	<tr>
		<th>BlazorCurrentDeviceService</th>
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
		<th>Orientation</th>
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
		<td>'ios', 'iphone', 'ipad', 'ipod', 'android', 'blackberry', 'windows', 'macos', 'fxos', 'meego', 'television', or 'unknown'</td>
	</tr>
</table>

## License
MIT
