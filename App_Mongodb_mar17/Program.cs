using App_Mongodb_mar17.Models;
using App_Mongodb_mar17.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ProductStoreSetting>(builder.Configuration.GetSection("ProductDatabase"));

builder.Services.AddSingleton<ProductService>();

builder.Services.AddControllers().AddJsonOptions(opt=>opt.JsonSerializerOptions.PropertyNamingPolicy=null);

builder.Services.AddCors(options =>
{
    options.AddPolicy("swagger", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("swagger");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
