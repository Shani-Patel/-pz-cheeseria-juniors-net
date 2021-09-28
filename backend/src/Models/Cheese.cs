using System.ComponentModel.DataAnnotations.Schema;

namespace Pz.Cheeseria.Api.Models
{
    [Table("Cheese", Schema = "dbo")]
    public class Cheese
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Price_suffix { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

    }
}
