using Microsoft.EntityFrameworkCore;
using Web_Server.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DataBaseConnection")));
builder.Services.AddControllers();

var app = builder.Build();

app.Urls.Add("http://localhost:12300");
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.EnsureCreated();
}

app.Run();
