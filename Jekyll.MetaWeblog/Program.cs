using Jekyll.MetaWeblog;
using WilderMinds.MetaWeblog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMetaWeblog<MetaWeblogProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseMetaWeblog("/metablog");

app.Run();