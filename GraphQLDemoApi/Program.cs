using GraphQLDemoApi.Schema.Mutations;
using GraphQLDemoApi.Schema.Queries;

var builder = WebApplication.CreateBuilder(args);

var serviceCollection = builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();



//app.MapGet("/", () => "Hello World!");


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


app.Run();
