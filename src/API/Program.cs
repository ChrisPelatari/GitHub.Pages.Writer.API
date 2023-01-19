using GitHub.Pages.Writer.API;
using GitHub.Pages.Writer.API.Services;
using Microsoft.EntityFrameworkCore;
using WilderMinds.MetaWeblog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMetaWeblog<MetaWeblogProvider>();
builder.Services.AddTransient<IFileStorage, JekyllFileStorage>();
builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlite("Data Source=Data/Blog.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseMetaWeblog("/metablog");

app.Run();

public partial class Program{}