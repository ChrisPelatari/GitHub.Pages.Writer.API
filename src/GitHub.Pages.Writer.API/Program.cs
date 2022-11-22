using GitHub.Pages.Writer.API;
using GitHub.Pages.Writer.API.Services;
using WilderMinds.MetaWeblog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMetaWeblog<MetaWeblogProvider>();
builder.Services.AddTransient<IFileStorage, JekyllFileStorage>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseMetaWeblog("/metablog");

app.Run();