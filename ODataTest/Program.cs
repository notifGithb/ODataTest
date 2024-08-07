using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ODataTest.Context;
using ODataTest.Middleware;
using ODataTest.Servisler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddOData(opt => opt.EnableQueryFeatures());


builder.Services.AddDbContext<ODataTestContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<ISehirServisi, SehirServisi>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseODataResponseManipulation();//Middleware eklendi.

app.MapControllers();

app.Run();
