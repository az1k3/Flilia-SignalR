using SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR(); 

var app = builder.Build();

app.UseStaticFiles();
app.MapHub<ChatHub>("/chat");

app.Run();
