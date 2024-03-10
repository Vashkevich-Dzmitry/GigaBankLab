using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GigaBankLab.Data;
using GigaBankLab.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<GigaBankLabContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GigaBankLabContext") ?? throw new InvalidOperationException("Connection string 'GigaBankLabContext' not found."))
);

builder.Services.AddScoped<AccountsService>();
builder.Services.AddScoped<TransactionsService>();
builder.Services.AddScoped<CurrentDateService>();
builder.Services.AddScoped<DepositsService>();
builder.Services.AddScoped<BankOperationsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
