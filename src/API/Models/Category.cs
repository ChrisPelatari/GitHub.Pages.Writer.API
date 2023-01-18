using System.ComponentModel.DataAnnotations;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Models {
    public class Category {
        public int Id { get; set; }
        public int ParentID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }

        public static implicit operator CategoryInfo(Category category)
        {
            return new CategoryInfo
            {
                categoryid = category.Id.ToString(),
                title = category.Name,
                description = category.Description,
                htmlUrl = category.Slug,
                rssUrl = category.Slug
            };
        }   
    }
}
