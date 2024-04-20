# CurrentDevice

Device/User agent detector made in Blazor for Blazor. This library is a port of [CurrentDevice](https://github.com/matthewhudson/current-device/)

No need to use JavaScript interop to detect the device or user agent. This library is a pure C# implementation of the original library.

This library is trimmable and does not rely on Javascript (no need to add a <script> tag somewhere)

### Nuget CLI
``dotnet add package CurrentDevice``

### Csproj
``<PackageReference Include="CurrentDevice" Version="1.0.2" />``

## Add reference in _Imports.razor

`@using CurrentDevice`

## Usage

### Add the service in your services method

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
//...  Shortend for brevity
builder.Services.AddCurrentDeviceService();
//... Shortend for brevity
await builder.Build().RunAsync();
```

### Inject the service in your component

```csharp
@code{
    [Inject] ICurrentDeviceService CurrentDeviceService { get; set; }
}
```
or
```csharp
@inject ICurrentDeviceService CurrentDeviceService
```

### Usage in your component

#### Blazor WASM

```csharp
protected override async Task OnInitializedAsync()
{
    UserAgent = await CurrentDeviceService.GetUserAgent();
}
```

#### Blazor Server

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        UserAgent = await CurrentDeviceService.GetUserAgent();
        StateHasChanged();
    }
}
```



#### Device Methods

To see a real world example you can visit the example [here on Github](https://hugovg.github.io/CurrentDevice/)



## Technical information

### Lifetimes

Eventhough in DI it get added as scoped,
blazor WASM will treat it as a singleton [more on that here](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/dependency-injection?view=aspnetcore-8.0#service-lifetime)
meaning that if an user changes User agents and refreshes the page it'll still display old data untill a page refresh

For blazor server it is scoped and every page request will have up to date information, interal responses get cached clientside per request so that if you check for Ipad then iOs it'll save some requests to the browser



## License
MIT
