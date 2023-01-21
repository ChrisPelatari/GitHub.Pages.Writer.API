task :b dotnet:build do
  sh "dotnet build src/API/Github.Pages.Writer.API.csproj"
end

task :s do
  sh "dotnet run -p src/API/Github.Pages.Writer.API.csproj"
end

task :default => :s