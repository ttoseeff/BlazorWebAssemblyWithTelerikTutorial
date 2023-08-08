using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class Publishers
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int  CityId { get; set; }
        public City City { get; set; }
    }
}
