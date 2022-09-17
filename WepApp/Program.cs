using Microsoft.EntityFrameworkCore;
using WepApp.Application.Orders;
using WepApp.Application.Users;
using WepApp.Domain.Contracts;
using WepApp.Infra;
using WepApp.Infra.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<MainContext>(options =>
{
    var conStr = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(conStr, sqlOpt =>
    {
    });
});

builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<ICreateNewOrderService, CreateNewOrderService>();


builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ICreateNewUserService, CreateNewUserService>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IGetUserByUsernameService, GetUserByUsernameService>();
builder.Services.AddScoped<IUpdateUserService, UpdateUserService>();
builder.Services.AddScoped<IDeleteUserService, DeleteUserService>();


builder.Services.AddScoped<IGenderizeService, GenderizeService>();

builder.Services.AddHttpClient();

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

public partial class Program { }