using RestaurantReservation.API;
using RestaurantReservation.Business.ServiceClass;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repository;
using RestaurantReservation.Domain.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(((ctx, lc) => lc
    .WriteTo.File(Directory.GetCurrentDirectory())));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant Reservation", Version = "v1" }));
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<EmployeeService>();
builder.Services.AddSingleton<OrderService>();
builder.Services.AddSingleton<MenuItemService>();
builder.Services.AddSingleton<ReservationService>();
builder.Services.AddSingleton<RestaurantService>();
builder.Services.AddSingleton<TableService>();
builder.Services.AddSingleton<OrderItemService>();
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddSingleton<IReservationRepository, ReservationRepository>();
builder.Services.AddSingleton<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddSingleton<ITableRepository, TableRepository>();
builder.Services.AddSingleton<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddSingleton<RestaurantReservationDbContext>();
builder.Services.AddSingleton<IJwt, Jwt>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWTToken:Issuer"],
        ValidAudience = builder.Configuration["JWTToken:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTToken:key"]))
    };
}
);
builder.Services.AddAuthorization();
builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant Reservation")
    );
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();