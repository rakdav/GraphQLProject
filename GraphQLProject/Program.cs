using GraphQLProject.DataAccess.DAO;
using GraphQLProject.DataAccess.Data;
using GraphQLProject.DataAccess.Entity;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddDbContext<SampleAppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer().AddQueryType<Query>().
    AddMutationType<Mutation>().AddSubscriptionType<Subscription>().AddInMemorySubscriptions();
builder.Services.AddScoped<DepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<EmployeeRepository, EmployeeRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseWebSockets();
using (var scope = app.Services.CreateScope())
{
    var services=scope.ServiceProvider;
    var db=services.GetRequiredService<SampleAppDbContext>();
    DataSeeder.SeedData(db);
}
app.MapGraphQL("/graphql");
app.Run();
