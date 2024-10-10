using Microsoft.EntityFrameworkCore;
using Web_Server.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DataBaseConnection")));
//builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();
if (!app.Environment.IsDevelopment()) { app.UseHttpsRedirection(); }
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Urls.Add("http://localhost:12300");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var db= scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.EnsureCreated();
}

    app.Run();
