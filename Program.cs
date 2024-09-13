using CustomersTable.Components;
using CustomersTable.Data.Interfaces;
using CustomersTable.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var baseAddress = builder.Configuration.GetValue<string>("BaseAddress");

builder.Services.AddSingleton(sp => new HttpClient(new HttpClientHandler
{
    UseCookies = true
})
{
    BaseAddress = new Uri(baseAddress)
});

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerManagementService, CustomerManagementService>();
builder.Services.AddScoped<ICustomerDialogService, CustomerDialogService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<IComponentCommunicationService, ComponentCommunicationService>();

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
