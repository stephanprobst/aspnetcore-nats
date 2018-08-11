# ASP<span></span>.NET Core NATS Integration

## How to use

In your ASP<span></span>.NET Core Startup class:

```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddNats(options =>
        {
            options.Url = "nats://nats:4222";
        });

        services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
```

### NATS Project

[NATS Website](https://nats.io)