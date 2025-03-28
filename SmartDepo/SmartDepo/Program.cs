using SmartDepo.Components;
using SmartDepo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// For prerendering purposes, register a named HttpClient for the app's
// named client component example.
builder.Services.AddHttpClient<ITramService, TramService>("WebAPI", client =>
    client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "http://localhost:5002"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
