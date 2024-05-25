using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Interfaces;
using CustomerRewardsTelecom.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//plugging in Application Context
builder.Services.AddDbContext<CustomerRewardsTelecom.Database.ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddHttpClient<SOAPDemoSoap, SOAPDemoSoap>(client =>
//{
//    client.BaseAddress = new Uri("https://www.crcind.com/csp/samples/SOAP.Demo.cls");
//});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchasesRepository>();
builder.Services.AddScoped<IRewardsRepository, RewardsRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
