task :t do
  sh "dotnet test src/Tests/Github.Pages.Writer.Tests.csproj"
end

task :b do
  sh "dotnet build src/API/Github.Pages.Writer.API.csproj"
end

task :s do
  sh "dotnet run -p src/API/Github.Pages.Writer.API.csproj"
end

task :default => :b