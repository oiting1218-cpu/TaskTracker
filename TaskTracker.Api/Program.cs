//Create application builder
var builder = WebApplication.CreateBuilder(args);

//Register services in DI container
builder.Services.AddControllers();

//Build application
var app = builder.Build();

//Connect incoming HTTP requests to my controller routes
app.MapControllers();

//Redirect Http to Https for improving security
app.UseHttpsRedirection();

//Start application 
app.Run();

