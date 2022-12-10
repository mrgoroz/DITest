using DITest.Data;
using DITest.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IOC registration
builder.Services.AddDbContext<AddressDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("sqlServer"))
    );
builder.Services.AddDbContext<UserDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("sqlServer"))
    );
builder.Services.AddDbContext<TimeslotDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("sqlServer"))
    );
builder.Services.AddDbContext<DeliveryDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("sqlServer"))
    );

builder.Services.AddHttpClient<IHolidayApiService, HolidayApiService>(o => o.BaseAddress = new Uri("https://holidayapi.com/v1/"));
builder.Services.AddSingleton<ICourierReaderService, CourierReaderService>();

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

