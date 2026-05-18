using GestaoFinanceira.Client.Services;
using GestaoFinanceira.Domain.Repositories;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();


builder.Services.AddScoped<HttpClient>(options =>
{
    var httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri("https://localhost:7133");
    return httpClient;
});

builder.Services.AddScoped<IAccountRepository, AccountService>();
builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<ICompanyRepository, CompanyService>();
builder.Services.AddScoped<IFinancialTransactionsRepository, FinancialTransctionService>();

await builder.Build().RunAsync();
