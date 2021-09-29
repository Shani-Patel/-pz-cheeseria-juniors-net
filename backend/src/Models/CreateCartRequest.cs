using System.Collections.Generic;

namespace Pz.Cheeseria.Api.Models
{
    public class CreateCartRequest
    {
        public List<(int, int)> Cart { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
