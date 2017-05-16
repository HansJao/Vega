using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Models.Request
{
    public class VehicleRequest
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        public ContactRequest Contact { get; set; }
        public ICollection<int> Features { get; set; }
        public VehicleRequest()
        {
            Features = new Collection<int>();
        }
    }

    public class ContactRequest
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Phone { get; set; }
    }
}