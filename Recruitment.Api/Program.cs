using Recruitment.Contracts.Repositories;
using Recruitment.Contracts.Services;
using Recruitment.Infrastructure.Repositories;
using Recruitment.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IExampleRepository, ExampleRepository>(); //singleton to persist example/test data
builder.Services.AddTransient<ICRUDServiceExample, CRUDServiceExample>();

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
})
    .AddXmlSerializerFormatters();

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

app.MapControllers();

app.Run();