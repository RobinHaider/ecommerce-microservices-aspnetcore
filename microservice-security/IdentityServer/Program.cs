using IdentityServer;
using IdentityServer4.Test;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryIdentityResources(Config.IdentityResources)
                //.AddTestUsers(TestUsers.Users)
                .AddDeveloperSigningCredential(); ;

var app = builder.Build();

app.UseRouting();
app.UseIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();
