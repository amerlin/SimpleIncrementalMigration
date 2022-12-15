var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSystemWebAdapters()
   .AddJsonSessionSerializer(option =>
   {
       TestLibrary.Class1.RegistrionSessionKeys(option.KnownKeys);
   })
    //.WrapAspNetCoreSession();
    .AddRemoteAppClient(options =>
    {
        options.ApiKey = "ea1949f0-7ce0-4f1d-b735-22a1305c8a02";
        options.RemoteAppUrl = new Uri(builder.Configuration["ReverseProxy:Clusters:fallbackCluster:Destinations:fallbackApp:Address"]);
    })
    .AddAuthenticationClient(true)
    .AddSessionClient();

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSystemWebAdapters();

// Minimal api
app.MapGet("/test1", (HttpContext ctx) => TestLibrary.Class1.GetUserAgentFromContext(ctx));
app.MapGet("/test2", () => TestLibrary.Class1.GetUserAgent());

// Session
app.MapGet("/session-set", ([Microsoft.AspNetCore.Mvc.FromQuery] string message) =>
{
    TestLibrary.Class1.SetValue(message);
    return $"Set session to {message}";
}).RequireSystemWebAdapterSession();
app.MapGet("/session-get", () => TestLibrary.Class1.GetValue()).RequireSystemWebAdapterSession();


app.MapDefaultControllerRoute();
app.MapReverseProxy();

app.Run();
