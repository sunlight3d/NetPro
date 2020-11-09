using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsMvc.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string UniqueInformation { get; set; }
        public string Category { get; set; }
    }
}
