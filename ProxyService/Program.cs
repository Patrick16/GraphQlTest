using Common;
using ProxyService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<HeaderAddInterceptor>();
builder.Services.AddHttpClient(ServicesNames.Products, c => c.BaseAddress = new Uri("http://localhost:8081/graphql"))
    .AddHttpMessageHandler<HeaderAddInterceptor>();
builder.Services.AddHttpClient(ServicesNames.Properties, c => c.BaseAddress = new Uri("http://localhost:8082/graphql"))
    .AddHttpMessageHandler<HeaderAddInterceptor>();

builder.Services.AddGraphQLServer()
        .AddRemoteSchema(ServicesNames.Products)
        .AddRemoteSchema(ServicesNames.Properties)
        .AddErrorFilter<CustomErrorFilter>()
        .AddDiagnosticEventListener<ProxyExecutionEventListener>();

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
app.UseGraphQLVoyager("/graphql-voyager");

app.Run();
