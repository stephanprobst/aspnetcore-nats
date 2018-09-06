# ASP<span></span>.NET Core NATS Integration

## How to use

Add nuget package

```bash
dotnet add package Probst.AspNetCore.Nats
```

In your ASP<span></span>.NET Core Startup class:

```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddNats(options =>
        {
            options.Url = "nats://nats:4222";
            // configure other options
        });

        services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
```

Inject an interface of `IJsonEncodedConnection`, `IEncodedConnection` or `IConnection` where you wan't to use `NATS` (e.g. in your Controller constructor):

```csharp
    public ValueController(IJsonEncodedConnection natsConnection)
    {
        _natsConnection = natsConnection;
    }
    
    // Use it
```

The `IJsonEncodedConnection` is a convenience interface which abstracts a `IEncodedConnection` with built in object to bytes conversion with `Newtonsoft.Json`. The `IEncodedConnection` has also already preinitialized conversion.


## NATS Project

[NATS Website](https://nats.io)

## Used NATS client libary
[nats-io/csharp-nats](https://github.com/nats-io/csharp-nats)

