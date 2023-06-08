using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProductService.DataAccess.Repositories;
using ProductService.DataAccess.Repositories.Interfaces;
using ProductService.Database;
using ProductService.GraphQl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IDesignTimeDbContextFactory<MyDbContext>, ContextFactory>();
builder.Services.AddMemoryCache();

builder.Services.AddGraphQLServer()
    .AddQueryType<Queries>()
    .AddMutationType<Mutations>()
    .AddSubscriptionType<Subscriptions>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions()
    .InitializeOnStartup()
    .PublishSchemaDefinition(c => c
      .SetName(ServicesNames.Products));

builder.Services.AddDbContext<MyDbContext>(
    options => options.UseNpgsql(builder.Configuration["ConnectionStrings:GraphQlTestDb"]));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<MyDbContext>();
    db.EnsureSeedData();
}

app.UseWebSockets();
app.MapControllers();
app.MapGraphQL("/graphql");

app.Run();
