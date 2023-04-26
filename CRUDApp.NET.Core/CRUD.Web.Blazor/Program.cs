using CRUD.Web.Blazor.Classes;
using CRUD.Web.Blazor.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddScoped<HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Use(async (context, next) =>
//{
//    var identity = context.User?.Identity?.Name;
//    var requestedResource = context.Request.Path;

//    // Do work that can write to the Response.
//    await next.Invoke();
//    // Do logging or other work that doesn't write to the Response.
//});


app.UseHttpsRedirection();

//app.Use(async (context, next) =>
//{
//    context.Request.Headers.Add("x-my-custom-header", context.User?.Identity?.Name);
//    await next();
//});

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();