//using System;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Pz.Cheeseria.Api.Models
//{
//    [Table("Cart", Schema = "dbo")]
//    public class Cart : ICreatedUtcColumn
//    {
//        public int Id { get; set; }

//        public int Order_id { get; set; }

//        public int Cheese_id { get; set; }

//        public int Quantity { get; set; }

//        /// <summary>
//        /// The date and time (in utc) at which the account was created
//        /// </summary>
//        [Column(TypeName = "datetime")]
//        public DateTime CreatedUtc { get; set; }

//        //[ForeignKey(nameof(Order_id))]
//        //public virtual Orders Order { get; set; }

//        //[ForeignKey(nameof(Cheese_id))]
//        //public virtual Cheese Cheese { get; set; }
//    }
//}