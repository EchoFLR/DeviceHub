using DeviceHub.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Using scoped here (for Blazor, REST controllers are still inited per request).
//Ideally it should be singleton but it would take more time to sync requests
//For the demo case it is an instanced node which listens to targeted broadcasted events
builder.Services.AddScoped<DeviceController>();
builder.Services.AddControllers();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

app.Run();
