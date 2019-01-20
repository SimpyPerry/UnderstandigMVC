using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandigMVC.Models
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [MinLength(5)]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string ArtistId { get; set; }
        public DateTime ArtistDeath { get; set; } = DateTime.UtcNow;
        public DateTime ArtistBirth { get; set; } = DateTime.UtcNow;
    }
}
