using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pz.Cheeseria.Api.Models
{
    [Table("Cart", Schema = "dbo")]
    public class Orders : ICreatedUtcColumn
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(38, 2)")]
        public decimal total_price { get; set; }

        public int total_quantity { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        /// <summary>
        /// The date and time (in utc) at which the order was created
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime CreatedUtc { get; set; }
    }
}