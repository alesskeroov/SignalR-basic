using SignalR_basic_.Business;
using SignalR_basic_.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
     policy.AllowAnyMethod()
     .AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(otigin => true)

));
builder.Services.AddControllers();
builder.Services.AddTransient<MyBusiness>();
var app = builder.Build();

app.UseCors();

app.MapHub<MyHub>("/MyHub");
app.MapHub<MessageHub>("/MessageHub");
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
