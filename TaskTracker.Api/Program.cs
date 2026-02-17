using TaskTracker.Api.Data;
using Microsoft.EntityFrameworkCore;

//Create application builder
var builder = WebApplication.CreateBuilder(args);

//Register services in DI container
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Build application
var app = builder.Build();

//Connect incoming HTTP requests to my controller routes
app.MapControllers();

//Redirect Http to Https for improving security
app.UseHttpsRedirection();

//Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Start application 
app.Run();

