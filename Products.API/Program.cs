using Products.API.Middleware;
using Products.Application.Extensions;
using Products.Infrastructure.Extensions;
using Products.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173");
    });
});
builder.Services.AddInfrastructureServices(builder.Configuration,builder.Environment.ContentRootPath);
builder.Services.AddApplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IProductSeeder>();
if (seeder != null)
    await seeder.Seed();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

//Adding this partial class as a workaround so that it can be passed on to IntegrationTests
public partial class Program
{

}
