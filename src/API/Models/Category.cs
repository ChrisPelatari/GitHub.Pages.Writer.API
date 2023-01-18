using System.ComponentModel.DataAnnotations;

namespace GitHub.Pages.Writer.API.Models {
    public class Category {
        public int Id { get; set; }
        public int ParentID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
