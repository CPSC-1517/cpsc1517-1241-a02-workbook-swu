using Microsoft.EntityFrameworkCore; // for extension method UseSqlServer 
using WestWindSystem; // for extension method AddBackendDependencies
using WestWindWebApp.Components;

var builder = WebApplication.CreateBuilder(args);

var westwindConnectionString = builder
                                .Configuration
                                .GetConnectionString("WestWindConnection");
builder.Services.AddBackendDependencies(options =>
    options.UseSqlServer(westwindConnectionString));


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
