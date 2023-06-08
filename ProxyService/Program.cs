using Common;
using HotChocolate;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient(ServicesNames.Products, c => c.BaseAddress = new Uri("http://localhost:8081/graphql"));
builder.Services.AddHttpClient(ServicesNames.Properties, c => c.BaseAddress = new Uri("http://localhost:8082/graphql"));

builder.Services.AddGraphQLServer()
        .AddRemoteSchema(ServicesNames.Products)
        .AddRemoteSchema(ServicesNames.Properties);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebSockets();
app.MapControllers();
app.MapGraphQL("/graphql");

app.Run();
