using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GitHub.Pages.Writer.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentID", "Slug" },
                values: new object[,]
                {
                    { 1, "Programming", "Programming", 0, "programming" },
                    { 2, "Life", "Life", 0, "life" },
                    { 3, "As if you cared", "as-if-you-cared", 0, "as-if-you-cared" },
                    { 4, "Professional Geek", "professional_geek", 0, "professional-geek" },
                    { 5, "RSSBandit", "rssbandit", 0, "rssbandit" },
                    { 6, "PostXing", "postxing", 0, "postxing" },
                    { 7, ".NET", "dotnet", 0, "dotnet" },
                    { 8, "C#", "csharp", 0, "csharp" },
                    { 9, "WinForms", "winforms", 0, "winforms" },
                    { 10, "Visual Studio", "visual_studio", 0, "visual-studio" },
                    { 11, "ASP.NET", "aspnet", 0, "aspnet" },
                    { 12, "BlogML", "BlogML", 0, "blogml" },
                    { 13, "SubSonic", "SubSonic", 0, "subsonic" },
                    { 14, "JavaScript", "javascript", 0, "javascript" },
                    { 15, "DataGridView", "DataGridView", 0, "datagridview" },
                    { 16, "Subversion", "subversion", 0, "subversion" },
                    { 17, "SVN", "svn", 0, "svn" },
                    { 18, "Apache", "apache", 0, "apache" },
                    { 19, "xUnit", "xunit", 0, "xunit" },
                    { 20, "StructureMap", "StructureMap", 0, "structuremap" },
                    { 21, "SQLite", "SQLite", 0, "sqlite" },
                    { 22, "MVC", "mvc", 0, "mvc" },
                    { 23, "Standard", "Standard", 0, "standard" },
                    { 24, "Stencil", "stencil", 0, "stencil" },
                    { 25, "Street Art", "streetart", 0, "streetart" },
                    { 26, "Same", "same", 0, "same" },
                    { 27, "Image", "Image", 0, "image" },
                    { 28, "Rake", "rake", 0, "rake" },
                    { 29, "Geek", "geek", 0, "geek" },
                    { 30, "Music", "music", 0, "music" },
                    { 31, "Travel", "travel", 0, "travel" },
                    { 32, "Puerto Rico", "puerto_rico", 0, "puerto-rico" },
                    { 33, "Ruby", "ruby", 0, "ruby" },
                    { 34, "Math", "math", 0, "math" },
                    { 35, "Personal", "personal", 0, "personal" },
                    { 36, "Albacore", "albacore", 0, "albacore" },
                    { 37, "Windows", "Windows", 0, "windows" },
                    { 38, "GRUB", "grub", 0, "grub" },
                    { 39, "Linux", "linux", 0, "linux" },
                    { 40, "Jekyll", "jekyll", 0, "jekyll" },
                    { 41, "Liquid", "liquid", 0, "liquid" },
                    { 42, "GitHub Pages", "github-pages", 0, "github-pages" },
                    { 43, "Git", "git", 0, "git" },
                    { 44, "ZSH", "zsh", 0, "zsh" },
                    { 45, "Philosophy", "Philosophy", 0, "philosophy" },
                    { 46, "Ruby", "Ruby", 0, "ruby" },
                    { 47, "Linux", "Linux", 0, "linux" },
                    { 48, "Unbuntu", "Unbuntu", 0, "unbuntu" },
                    { 49, "Programming", "Programming", 0, "programming" },
                    { 50, "gh-pages", "gh-pages", 0, "gh-pages" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50);
        }
    }
}
