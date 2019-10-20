using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ListadoProductosWebs.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name  { get; set; }
        [Required]
        [StringLength(40)]
        public string Brand { get; set; }
        [Required]
        [StringLength(40)]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

    }
}