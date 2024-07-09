using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ODataTest.Context;
using ODataTest.Filters;
using ODataTest.Servisler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new MyAsyncActionFilter());
}).AddOData(opt => opt.EnableQueryFeatures());

builder.Services.AddScoped<MyAsyncActionFilter>();

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
app.UseODataBatching();
app.UseODataQueryRequest();
app.UseODataRouteDebug();
app.MapControllers();

app.Run();
