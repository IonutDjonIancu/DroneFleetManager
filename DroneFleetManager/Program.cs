using PricingService;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// repos
var droneDb = new DroneDb(); // let's consider this comes from 3rd party we won't modify it
builder.Services.AddSingleton(droneDb);
builder.Services.AddSingleton<IPriceStorage, PriceStorage>();
builder.Services.AddSingleton<IDroneStorage, DroneStorage>();

// services
builder.Services.AddSingleton<IPricingManager, PricingManager>();

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
