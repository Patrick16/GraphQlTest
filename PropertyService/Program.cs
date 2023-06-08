using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PropertyService.DataAccess.Repositories;
using PropertyService.DataAccess.Repositories.Interfaces;
using PropertyService.Database;
using PropertyService.GraphQl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddSingleton<IDesignTimeDbContextFactory<MyDbContext>, ContextFactory>();
builder.Services.AddMemoryCache();

builder.Services.AddGraphQLServer()
    .AddQueryType<Queries>()
    .AddMutationType<Mutations>()
    .AddSubscriptionType<Subscriptions>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions();

//builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
//builder.Services.AddScoped<PropertyQuery>();
//builder.Services.AddScoped<PropertyType>();
//builder.Services.AddScoped<PaymentType>();
builder.Services.AddDbContext<MyDbContext>(
    options => options.UseNpgsql(builder.Configuration["ConnectionStrings:GraphQlTestDb"]));

//var sp = builder.Services.BuildServiceProvider();
//builder.Services.AddSingleton<ISchema>(
//new GraphQlSchema(
//    new FuncDependencyResolver(
//        t => sp.GetService(t))));

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
