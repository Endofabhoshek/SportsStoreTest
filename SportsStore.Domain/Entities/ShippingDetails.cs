using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please Enter A Name!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter First Address Line!!")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Enter The City!!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter The State!!")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Enter The Country!!")]        
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
