using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace For03.Models
{
    public class Service
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Descrtiption { get; set; }
        public string Discount { get; set; }
        [NotMapped]
        public Image ServiceImage { get; set; }
    }
}
